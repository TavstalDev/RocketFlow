# API Reference

This page explains the core RocketFlow classes. Everything lives in the `Tavstal.RocketFlow` root namespace, with the internal machinery under `Tavstal.RocketFlow.RocketListeners` (you don't need to touch those).

For hands-on examples, see [Getting Started](getting-started.md).

---

## `RocketFlow` (static class)

`Tavstal.RocketFlow.RocketFlow`

The entry point. Sets up all of RocketFlow's internal listeners.

| Method | Description |
|--------|-------------|
| `void Initialize()` | Hooks RocketFlow's listeners into Unturned and RocketMod. Safe to call multiple times; it only initializes once. Call this in your plugin's `Load()`. |

```csharp
RocketFlow.Initialize();
```

---

## `EventManager` (static class)

`Tavstal.RocketFlow.Core.EventManager`

The heart of RocketFlow. Stores all registered handlers and fires events to them in priority order.

### Registering handlers

| Method | Description |
|--------|-------------|
| `void RegisterAll(RocketPlugin plugin)` | Scans the plugin's assembly for every class implementing `EventListener`, creates an instance, and registers all of its `[EventHandler]` methods. |
| `void RegisterAll(object listenerInstance)` | Registers every `[EventHandler]` method on a single listener instance. |

Both methods throw `InvalidOperationException` if a `[EventHandler]` method doesn't have the correct signature (exactly one parameter derived from `Event`).

### Unregistering handlers

| Method | Description |
|--------|-------------|
| `void UnregisterAll(RocketPlugin plugin)` | Removes all handlers registered by that plugin's assembly. |
| `void UnregisterAll(object listenerInstance)` | Removes all handlers belonging to one listener instance. |
| `void UnregisterAssembly(Assembly assembly)` | Removes all handlers whose methods come from a specific assembly. |

### Firing events

| Method | Description |
|--------|-------------|
| `TEvent Fire<TEvent>(TEvent e)` | Dispatches an event to every matching handler, in priority order. Honors the handled signal from `ICancellable`: once a handler sets `IsCancelled`, remaining handlers are skipped unless they opt in with `ignoreCancelled: true`. |

You normally won't call `Fire` yourself — the built-in events do it for you. It's there for advanced use (for example, firing your own custom events, see below).

```csharp
// Fire your own custom event
EventManager.Fire(new MyCustomEvent(...));
```

---

## `EventHandlerAttribute`

`Tavstal.RocketFlow.Attributes.EventHandlerAttribute`

Marks a method as an event handler. Apply it to methods that take exactly one `Event`-derived parameter.

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Priority` | `EEventPriority` | `NORMAL` | Determines when the handler runs relative to others. |
| `IgnoreCancelled` | `bool` | `false` | If `true`, the handler runs even when an earlier handler set `IsCancelled`. |

```csharp
[EventHandler]
[EventHandler(EEventPriority.HIGH)]
[EventHandler(EEventPriority.LOWEST, ignoreCancelled: true)]
```

---

## `EEventPriority` (enum)

`Tavstal.RocketFlow.Core.EEventPriority`

Controls execution order. Handlers run from **highest** to **lowest**; equal priorities run in registration order.

| Value | Number |
|-------|--------|
| `LOWEST` | -20 |
| `LOW` | -10 |
| `NORMAL` | 0 |
| `HIGH` | 10 |
| `HIGHEST` | 20 |

---

## `Event` (abstract class)

`Tavstal.RocketFlow.Core.Event`

The base class of every RocketFlow event.

| Property | Type | Description |
|----------|------|-------------|
| `FiredAtUtc` | `DateTime` | When the event was created, in UTC. Useful for timing/audit purposes. |

---

## `EventListener` (interface)

`Tavstal.RocketFlow.Core.EventListener`

A marker interface. Any class that implements it is recognized by `EventManager.RegisterAll(plugin)` as a listener candidate. It declares no members — you just implement it and add `[EventHandler]` methods.

```csharp
public class MyListener : EventListener
{
    [EventHandler]
    public void OnChat(PlayerChatEvent e) { }
}
```

---

## `ICancellable` (interface)

`Tavstal.RocketFlow.Core.ICancellable`

A marker interface that adds a **handled signal** to an event. Implement it on your own custom events to participate in handled-signal dispatch too.

| Property | Type | Description |
|----------|------|-------------|
| `IsCancelled` | `bool` | Signals that the event was **handled and modified** by a listener. |

> **Important — `IsCancelled` does not block the action.** `IsCancelled` is a signal to *other listeners*, not a control for the game. Setting it tells the pipeline that the event has already been dealt with, so the remaining (lower-priority) handlers are skipped unless they opt in with `ignoreCancelled: true`. By itself it never prevents the underlying Unturned action.

To actually **allow, block, or change** what happens in the game, modify the event's dedicated control properties. These are named per event and are what feed back into Unturned — for example `Cancel` (`PlayerChatEvent`), `ShouldAllow` (`VehicleEnterEvent`, `BarricadeDamageEvent`, ...), `Allow` (`VehicleCarjackEvent`), `IsAllowed` (`PlayerAllowedToDamagePlayerEvent`), `CancelLoading` (`PluginLoadingEvent`), or `ShouldVanillaBan` (`ProviderBanEvent`).

```csharp
public class MyCustomEvent : Event, ICancellable
{
    public bool ShouldAllow { get; set; } // controls the game action
    public bool IsCancelled { get; set; } // handled signal for other listeners
}

[EventHandler(EEventPriority.NORMAL)]
public void OnCustom(MyCustomEvent e)
{
    e.ShouldAllow = CheckPermissions(e.Player); // actually allows/blocks the action
    e.IsCancelled = true;                       // signals the event was handled and modified
}
```

---

## Writing Custom Events

RocketFlow isn't limited to its built-in events — you can define your own and fire them through the same prioritized pipeline.

```csharp
// 1. Define the event
public class PlayerGreetingEvent : Event, ICancellable
{
    public UnturnedPlayer Player { get; }
    public string Greeting { get; set; }
    public bool ShouldAllow { get; set; } // controls the game action
    public bool IsCancelled { get; set; } // handled signal for other listeners

    public PlayerGreetingEvent(UnturnedPlayer player, string greeting, ref bool shouldAllow)
    {
        Player = player;
        Greeting = greeting;
        ShouldAllow = shouldAllow;
    }
}

// 2. Fire it from anywhere
EventManager.Fire(new PlayerGreetingEvent(player, "Hello!", ref shouldAllow));

// 3. Listen for it like any other event
[EventHandler(EEventPriority.HIGHEST)]
public void OnGreeting(PlayerGreetingEvent e)
{
    if (!CanGreet(e.Player))
    {
        e.ShouldAllow = false; // actually prevents the action
        e.IsCancelled = true;  // signals the event was handled and modified
        return;
    }

    e.Greeting = "Hello there!";
    e.IsCancelled = true; // tells other listeners the event was handled and modified
    Rocket.Core.Logging.Logger.Log($"{e.Player.CharacterName}: {e.Greeting}");
}
```

---

## Type Hierarchy and How Dispatch Works

When you call `Fire`, RocketFlow looks up handlers for the event type **and all of its base types**, in order from most derived to least derived. This means a handler that listens for `Event` (the base class) will be called for *every* event. Handler lists are kept sorted by priority, so dispatch always happens in the correct order.

## Thread Safety

`EventManager` uses thread-safe collections and locks around its subscription lists, so registering/unregistering while events fire is safe. Handler invocation itself runs on whatever thread fired the event (usually the main Unturned thread).
