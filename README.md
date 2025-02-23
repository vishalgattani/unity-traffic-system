# Unity Traffic System

I am learning Game Development and this is a Unity project that simulates traffic flow in a city. It uses the Unity physics engine to simulate the movement of vehicles and pedestrians. The simulation is based on the concept of waypoints, which are used to define the path of vehicles and pedestrians. The waypoints are arranged in a hierarchical structure, with each waypoint having a parent and child waypoints. This allows for the creation of complex traffic flow patterns, such as loops and forks.

The simulation also includes a waypoint manager tool, which allows for the creation and management of waypoints in the scene. This tool is useful for creating and editing the traffic flow patterns in the city.

## Unity Concepts

### [Animator](https://docs.unity3d.com/ScriptReference/Animator.html)

The Unity's built-in Animator component and the Animator controller are used to control the animation transitions of the pedestrians. The animator component has the controller property which is used to assign the Animator controller to itself. The animator's grid pane serves as an interface to create, modify and connect animation states. You may have seen a non-player character in many games such as Grand Theft Auto or Assassin's Creed. In these games, the non-player character (NPC) is controlled by an animator. As these NPCs move around the game world, they use animations to perform various actions such as walking, talking or perform other actions such as waving and sitting down for a time period. All these character animations follow state transitions which are defined in the animator's controller.

There are different ways of transitioning between animation states using the animator by using boolean, integer, float and trigger conditions. 

Considering the boolean parameter, let's assume that the NPC has two states: `Walking` and `Idle`. The initial state of the NPC is `Idle`. If the boolean parameter is set to true, the NPC will transition to the `Walking` state. If the boolean parameter is set to false, the NPC will transition to the `Idle` state. This is a simple example of a boolean transition. However, in real-world scenarios, NPCs may have more complex animation transitions. For example, the NPC may have a walking animation state that transitions to a running animation state based on a certain condition. This can also be achieved by using two boolean parameters. Let's say the NPC is in a walking state by pressing a key which sets the boolean `Walking` parameter is set to true. Let's say we press, another button that allows the NPC to transition to the running state. If the user stops either of the keys to make the NPC move forward or run, then the state is changed to the `Idle` state. To make the transitions from walking to running seamless, we can use a blend tree. 

<video src="https://github.com/user-attachments/assets/19538267-e845-446d-9949-5fb58b3a29d3" controls="controls" style="max-width: 1024px;"></video>

### Blend Trees

Also, the animator has a blend tree feature which allows for more complex animation transitions. A blend tree is a graphical representation of an animation transition by allowing us to add another parameter to control the blending between two animation states. For example, if we want to blend between the walking and running animation states, we can add a parameter called `Velocity` which corresponds to the speed of the NPC. As this speed increases, the blend tree can be configured to swicth to the running animation state as the value of the `Velocity` parameter increases.

The blend tree feature of the animator is used to dynamically blend multiple animations together. This results in a dynamic animation that scales between the multiple animation states. The blending can depend on multiple values. For example, we can have a blend tree that transitions between two animation states based on the value of the `Velocity` parameter. If the velocity is low, the animation will transition to the walking animation state. If the velocity is high, the animation will transition to the running animation state. And if the velocity is less than a certain small value, the animation will transition to the idle animation state. You can have blend trees within blend trees to create even more complex animation transitions.

# Steps

- Create an animator controller
- Create a character controller
- Create a waypoint manager
- Create waypoints
- Add (brainless) pedestrians
- Assign the start waypoint in a randomized fashion to randomized number of pedestrians
- Assign a randomized direction to the pedestrians
- Assign a randomized speed to the pedestrians
- Assign a randomized destination to the pedestrians
- Assign a randomized rotation speed to the pedestrians incase they collide (which they will, I have not added brains to the NPCs)
- Assign a randomized movement speed to the pedestrians
- Assign a randomized stop distance to the pedestrians
- Assign a randomized branch ratio to the waypoints

## Results

<video src="https://github.com/user-attachments/assets/0f30b3c4-7ac8-4926-9239-116b28be72d9" controls="controls" style="max-width: 1024px;"></video>

## Contributing

Contributions are welcome! If you find any bugs or have suggestions for improvements, please open an issue or submit a pull request.

## References

1. [Game Dev Guide - Building a Traffic system](https://www.youtube.com/watch?v=MXCZ-n5VyJc&t=107s)
2. [iHeartGameDev](https://www.youtube.com/@iHeartGameDev)
    - [How to Animate Characters in Unity 3D | Importing Free Characters and Animations from Mixamo](https://www.youtube.com/watch?v=vApG8aYD5aI&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO&index=3)
    - [How to Animate Characters in Unity 3D | Animator Explained](https://www.youtube.com/watch?v=vApG8aYD5aI&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO&index=3)
    - [How to Animate Characters in Unity 3D | Animation Transitions With Booleans](https://www.youtube.com/watch?v=FF6kezDQZ7s&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO&index=4)
    - [How to Animate Characters in Unity 3D | Blend Trees Explained: One Dimensional](https://www.youtube.com/watch?v=m8rGyoStfgQ&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO&index=5)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
