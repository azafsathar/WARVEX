# 🎮 WARVEX

### Third-Person Shooter | Unity 6.6 | C#

**WARVEX** is an upcoming third-person shooter game developed with Unity 6.6 and C#. The project aims to deliver responsive character movement, tactical gunplay, challenging enemy AI, immersive 3D environments, and objective-driven missions.

The goal is to build a complete, playable shooter experience while exploring professional game development practices, gameplay programming, AI systems, animation, level design, and optimization.

> 🚧 **Project Status: In Development**
>
> WARVEX is an evolving project. Features described below represent the current development vision and roadmap; they should not be assumed to be implemented until documented as completed.

---

## 📌 About the Project

WARVEX is being developed as a PC-focused third-person shooter, initially targeting a single-player, offline experience.

The player will navigate hostile environments, engage enemies, complete mission objectives, and reach extraction points. Development will begin with a small playable prototype before expanding into a more complete game.

### 🎯 Project Goals

- Build a responsive third-person player controller.
- Develop satisfying aiming and shooting mechanics.
- Implement reusable weapon and damage systems.
- Create enemies with patrol, detection, and combat behaviors.
- Design engaging mission-based gameplay.
- Develop a functional HUD, menus, and gameplay feedback.
- Optimize the game for Windows PC.
- Deliver a standalone, playable game build.

---

## ✨ Planned Features

### 🧍 Player Controller
- Third-person character movement.
- Walking, running, sprinting, and jumping.
- Camera-relative movement and character rotation.
- Over-the-shoulder camera control.
- Aiming and movement animation integration.

### 🔫 Combat and Weapons
- Raycast-based shooting for initial firearms.
- Assault rifle and pistol.
- Ammunition, magazine capacity, and reloading.
- Weapon switching.
- Weapon recoil and firing effects.
- Hit detection, damage, and health systems.
- Combat audio and visual feedback.

### 🤖 Enemy AI
- NavMesh-based navigation.
- Patrol and player detection.
- Line-of-sight checks.
- Chasing and attacking.
- Enemy health and death behavior.
- Multiple enemy archetypes.
- Potential future improvements to cover usage and tactical behavior.

### 🗺️ Missions and Level Design
- Compact 3D combat environments.
- Mission objectives and progression.
- Enemy encounters and exploration.
- Extraction points.
- Mission success and failure conditions.
- Checkpoints and replayable missions.

### 🖥️ User Interface
- Player health and ammunition display.
- Crosshair and aiming feedback.
- Mission objective indicators.
- Main menu and pause menu.
- Game-over and mission-completion screens.
- Gameplay settings.

### ⚙️ Performance and Quality
- Windows standalone builds.
- Profiling and performance optimization.
- Graphics settings appropriate to the target hardware.
- Improved lighting, audio, materials, and visual effects.

*These features are planned; their implementation and final scope may change as development progresses.*

---

## 🛠️ Technology Stack

| Technology | Intended Use |
|---|---|
| Unity 6.6 | Game engine |
| C# | Gameplay programming |
| Universal Render Pipeline (URP) | Real-time rendering |
| Unity Input System | Keyboard, mouse, and potential controller support |
| Cinemachine | Third-person camera behavior |
| Animator / Mecanim | Character animation and state transitions |
| AI Navigation | NavMesh navigation for enemy AI |
| TextMeshPro | In-game text and user interface |
| Git and GitHub | Version control and project management |

*The listed packages and tools are part of the intended development setup and may be introduced as implementation progresses.*

---

## 🎮 Planned Controls

| Action | Keyboard / Mouse |
|---|---|
| Move | `W`, `A`, `S`, `D` |
| Look Around | Mouse |
| Aim | Right Mouse Button |
| Shoot | Left Mouse Button |
| Reload | `R` |
| Sprint | `Left Shift` |
| Jump | `Space` |
| Crouch | `C` |
| Interact | `E` |
| Switch Weapon | `Q` or Mouse Wheel |
| Pause | `Esc` |

*Controls are provisional and may change during development.*

---

## 🗺️ Development Roadmap

WARVEX will be developed incrementally, with each stage building on a working foundation.

