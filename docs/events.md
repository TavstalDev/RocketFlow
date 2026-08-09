# Event Reference

RocketFlow comes with **112 events** covering most things that happen on an Unturned server. All events inherit from `Tavstal.RocketFlow.Core.Event` (which exposes a `FiredAtUtc` timestamp) and live under the `Tavstal.RocketFlow.Events` namespace.

## Reading the Tables

| Column | Meaning |
|--------|---------|
| **Event** | The class you receive in your handler. |
| **Description** | When the event fires and what you can do with it. |
| **ICancellable** | Whether the event implements `ICancellable` (and therefore carries an `IsCancelled` handled signal). |

> **Handled signal, not a block.** On an `ICancellable` event, `IsCancelled` does **not** prevent the action. It signals to other listeners that the event was **handled and modified** — once set, the remaining (lower-priority) handlers are skipped unless they opt in with `ignoreCancelled: true`.
>
> **How you actually control the game.** Each cancellable event also exposes a dedicated control property that is fed back to Unturned — `ShouldAllow`, `Cancel`, `Allow`, `IsAllowed`, `CancelLoading`, `ShouldVanillaBan`, and so on. Set those to allow, block, or change the outcome. The descriptions below name the exact property per event.
---

## Player Events

`Tavstal.RocketFlow.Events.Player`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `PlayerChatEvent` | A player sent a chat message. Change `Color`, or set `Cancel = true` to block it. | Yes |
| `PlayerConnectEvent` | A player finished connecting and joined the game. | No |
| `PlayerDamagedEvent` | A player took damage. Modify the damage details, or set `CanDamage = false` to block it. | Yes |
| `PlayerDeadzoneUpdatedEvent` | A player's deadzone status changed (entered or left a radiation zone). | No |
| `PlayerDisconnectEvent` | A player disconnected from the server. | No |
| `PlayerPreConnectEvent` | A player is about to connect (before `PlayerConnectEvent`). | No |
| `PlayerSafezoneUpdatedEvent` | A player entered or left a safezone. | No |
| `PlayerVisionUpdatedEvent` | A player's vision (map/UI) mode changed. | No |

## Player Inventory Events

`Tavstal.RocketFlow.Events.Player.Inventory`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `PlayerInventoryAddEvent` | An item was added to a player's inventory. | No |
| `PlayerInventoryEvent` | A player's inventory slot was updated (general update). | No |
| `PlayerInventoryRemoveEvent` | An item was removed from a player's inventory. | No |
| `PlayerInventoryResizeEvent` | A player's inventory page was resized. | No |
| `PlayerWearEvent` | A player equipped or unequipped a wearable item. | No |
| `PlayerEquipEvent` | A player is equipping an item. Set `ShouldAllow = false` to block it. | Yes |
| `PlayerDequipEvent` | A player is unequipping an item. Set `ShouldAllow = false` to block it. | Yes |
| `PlayerInventoryDropEvent` | A player is dropping an item. Set `ShouldAllow = false` to block the drop. | No |
| `PlayerInventoryStateUpdatedEvent` | A player's inventory state was updated. | No |
| `PlayerInventoryStoredEvent` | A player's inventory was stored (data sync). | No |
| `PlayerHatUpdatedEvent` | A player's hat item changed. Includes the new id, quality, and state. | No |
| `PlayerShirtUpdatedEvent` | A player's shirt item changed. Includes the new id, quality, and state. | No |
| `PlayerPantsUpdatedEvent` | A player's pants item changed. Includes the new id, quality, and state. | No |
| `PlayerVestUpdatedEvent` | A player's vest item changed. Includes the new id, quality, and state. | No |
| `PlayerBackpackUpdatedEvent` | A player's backpack item changed. Includes the new id, quality, and state. | No |
| `PlayerGlassesUpdatedEvent` | A player's glasses item changed. Includes the new id, quality, and state. | No |
| `PlayerMaskUpdatedEvent` | A player's mask item changed. Includes the new id, quality, and state. | No |

## Player Life Events

`Tavstal.RocketFlow.Events.Player.Life`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `PlayerBleedingEvent` | A player's bleeding state changed. | No |
| `PlayerBonesEvent` | A player's broken-bone state changed. | No |
| `PlayerDeadEvent` | A player became dead (the dead state, includes death position). | No |
| `PlayerDeathEvent` | A player died. Includes the cause, limb, and murderer. | No |
| `PlayerFoodEvent` | A player's food level changed. | No |
| `PlayerHealthEvent` | A player's health changed. | No |
| `PlayerLifeDamagedEvent` | A player's life was damaged (informational damage update). | No |
| `PlayerLifeStateEvent` | A player's alive/dead state changed. | No |
| `PlayerLifeUpdatedEvent` | A player's life values were updated in general. | No |
| `PlayerOxygenEvent` | A player's oxygen level changed. | No |
| `PlayerReviveEvent` | A player was revived. Includes the revive position and angle. | No |
| `PlayerStaminaEvent` | A player's stamina level changed. | No |
| `PlayerTemperatureUpdatedEvent` | A player's temperature state changed. | No |
| `PlayerVirusEvent` | A player's virus (infection) level changed. | No |
| `PlayerWaterEvent` | A player's water level changed. | No |

