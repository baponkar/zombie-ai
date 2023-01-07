![Unity 2020 Badge](https://img.shields.io/badge/Unity-2020-blue)
![FPS](https://img.shields.io/badge/FPS-for%20Unity-blue)
![C#](https://img.shields.io/badge/C-%23-lightgrey)
![Issue](https://img.shields.io/github/issues/baponkar/zombie-ai)
![fork](https://img.shields.io/github/forks/baponkar/zombie-ai)
![star](https://img.shields.io/github/stars/baponkar/zombie-ai)
![License](https://img.shields.io/github/license/baponkar/zombie-ai)



# <span style="color:blue">Zombie AI for Unity Engine </span>.
A FSM and Behavior Tree based Zombie NPC Unity Project with a Demo Scene.See [Demo for 2.0.0](https://www.youtube.com/watch?v=JxbXT3MU_9M), [Demo for 1.0.0](https://www.youtube.com/watch?v=486w7NuyBWo).

It has roughly following Characteristics:

- [x] Zombie - Idle State.
- [x] Zombie - Chasing Player  State
- [x] Zombie - Patrolling State
- [x] Zombie - Attack State
- [x] Zombie - Flee State
- [x] Zombie  - Dead State
- [x] Zombie State - Waypoint based Patrolling. 
- [x] Zombie - Call Near NPC to attack Player
- [ ] ~State Control by Behavior Tree~
- [x] Statemachine[Both prefab have]
- [x] Zombie - Sound Sensor
- [x] Zombie - Vison Sensor
- [x] Sensor Memory for Target
- [x] FPS Player
- [x] A Demo Scene
- [x] Walking Audio 
- [x] Camera Shake

## ![ScreenShots0](ScreenShots/screenshot_with_weapon.png)
## ![ScreenShots1](ScreenShots/Screenshot1.png)
## ![ScreenShots1](ScreenShots/screenshot_with_multiple_zombie.png)

## Behavior Tree
## ![ScreenShots of behavior tree](ScreenShots/behavior_tree.png)
## ![ScreenShots of behavior tree](ScreenShots/Zombie_behavior_tree.png)


## Doc :
This is complete Unity Project if You download this project and open it then it will works perfectly.
If you use this project with your old project then first put 'Asset' folder in your project.
Zombie NPC is a navmesh agent which detect player by using vision sensor and sound sensor.

---
0. Add following layers in the following orders 
Layer 3 - Player,Layer 6-NPC,Layer 7-Sensor,Layer 8-Lighting,Layer 9-Ground,Layer 13-Character, Layer 14-Mini Map
1. NPC  : Change Default layer to NPC layer on Zombie Prefab.
 Change Tag NPC of Zombie Prefab.
2. Player : Change "Default" layer to "Character" layer on Player Prefab.
Change Tag of Player with "Player"
3. Ground : Change Default layer to Ground layer on Ground Plain or Terrain or like that envirionment object.
4. Change Vision Sensor(Which attached to the Zombie Prefab)'s target layer to 'Character'.
5. Change All Occulation layer of Vision Sensor(Which attached to the Zombie Prefab) to Default,Ground etc all occulation layer have in your scene.
6. Bake Navmesh with Humanoid Agent which should be in NavMeshAgent(Which attached to the Zombie Prefab).
7. Now put zombie prefab and player prefab in your scene.Player has attached a Health script which is damageable by Zombie.
8. Zombie also has attached a Health Script which can be damagable by external player which has a weapon which can be used to damage zombies health.
9. Change or tweak zombie behavior by setting up zombie config scriptable object.
10. To Change custom sensor detection layer edit 'NPCSensoryMemory.cs' file

## ![ScreenShots of behavior tree](ScreenShots/set_sensor_layer.png)

* This Project has a Demo Scene with necessary setup.
## License:
[GNU GPL v-3.0 License](LICENSE.md)

## Credits :
1. I have get ideas from  Youtuber 'Kiwi Coder's  tutorials
   [1](https://www.youtube.com/watch?v=znZXmmyBF-o&t=629s)
   [2](https://www.youtube.com/watch?v=1H9jrKyWKs0)

3. I have get ideas from  Youtuber ['Dev/GameDevelopment'](https://www.youtube.com/watch?v=UjkSFoLxesw&t=7s)s  tutorials

4. [Unity Learn - BehaviorTree](https://learn.unity.com/tutorial/introducing-behaviour-trees?uv=2020.2&projectId=60645258edbc2a001f5585aa)   
   
5. Sound Effect from <a href="https://pixabay.com/sound-effects/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=6419">Pixabay</a>

## Dependency
1. This Assets depend on ['Zombie assets by Pxltiger'](https://assetstore.unity.com/packages/3d/characters/humanoids/zombie-30232).
So You need to download this package from Unity assets store along with this Zombie_Enemy_AI assets.
2. [Standard-Assets-Characters](https://github.com/Unity-Technologies/Standard-Assets-Characters)
I am using Audio files for footstep sound.
3. [Rifle by Game-Ready Studios](https://assetstore.unity.com/packages/3d/props/guns/rifle-25668)
4. [Unity Simple FPS](https://github.com/baponkar/Unity-Simple-FPS) by me.
5. [My Behavior Tree](https://github.com/baponkar/My-Behavior-Tree) by me.
6. [Traffic-System](https://github.com/baponkar/Traffic-System-in-Unity) by me.
7. [Kiwi coder Behavior Tree](https://thekiwicoder.com/behaviour-tree-editor/) by Kiwi Coder.

* I have put all the above packages file and folder inside of this project.
## Unity Version
Unity 2020.3.15f2 or higher version.

## Contact
![Twitter](https://img.shields.io/twitter/follow/kar_bapon?style=social)
![Github](https://img.shields.io/github/followers/baponkar?style=social)
