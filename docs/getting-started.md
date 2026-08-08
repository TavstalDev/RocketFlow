# Getting Started

This guide walks you through adding RocketFlow to your RocketMod plugin and writing your first event handler. It assumes you already have a RocketMod plugin project for Unturned.

## Requirements

- Unturned 3.24.x or later
- [RocketMod](https://rocketmod.net/) installed on the server
- .NET Framework 4.8

## 1. Reference RocketFlow

Copy `RocketFlow.dll` into a folder your project can reach (for example `Libs/`), then add a reference to it in your `.csproj`:

```xml
<Reference Include="RocketFlow">
  <HintPath>Libs\RocketFlow.dll</HintPath>
  <Private>False</Private>
</Reference>
```

## 2. Initialize RocketFlow

Call `RocketFlow.Initialize()` once when your plugin loads. This hooks RocketFlow's internal listeners into Unturned and RocketMod. It's safe to call more than once — it only sets up once.

```csharp
using Rocket.Core.Plugins;

public class MyPlugin : RocketPlugin
{
    protected override void Load()
    {
        Tavstal.RocketFlow.RocketFlow.Initialize();
    }
}
```

## 3. Create an Event Listener

A listener is any class that implements the `EventListener` interface. Inside it, every method marked with `[EventHandler]` is called automatically when the matching event fires.

```csharp
using Rocket.Core.Logging;
using Tavstal.RocketFlow.Attributes;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Player;
using Tavstal.RocketFlow.Events.Player.Life;

public class PlayerListener : EventListener
{
    [EventHandler]
    public void OnChat(PlayerChatEvent e)
    {
        Logger.Log($"{e.Player.CharacterName} said: {e.Message}");
    }

    [EventHandler]
    public void OnPlayerDeath(PlayerDeathEvent e)
    {
        Logger.Log($"{e.Player.CharacterName} died from {e.Cause}.");
    }
}
```

Each handler method must take **exactly one parameter** — the event class it wants to receive. If you get the signature wrong, RocketFlow throws an `InvalidOperationException` at registration time with a clear message.

## 4. Register the Listener

In your plugin's `Load()` method, register your listener instance:

```csharp
protected override void Load()
{
    RocketFlow.Initialize();
    EventManager.RegisterAll(new PlayerListener());
    // or if your plugin itself is the listener:
    EventManager.RegisterAll(this);
}
```

### Alternative: Register every listener automatically

If you call `EventManager.RegisterAll(plugin)` and your plugin implements `EventListener`, RocketFlow will scan your plugin's assembly, find **every** class implementing `EventListener`, create an instance, and register all its handlers for you.

```csharp
protected override void Load()
{
    RocketFlow.Initialize();
    EventManager.RegisterAll(this); // finds all EventListener classes in the assembly
}
```

## 5. Understanding Priorities

The `[EventHandler]` attribute takes an optional `EEventPriority` value. Handlers run from highest priority to lowest. Handlers with the **same** priority run in registration order.

```csharp
[EventHandler(EEventPriority.HIGHEST)]  // runs first
public void First(PlayerChatEvent e) { }

[EventHandler]                          // default is NORMAL
public void Normal(PlayerChatEvent e) { }

[EventHandler(EEventPriority.LOWEST)]  // runs last
public void Last(PlayerChatEvent e) { }
```

Priorities at a glance:

| Priority | Value | When it runs |
|----------|-------|--------------|
| `HIGHEST`| 20    | First |
| `HIGH`   | 10    | Second |
| `NORMAL` | 0     | Middle (default) |
| `LOW`    | -10   | Second to last |
| `LOWEST` | -20   | Last |

## 6. Working with Cancellation

Many events implement `ICancellable`, which gives them an `IsCancelled` flag. You can set it to `true` to cancel the event.

There are two things to know:

1. **Lower-priority handlers are skipped.** Once a handler cancels an event, every remaining handler is skipped automatically.
2. **You can opt out.** Pass `ignoreCancelled: true` to `[EventHandler]` to have your handler run even if the event was already cancelled by someone else.

```csharp
[EventHandler(EEventPriority.HIGHEST)]
public void CancelDeath(PlayerChatEvent e)
{
    e.IsCancelled = true; // signals that the event was handled and modified
}

// This still runs even though the event was cancelled above,
// because ignoreCancelled is true.
[EventHandler(EEventPriority.LOWEST, ignoreCancelled: true)]
public void AlwaysRuns(PlayerChatEvent e)
{
    Logger.Log("Someone tried to chat.");
}
```

## 7. Unregistering Listeners

Clean up when your plugin unloads:

```csharp
protected override void Unload()
{
    EventManager.UnregisterAll(this);   // remove a specific listener
}
```

Other options:

| Method | What it removes |
|--------|-----------------|
| `EventManager.UnregisterAll(RocketPlugin plugin)` | All handlers registered from that plugin's assembly |
| `EventManager.UnregisterAll(object listener)` | Handlers belonging to one listener instance |
| `EventManager.UnregisterAssembly(Assembly assembly)` | All handlers from a specific assembly |

## What's Next?

- Browse the full list of events in the [Event Reference](events.md).
- See how the core classes work under the hood in the [API Reference](api-reference.md).
- Look at the working [`RocketFlow.Example`](../RocketFlow.Example) plugin.
