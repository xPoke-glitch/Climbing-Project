# Climbing Project
[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=flat&logo=unity)](https://www.unity.com)

This is a **test project** where I tried to create a generic **climbing system** for a player

<img src="https://github.com/xPoke-glitch/ClimbingProject/blob/main/Screenshots/screen.png" width="750">

## The Game

Because it's a test project there is nothing much to do.

The player has the freedom of moving around on the test platform and climbing the test towers.

OH! and there is a random zombie in there so that you don't feel alone in the meantime.

## Requirements

If you only want to run the game and play:
* Windows 64bit

If you want to open, edit or see the Unity project:
* Unity 2020.3.26f1 (or greater)

## How to play

In order to play the game you have two options:
* Open the project with the recommended Unity version and play it from the game window
* Open the project with the recommended Unity version and build it for your platform

The commands are really simple:
* W/A/S/D: Move the player
* W/A/S/D + Left Shift: Run
* Walk/Run towards a big wall to automatically climb it
* Hold left click and move mouse to move the player's camera

## Gameplay example

This is an example that shows you how the game looks like. In this scene you can see how the climbing system works.

<img src="https://github.com/xPoke-glitch/ClimbingProject/blob/main/Screenshots/gameplay.gif" width="750">

## Test notes

The climbing system is working as expected. In order to achieve it I learnt how to properly set and use root motion animations, those are really helpful when it comes to climb the last part of the tower/wall. Of course there are many other way to achive a good climbing system.

There are few things that can be improved:
* the ground detection should be done with a boxcast instead of a single raycast
* when climbing the player sometimes is not directly facing the wall, so there is the opportunity to fix it - but there is already a minor fix for that in the code
* better animations

## Team

**Developers**:
* Cristian: https://github.com/xPoke-glitch / https://pokedev.itch.io/
