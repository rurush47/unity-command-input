# Unity Command Input

This is an implementation of the input with the usage of the command pattern. It features Undo and Redo commands. The input and actions are highly abstract, decoupled and customizable. The project utilizes scriptable objects which allows all actions to be drag-and-drop objects in the Unity Editor. All input bindings can be changed via the Editor and no additional scripting is required.

# Structure

## Input Controller
![alt-text](https://i.imgur.com/PZQl08T.png)
It is a scriptable object in which you can bind a key to a specific command.

## Input Command
A scriptable object which contains the logic of a command. It also has a reference to a Getter - another scriptable object that let you define how do you want to provide a command with data required by it.

## Context Getter
A scriptable object that contains the logic of how to grab the required data directly from the game. Input Command has a reference to it that can be drag-and-drop switched any time.

## Input Handler
A scriptable object that subscribes to Input Controller event and gets a command to execute from it. It also keeps track of input commands and handles Undo/Redo logic.

# Remarks
I recommend switching the type of the Input Actions drag-and-drop list to a serialized dictionary. As the Unity 2020 does not support this feature I have not included any plugins that support this feature in this project.
The approach taken in this project is similar to the one undertaken by the new Input System in unity. However, the new Input System does not support Undo/Redo out of the box. Unity's new Input System can be easily bound to this project. It would replace the Input Controller.
