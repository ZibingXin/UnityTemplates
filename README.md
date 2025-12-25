# ZXTemplate (Unity)

A small Unity template for course projects: **Bootstrap + UI + Settings + Save + Progress**.

## Quick Start (3 steps)

### 1) Scenes
Add scenes to **Build Settings** in this order:
1. `Bootstrap`
2. `MainMenu`
3. `Game`

✅ Always press Play from **Bootstrap** scene.

---

### 2) Bootstrapper setup
In `Bootstrap` scene, create `@Bootstrap` and add:
- `Bootstrapper`
- (Optional) `SaveManagerRunner`
- `BootstrapEntry` (auto load MainMenu)

Assign in inspector:
- `UIRoot` prefab
- `GameInput` (InputActionAsset)
- `AudioMixer` + groups (BGM/SFX)
- `AudioLibrary` asset
- `ConfirmDialogWindow` prefab
- `ToastView` prefab

---

### 3) Scene installers
**MainMenu** scene:
- Add `MainMenuInstaller`
- Assign `MainMenuWindow` prefab

**Game** scene:
- Add `GameInstaller` (sets base input = Gameplay)
- Add `HUDInstaller` (shows HUD overlay)
- Add `PauseMenuController` (Esc toggles pause window)

---

## How to use (common tasks)

### Open a UI window (stack)
```csharp
ServiceContainer.Get<IUIService>().Push(settingsWindowPrefab);
```

### Close current window
```csharp
ServiceContainer.Get<IUIService>().Pop();
```

### Show HUD / Toast (overlay)
```csharp
var ui = ServiceContainer.Get<IUIService>();
ui.ShowOverlay("HUD", hudPrefab);
ui.ShowOverlay("Toast", toastViewPrefab);
```

### Load a scene with loading screen
```csharp
await ServiceContainer.Get<ISceneService>().LoadSceneAsync("Game");
```

---

## Settings

### AudioMixer parameters (required)
Expose these **Volume (Attenuation)** parameters in your AudioMixer:
- `Master`
- `BGM`
- `SFX`

### Apply / Cancel workflow
SettingsWindow uses snapshot:
- open → `ExportJsonSnapshot()`
- cancel → `ImportJsonSnapshot(snapshot, markDirty:false)`
- apply → `Save()`

### Controls rebinding
Rebind rows use:
- `actionPath` = `"Map/Action"` (e.g. `Gameplay/Jump`)
- rebinding supports **non-composite** bindings (Jump/Crouch/Interact).

---

## Save / Progress

- JSON files saved to `Application.persistentDataPath`
- Keys:
  - settings: `settings_main`
  - progress: `progress_main`

Progress includes:
- `coins`, `highScore`, `unlockedLevel`
- custom ints: `SetInt("key", value)` / `GetInt("key")`

---

## Naming conventions
- Persistent roots: `@Bootstrap`, `@Audio`
- Windows: `XxxWindow`
- Installers: `XxxInstaller`
- Services: `IXxxService` / `XxxService`