- [x] **Phase 0:** Game concept and design document
- [x] **Phase 1:** Project setup and test environment
- [x] **Phase 2:** Player movement and third-person camera
- [ ] **Phase 3:** Shooting, weapons, ammunition, and damage
- [ ] **Phase 4:** Character animation and weapon handling
- [ ] **Phase 5:** Enemy AI and combat behavior
- [ ] **Phase 6:** Level design and mission objectives
- [ ] **Phase 7:** HUD, menus, audio, and visual feedback
- [ ] **Phase 8:** Gameplay completeness and usability
- [ ] **Phase 9:** Testing, bug fixing, and optimization
- [ ] **Phase 10:** Windows build and portfolio release

Progress will be reflected in this checklist as milestones are completed and tested.

---

## 📁 Intended Project Structure

The Unity project will be organized around reusable gameplay systems.

```text
Assets/
└── _WARVEX/
    ├── Art/
    │   ├── Characters/
    │   ├── Environment/
    │   └── Weapons/
    ├── Animations/
    ├── Audio/
    ├── Materials/
    ├── Prefabs/
    ├── Scenes/
    ├── Scripts/
    │   ├── Core/
    │   ├── Input/
    │   ├── Player/
    │   ├── Camera/
    │   ├── Combat/
    │   ├── Weapons/
    │   ├── AI/
    │   ├── Missions/
    │   ├── UI/
    │   └── Audio/
    ├── ScriptableObjects/
    ├── UI/
    └── VFX/
```

*This is the intended organization, not a claim that every directory currently exists.*

---

## 🚀 Getting Started

### Prerequisites

Before opening WARVEX, you will need:

- [Unity Hub](https://unity.com/download)
- Unity Editor **6.6**, using the version selected for this project
- A compatible Windows development environment
- Git for version control, if working with the repository through Git
- Windows Build Support in Unity Hub when building for Windows

### Open the Project

1. Clone or download this repository.
2. Open Unity Hub.
3. Select **Add** or **Add project from disk**.
4. Select the root folder containing the Unity project.
5. Open the project using the intended Unity Editor version.
6. Allow Unity to import the assets and packages.
7. Open the available test or gameplay scene to start development.

**Important:** A usable Unity project must contain the required project files, including `Assets/`, `Packages/`, and `ProjectSettings/`. A README-only repository is documentation rather than a complete playable project.

---

## 🧪 Testing and Development

During development, the game will be tested incrementally.

Testing priorities include:

- Player movement and camera collision.
- Weapon firing, ammunition, and reloading.
- Damage, health, and death behavior.
- Enemy navigation and target detection.
- Mission objectives and completion conditions.
- UI interaction and scene transitions.
- Performance and stability in standalone builds.

Features will be marked as complete only after they have been implemented and tested.

---

## 📸 Screenshots and Gameplay

Gameplay screenshots, prototype footage, and development updates will be added here as the project progresses.

*No screenshots are included yet. Add genuine WARVEX gameplay images when a suitable build is available.*

---

## 🔮 Future Possibilities

After the first playable mission is complete, potential expansions may include:

- Additional missions and environments.
- More weapons and enemy types.
- Improved enemy tactics and cover mechanics.
- Weapon pickups and customization.
- Higher-quality character animation and effects.
- Additional difficulty settings.
- Expanded controller support.

These are possibilities rather than confirmed release commitments.

---

## 📚 Learning and Development

WARVEX is also an opportunity to practice and demonstrate skills in:

- C# programming and object-oriented design.
- Unity gameplay systems.
- Character controllers and animation.
- Third-person camera implementation.
- Weapon systems and combat programming.
- AI navigation and finite-state machines.
- Level design and mission scripting.
- Debugging, profiling, and optimization.
- Git version control and project documentation.

The project will evolve through experimentation, testing, and continuous improvement.

---

## 📄 License and Third-Party Assets

A license has not yet been specified for this project. Until a license is added, do not assume that others have permission to redistribute or reuse the project's code or original assets.

Any third-party models, animations, audio, textures, fonts, or packages used in WARVEX must follow their respective licenses and attribution requirements. Asset credits will be documented as appropriate.

---

## 👨‍💻 Project Information

**Project Name:** WARVEX  
**Genre:** Third-Person Shooter  
**Engine:** Unity 6.6  
**Language:** C#  
**Initial Target Platform:** Windows PC  
**Development Status:** In Development

---

*WARVEX — Plan. Build. Fight. Evolve.*
