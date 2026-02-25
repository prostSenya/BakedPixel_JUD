# 🧩 Unity Inventory 

> Clean architecture--oriented Unity test project\
> Focused on scalability, maintainability, and proper separation of
> concerns.

------------------------------------------------------------------------

<img width="486" height="868" alt="image" src="https://github.com/user-attachments/assets/1282a57f-bdd7-4831-956d-f85357a4c2fe" />

------------------------------------------------------------------------

## 🚀 Overview

This project implements a modular **inventory system** built with
architectural clarity in mind.

The goal was not just to make it work, but to design a structure that
can scale and evolve cleanly over time.

------------------------------------------------------------------------

## 🏗 Architecture

The project is logically separated into layers:

### ⚙️ Infrastructure

-   Game State Machine
-   Scene Loading
-   Save/Load system
-   Application bootstrap

### 🎨 Presentation

-   UI
-   Presenters
-   Factories
-   Unity-specific bindings

------------------------------------------------------------------------

## 🧩 Patterns & Principles

-   State Machine
-   Factory Pattern
-   Dependency Injection (VContainer)
-   SOLID principles
-   ScriptableObject for static configuration

------------------------------------------------------------------------

## 🎒 Inventory System

-   Slot-based inventory structure\
-   Item configuration via ScriptableObject\
-   Clear separation between config data and runtime logic\
-   Easily extendable for new item types

------------------------------------------------------------------------

## 🔄 State Flow

BootstrapState\
↓\
LoadProgressState\
↓\
LoadSceneState\
↓\
GameplayState

Loads saved progress if available\
Creates new save if not\
Transitions to gameplay scene via state machine

------------------------------------------------------------------------

## 🛠 Tech Stack

-   Unity\
-   C#\
-   VContainer\
-   UniTask
-   ScriptableObject