## Player Movement Events

`Tavstal.RocketFlow.Events.Player.Movement`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `PlayerGestureEvent` | A player performed a gesture (point, surrender, etc.). | No |
| `PlayerMoveEvent` | A player's position updated. Includes the new position. | No |
| `PlayerStanceEvent` | A player's stance changed (prone, crouch, stand, etc.). | No |
| `PlayerLandedEvent` | A player landed after falling. Includes the impact velocity. | No |
| `PlayerSeatedEvent` | A player sat down or stood up in a vehicle. Includes the old/new vehicle and seat role. | No |

## Player Stat Events

`Tavstal.RocketFlow.Events.Player.Stat`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `PlayerBoostUpdatedEvent` | A player's boost (e.g. dash) state changed. | No |
| `PlayerExperienceEvent` | A player's experience points changed. | No |
| `PlayerReputationUpdatedEvent` | A player's reputation value changed. | No |
| `PlayerSkillsUpdatedEvent` | A player's skills were updated. | No |
| `PlayerStatEvent` | One of a player's stats was updated. Includes which stat. | No |

## Player Vehicle Events

`Tavstal.RocketFlow.Events.Player.Vehicle`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `PlayerVehicleUpdatedEvent` | A player's current vehicle stats updated (fuel, speed, health, battery). | No |

---

## Effect Events

`Tavstal.RocketFlow.Events.Effect`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `EffectButtonEvent` | A player clicked a button in an effect UI. Includes the button's name. | Yes |
| `EffectTextEvent` | A player committed text in an effect input box. Includes the button's name and the entered `Text`. | Yes |

---

## Barricade Events

`Tavstal.RocketFlow.Events.Barricade`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `BarricadeDamageEvent` | A barricade is taking damage. Adjust the damage, or set `ShouldAllow = false` to block it. | Yes |
| `BarricadeDeployEvent` | A player is deploying a barricade. Adjust the placement details, or set `ShouldAllow = false` to block. | Yes |
| `BarricadeRepairEvent` | A barricade is being repaired. Adjust the healing, or set `ShouldAllow = false` to block. | Yes |
| `BarricadeRepairedEvent` | A barricade finished being repaired. | No |
| `BarricadeSalvageEvent` | A player is salvaging a barricade. Set `ShouldAllow = false` to block it. | Yes |
| `BarricadeSignModifyEvent` | A player is editing a sign. Change the text, or set `ShouldAllow = false` to block. | Yes |
| `BarricadeSpawnedEvent` | A barricade was spawned into the world. | No |
| `BarricadeStorageOpenEvent` | A player is opening a barricade's storage. Set `ShouldAllow = false` to block it. | Yes |
| `BarricadeTransformEvent` | A barricade is being moved/replaced. Adjust the placement, or set `ShouldAllow = false` to block. | Yes |

---

## Structure Events

`Tavstal.RocketFlow.Events.Structure`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `StructureDamageEvent` | A structure is taking damage. Adjust the damage, or set `ShouldAllow = false` to block it. | Yes |
| `StructureDeployEvent` | A player is deploying a structure. Adjust the placement details, or set `ShouldAllow = false` to block. | Yes |
| `StructureRepairEvent` | A structure is being repaired. Adjust the healing, or set `ShouldAllow = false` to block. | Yes |
| `StructureRepairedEvent` | A structure finished being repaired. | No |
| `StructureSalvageEvent` | A player is salvaging a structure. Set `ShouldAllow = false` to block it. | Yes |
| `StructureSpawnedEvent` | A structure was spawned into the world. | No |
| `StructureTransformEvent` | A structure is being moved/replaced. Adjust the placement, or set `ShouldAllow = false` to block. | Yes |

---

## Vehicle Events

`Tavstal.RocketFlow.Events.Vehicle`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `VehicleCarjackEvent` | A player is breaking into a locked vehicle. Adjust the force/torque, or set `Allow = false` to block. | Yes |
| `VehicleDamageEvent` | A vehicle is taking damage. Adjust the damage or `CanRepair`, or set `ShouldAllow = false` to block. | Yes |
| `VehicleEnterEvent` | A player is entering a vehicle. Set `ShouldAllow = false` to block the entry. | Yes |
| `VehicleExitEvent` | A player is exiting a vehicle. Adjust where they exit, or set `ShouldAllow = false` to block. | Yes |
| `VehicleExplodeEvent` | A vehicle exploded. | No |
| `VehicleLockEvent` | A vehicle's lock is being toggled (locked or unlocked). Set `ShouldAllow = false` to block. | Yes |
| `VehicleLockedEvent` | A vehicle's lock was toggled. | No |
| `VehicleLockpickEvent` | A player is lockpicking a vehicle. Set `Allow = false` to block it. | Yes |
| `VehiclePreDestroyEvent` | A vehicle is about to be destroyed (before actual destruction). | No |
| `VehicleRepairEvent` | A vehicle is being repaired. Adjust the healing, or set `ShouldAllow = false` to block. | Yes |
| `VehicleSiphonEvent` | A player is siphoning fuel from a vehicle. Adjust `DesiredAmount`, or set `ShouldAllow = false` to block. | Yes |
| `VehicleSwapSeatEvent` | A player is switching seats in a vehicle. Adjust the target seat, or set `ShouldAllow = false` to block. | Yes |
| `VehicleTireDamageEvent` | One of a vehicle's tires is taking damage. Set `ShouldAllow = false` to block it. | Yes |

