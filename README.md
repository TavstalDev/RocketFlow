# RocketFlow

![Release (latest by date)](https://img.shields.io/github/v/release/TavstalDev/RocketFlow?style=plastic-square)
![Workflow Status](https://img.shields.io/github/actions/workflow/status/TavstalDev/RocketFlow/release.yml?branch=stable&label=build&style=plastic-square)
![License](https://img.shields.io/github/license/TavstalDev/RocketFlow?style=plastic-square)
![Downloads](https://img.shields.io/github/downloads/TavstalDev/RocketFlow/total?style=plastic-square)
![Issues](https://img.shields.io/github/issues/TavstalDev/RocketFlow?style=plastic-square)

## What is RocketFlow?

RocketFlow is a lightweight [RocketMod](https://rocketmod.net/) library for [Unturned](https://unturned.fandom.com/wiki/Unturned) plugins. It gives you a clean, event-driven API with **precise event-listening prioritization**, so you have full control over the order in which your handlers run.

Instead of subscribing to RocketMod's raw events directly, you:

1. Mark your methods with the `[EventHandler]` attribute.
2. Register your class or plugin with `EventManager`.
3. RocketFlow does the rest - it listens to Unturned/RocketMod for you and fires your handlers in priority order.

RocketFlow ships with **90+ ready-made events** covering players, barricades, structures, vehicles, items, damage, the world, and more.

## Features

- **Priority-based execution** - control exactly when your handlers run with `LOWEST`, `LOW`, `NORMAL`, `HIGH`, and `HIGHEST` priorities.
- **90+ built-in events** - from player chat and damage to barricades, vehicles, and level loading.
- **Cancellation support** - many events implement `ICancellable`. Cancel them from any handler, and lower-priority handlers are skipped automatically.
- **Attribute-based setup** - no manual event wiring, no unsubscribe juggling.
- **Clean unregistration** - unregister a single listener, a whole plugin, or an entire assembly with one call.
- **Fast dispatch** - event invokers are compiled with expression trees, so the overhead is minimal.
- **Zero configuration** - one `Initialize()` call sets everything up.

## Requirements

- Unturned 3.24.x or later
- [RocketMod](https://rocketmod.net/) installed on the server
- .NET Framework 4.8

## Quick Start

```csharp
using Rocket.Core.Plugins;
using Tavstal.RocketFlow.Attributes;
using Tavstal.RocketFlow.Core;
using Tavstal.RocketFlow.Events.Player.Movement;

namespace MyPlugin
{
    public class Main : RocketPlugin, EventListener
    {
        protected override void Load()
        {
            RocketFlow.Initialize();
            EventManager.RegisterAll(this);
        }

        [EventHandler]
        public void OnPlayerMove(PlayerMoveEvent e)
        {
            Rocket.Core.Logging.Logger.Log($"{e.Player.CharacterName} moved to {e.Position}");
        }
    }
}
```

## Documentation

- [Getting Started](docs/getting-started.md) - requirements, installation, and your first event handler.
- [Event Reference](docs/events.md) - every event grouped by category, with descriptions and cancellation info.
- [API Reference](docs/api-reference.md) - the core classes and how they work.

## Building from Source

### Prerequisites

- .NET Framework 4.8 SDK / targeting pack

### Build Steps

1. Clone the repository:
   ```
   git clone https://github.com/TavstalDev/RocketFlow.git
   ```
2. Open `RocketFlow.sln` in your IDE.
3. Build the project:
   ```
   dotnet build -c Release
   ```
4. The compiled `RocketFlow.dll` will be in `RocketFlow/bin/Release/`.

## Example Plugin

A complete working example is included in the [`RocketFlow.Example`](RocketFlow.Example) project. Read its source alongside the [Getting Started](docs/getting-started.md) guide to see everything in action.

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more details.

## Contact

For issues or feature requests, please use the [GitHub issue tracker](https://github.com/TavstalDev/RocketFlow/issues).
