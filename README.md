# Crossy Road - A Unity Project

## Project Group
Banana Lovers

## Project Members
Clarissa Roehrdanz, Jannik Recklies

## Overview

This project is a Unity-based implementation of the popular game "Crossy Road". The objective is to guide a character across a series of roads and obstacles without getting hit by vehicles or falling into water. The game combines elements of action, strategy, and timing, making it engaging and challenging.

## Chosen Platform
The project is developed using **Unity** for the following reasons:
- **Extensive Documentation and Community Support**: Unity has comprehensive documentation and a large community, making it easier to find solutions and support.
- **Cross-Platform Development**: Unity supports multiple platforms, allowing for easy deployment across different devices.
- **Powerful Features**: Unity offers a wide range of features and tools that simplify the development process, such as the Animator Controller for animations.

## Installation

1. **Download Unity Hub**: [Unity Hub](https://unity.com/download) is required to manage Unity installations and projects.

2. **Open Project in Unity**:
    - Open Unity Hub.
    - Click on "Add".
    - Navigate to the cloned repository folder and select it.

3. **Options to play the Game**:
- **Option 1 - Running in the Unity Editor**: Open the MainScene scene and click on the Play button in the Unity Editor.
- **Option 2 - Running pre-built application**: When using MacOS (tested on Apple Silicon) the game can also be started by running the pre-built Crossy_Road_MacOS.app
- **Option 3 - Building application**: Go to `File` > `Build Settings`, select `Scences/MainScene` and correct platform, then apply by clicking `Build and Run`

## How to Play
- **Movement**: Use WASD keys to move the character.
    - `W`: Move up.
    - `A`: Move left.
    - `S`: Move down.
    - `D`: Move right.
- **Objective**: Cross roads, rivers, and other obstacles to get as far as possible without getting hit.
- **Score**: The score increases with the distance covered.

## Project Structure
- **Assets/Scripts**: Contains all the C# scripts for game logic and mechanics.
    - **AudioManager.cs**: Manages audio playback for various game events.
    - **FollowPlayer.cs**: Controls the camera to follow the player's movement.
    - **GameEvents.cs**: Manages game events like player death.
    - **GameOverScreen.cs**: Manages the game over screen functionality.
    - **GameController.cs**: Manages the overall game logic and state.
    - **KillPlayerOnTouch.cs**: Handles the logic when the player collides with obstacles.
    - **MovingOject.cs**: Defines the behavior of moving objects like cars and logs.
    - **MovingOjectSpawner.cs**: Spawns moving objects at set intervals.
    - **PauseMenu.cs**: Manages the functionality of the pause menu.
    - **Player.cs**: Contains the player's movement and interaction logic.
    - **Sound.cs**: Represents individual sound effects.
    - **StartScreen.cs**: Manages the start screen functionality.
    - **TerrainData.cs**: Stores data related to terrain generation.
    - **TerrainGenerator.cs**: Generates the terrain and obstacles dynamically.
- **Assets/Prefabs**: Contains prefab objects like the player, vehicles, logs, and other obstacles.
- **Assets/Animations**: Contains Animator Controllers and animation clips.
- **Assets/Sounds**: Contains the sounds used for the game.
- **Assets/Scenes**: Contains the main scene (MainScene.unity) of the game.

## Key Scripts
**GameOverScreen.cs**
Handles the game over screen, showing the player's score and options to restart or quit the game.

**KillPlayerOnTouch.cs**
Destroys the player object upon collision with an obstacle and triggers the game over event.

**PlayerMovement.cs**
Controls the player's movement and rotation. Calls methods to move the player and handles input detection.

**TerrainGenerator.cs**
Generates terrain and obstacles dynamically as the player progresses through the game.

**GameEvents.cs**
Manages game events using C# events, such as player death, to decouple the game logic and improve maintainability.

## Future Improvements
- **Enhanced Graphics**: Add more detailed textures and models.
- **Power-Ups**: Introduce power-ups to provide temporary advantages to the player.
- **Multiplayer Mode**: Add a multiplayer mode for competitive gameplay.
- **Unique Design**: Develop a more unique visual style to differentiate from the original Crossy Road.