---

## Damage Events

`Tavstal.RocketFlow.Events.Damage`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `AnimalDamageEvent` | An animal is taking damage. Adjust the damage, or set `ShouldAllow = false` to block it. | Yes |
| `PlayerAllowedToDamagePlayerEvent` | Checks whether one player may damage another. Adjust `IsAllowed` to allow/block. | Yes |
| `PlayerDamageEvent` | A player is taking damage. Adjust the damage, or set `ShouldAllow = false` to block it. | Yes |
| `ZombieDamageEvent` | A zombie is taking damage. Adjust the damage, or set `ShouldAllow = false` to block it. | Yes |

---

## Item Events

`Tavstal.RocketFlow.Events.Item`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `EquipmentPunchEvent` | A player punched with an equipment item. Includes the punch mode. | No |
| `EquipmentUseableChangedEvent` | A player's equipped usable item changed. | No |
| `ItemConsumeEvent` | A player is about to consume an item. Set `ShouldAllow = false` to block it. | Yes |
| `ItemConsumedEvent` | A player consumed an item. | No |
| `ItemDropAddedEvent` | An item drop was added to the world. | No |
| `ItemDropRemovedEvent` | An item drop was removed from the world. | No |
| `ItemDropSpawningEvent` | An item drop is spawning. Adjust its location, or set `ShouldAllow = false` to block. | Yes |
| `ItemTakeEvent` | A player is taking an item from a container/inventory. Set `ShouldAllow = false` to block it. | Yes |

---

## Level Events

`Tavstal.RocketFlow.Events.Level`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `LevelExitEvent` | The server is leaving the current level. | No |
| `LevelLoadedEvent` | A level finished loading. Includes the level index. | No |
| `LevelPostLoadEvent` | Runs after a level is fully loaded. | No |
| `LevelPreLoadEvent` | Runs before a level starts loading. | No |
| `LevelPrePreLoadEvent` | Runs even earlier, before the level loading begins. | No |
| `LevelRefreshEvent` | The level is being refreshed. | No |
| `LevelSatellitePostCaptureEvent` | The level satellite image finished capturing. | No |
| `LevelSatellitePreCaptureEvent` | The level satellite image is about to be captured. | No |

---

## World Events

`Tavstal.RocketFlow.Events.World`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `WorldHarvestEvent` | A player is harvesting a farm plant. Set `ShouldAllow = false` to block it. | Yes |
| `WorldObjectDamageEvent` | A world object is taking damage. Adjust the damage, or set `ShouldAllow = false` to block. | Yes |
| `WorldResourceDamageEvent` | A resource node (trees, rocks, etc.) is taking damage. Adjust the damage, or set `ShouldAllow = false` to block. | Yes |

---

## Zombie Events

`Tavstal.RocketFlow.Events.Zombie`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `ZombieWaveEvent` | A new zombie wave is ready. Includes the wave index. | No |

---

## Crafting Events

`Tavstal.RocketFlow.Events.Crafting`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `CraftBlueprintEvent` | A player is crafting a blueprint. Set `ShouldAllow = false` to block the craft. | Yes |

---

## Plugin Events

`Tavstal.RocketFlow.Events.Plugin`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `PluginLoadingEvent` | A RocketMod plugin is loading. Set `CancelLoading = true` to stop it. | Yes |
| `PluginUnloadingEvent` | A RocketMod plugin is unloading. | No |

---

## Provider Events

`Tavstal.RocketFlow.Events.Provider`

| Event | Description | ICancellable |
|-------|-------------|--------------|
| `ProviderBanEvent` | A player is being banned. Adjust `Reason`/`Duration`, or set `ShouldVanillaBan = false` to skip the vanilla ban. | Yes |
| `ProviderShutdownEvent` | The server provider is shutting down. | No |
| `ProviderUnbanEvent` | A player is being unbanned. Set `ShouldVanillaUnban = false` to skip the vanilla unban. | Yes |

---

## Did We Miss Something?

If there's an Unturned or RocketMod event you'd like RocketFlow to wrap, open an [issue](https://github.com/TavstalDev/RocketFlow/issues) — event wrappers are intentionally small and easy to add.
