# Space Scrapper VR

## 🚀 Overview
Space Scrapper is a VR scavenger-loop experience where players explore, collect scrap, and maintain their ship. Originally inspired by the "Space Scrapper" tutorial by Valem, this repository serves as a modernized implementation built from the ground up for the latest Unity ecosystem.

## 🛠️ Technical Highlights
This project focuses on transitioning from "tutorial-level" code to a production-ready architecture by leveraging the latest features in Unity and XR Interaction Toolkit.

* Updated Game Engine: Utlizing the latest version of Unity 6000.0.35f1 newest tools and features.
* Modern Interaction Framework: Migrated from legacy Direct/Ray Interactors to the XRI 3.3.1 Near-Far Interactor system and Interaction Groups, providing a unified and more performant input handling logic.

## 📝 Roadmap
The following tasks are scheduled to further harden the project and align it with 2026 professional VR standards:

* Decoupled Gameplay Architecture: Replace legacy SendMessage patterns with a clean, Interface-based approach.
* Data-Driven Socket Filtering: Implemente a ScriptableObject-based "Key & Lock" system.
* Lifecycle-Safe Event Management: Utilized OnEnable and OnDisable for all XR Interaction events.
* Adaptive Probe Volumes (APV): Transition the manual "Light Probe Group" grid to Unity 6’s APV system for more accurate, automated lighting in interior spaces.
* XRI 3.4.0 Datum Migration: Refactor the current local affordances into a centralized Affordance Theme Datum (ScriptableObject) system for global audio/visual consistency.
* Modern Input Reader Pattern: Update SetTurnTypeFromPlayerPref.cs and locomotion controllers to use the new XRI Input Reader pattern, removing direct dependencies on Action Maps.
* State Machine for Mission Logic: Move the "Ship Repair" sequence from Timeline-based triggers to a robust State Machine to ensure the game data remains the "Source of Truth" during cutscenes.

## 🤝 Acknowledgments
Base Concept: Inspired by Valem's "Let's make a VR game".

Architectural Philosophy: Heavily influenced by the decoupled coding patterns found in CodeMonkey’s "Kitchen Chaos".

## ⚙️ Stack
* Engine: Unity 6.3 (6000.0.35f1)
* Toolkit: XR Interaction Toolkit 3.3.1
* Platform: Meta Quest 2 / 3 / Pro (OpenXR)
