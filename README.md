## How to Open and Run

### Unity Version

This project was developed using:

- Unity 6000.3.8f1

### Running the Project

1. Open the project in Unity Hub using Unity 6000.3.8f1.
2. Open the main scene:
   `Assets/Scenes/ColonySurvival.unity`
3. Press **Play** in the Unity Editor.

The simulation starts automatically when the scene runs.

The simulation uses an accelerated clock where **1 real second equals 1 game day**.

The UI displays the current food, water, days remaining, game-day counter, and colony status. When either food or water reaches zero, the colony enters the **COLONY STARVING** state.

---

## Running Unit Tests

The project uses Unity's EditMode Test Runner.

To run the tests:

1. Open the project in Unity.
2. Go to **Window → General → Test Runner**.
3. Select **EditMode**.
4. Click **Run All**.

The current test suite contains six tests covering:

- Initial simulation values
- Food and water consumption
- Resource clamping at zero
- Starvation detection
- Days-remaining calculations
- Zero-consumption behavior

All six tests currently pass.

## Demo

The demo shows the scene running with:

- Food and water reserves depleting
- Days remaining ticking down
- The game-day counter advancing
- The **COLONY STARVING** state triggering

[Watch the 30-second demo](https://drive.google.com/drive/folders/1SnMnlQLTcr05MQcvIDglAev_DLG9SbDU?usp=drive_link)

---

## AI Tools Used

I used **ChatGPT** during development for architecture discussions, code review, debugging, and unit-test design.

The AI was mainly used to discuss approaches, identify issues, and suggest implementations. I wrote, integrated, and tested the project in Unity, and adapted the suggestions to the project's requirements.

The final implementation was manually tested in Unity, including the simulation, UI, JSON loading, and unit tests.

---

## Decisions & Trade-offs

### Pure C# Simulation

The simulation logic was kept in a plain C# class instead of a `MonoBehaviour`. This keeps the simulation independent from Unity and allows it to be tested through EditMode tests.

### JSON Configuration

Population, starting reserves, and consumption rates are stored in JSON configuration files rather than being hardcoded into the simulation.

### Generic JSON Loader

A generic JSON loader was used so the same loading method can deserialize both configuration types instead of creating separate loading methods for each file.

### Accelerated Time

The simulation uses **1 real second = 1 game day** so that resource consumption and starvation can be observed quickly during the demonstration.

### Simple UI

The UI was intentionally kept simple using standard Unity UI components. No custom art, animations, sound, or additional gameplay systems were added because they were outside the scope of the task.

### Zero Consumption

When a resource has zero daily consumption, its remaining days are treated as positive infinity because the resource will not be depleted through consumption.
