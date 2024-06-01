![Unity Badge](https://img.shields.io/badge/Unity-2020-maker?logo=unity)
![FPS](https://img.shields.io/badge/FPS-for%20Unity-blue)
![CSharp Badge](https://img.shields.io/badge/C%23-maker?logo=csharp)
[![Issue](https://img.shields.io/github/issues/baponkar/zombie-ai)](https://github.com/baponkar/zombie-ai/issues)
[![fork](https://img.shields.io/github/forks/baponkar/zombie-ai)](https://github.com/baponkar/zombie-ai/forks)
[![star](https://img.shields.io/github/stars/baponkar/zombie-ai)](https://github.com/baponkar/zombie-ai/stargazers)
[![License](https://img.shields.io/github/license/baponkar/zombie-ai)](https://github.com/baponkar/zombie-ai/blob/main/LICENSE.md)[![Wiki Badge](https://img.shields.io/badge/%F0%9F%93%96%20wiki-maker?style=flat-square&logo=pdf&labelColor=blue&color=blue)](https://github.com/baponkar/zombie-ai/blob/main/Assets/__baponkar__/Tutorials.pdf)
<a href="https://baponkar.github.io/zombie-ai">
 <img src="ScreenShots/share_icon.png" alt="Share icon" width="20" height="20">
</a>

<img src="ScreenShots/Social_pic.png" alt="Social Picture Banner" width="300" height="auto">

# Zombie NPC or Zombie AI for Unity Game Engine

* A Fully State Machine and ~Behavior Tree~  controlled advanced Zombie Non Playable Character(NPC) or AI for Unity Project with a Demo Scene.You can use this asset for your Game development.You can use the given states or introduced your own new state then you need to import the corresponding state animation and state transition logic. You also can use the zombie prefab for any kind mesh character by importing corresponding mesh and animation.


See following demo videos :
* [![YouTube demo Badge](https://img.shields.io/badge/youtube%20demo-2.0.0-maker?style=flat-square&logo=YouTube&logoColor=red&color=red)
](https://www.youtube.com/watch?v=JxbXT3MU_9M)

* [![YouTube demo Badge](https://img.shields.io/badge/youtube%20demo-1.0.0-maker?style=flat-square&logo=YouTube&logoColor=red&color=red)
](https://www.youtube.com/watch?v=486w7NuyBWo)

* ![Download Badge](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20download%20-latest-maker?style=flat-square&labelColor=red&color=blue&cacheSeconds=https%3A%2F%2Fgithub.com%2Fbaponkar%2Fzombie-ai%2Freleases%2Ftag%2Fv2.3.3)


Roughly It has following Characteristics:

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

## Screenshots:

<img src="ScreenShots/screenshot_with_weapon.png" alt="Screenshot 0" width="150" height="150"><img src="ScreenShots/Screenshot1.png" alt="Screenshot 1" width="150" height="150"><img src="ScreenShots/screenshot_with_multiple_zombie.png" alt="Screenshot 2" width="150" height="150"><img src="ScreenShots/screenshot_4.png" alt="Screenshot 2" width="150" height="150">



## [Flowchart of State Transition](https://colab.research.google.com/drive/14w90fm0O1CPNVTPYqNnic9xqHehyHnAs?usp=sharing)

<a href="https://colab.research.google.com/drive/14w90fm0O1CPNVTPYqNnic9xqHehyHnAs?usp=sharing">
<img src="ScreenShots/flowchart.png" alt="Flowchart of State transition" width="300" height="auto">
</a>

You can make your own custom transition then you need to update the state csharp script files according to your logic.

## Behavior Tree:
I have dropped this feature.
<img src="ScreenShots/behavior_tree.png" alt="Behavior Tree" width="300" height="auto">



## Documentation :

* You can see scene setup tutorial on [![Wiki Badge](https://img.shields.io/badge/Wiki-maker?logo=wiki)](https://github.com/baponkar/zombie-ai/blob/main/Assets/__baponkar__/Tutorials.pdf) or included PDF file.

* This is a complete Unity Project with included depending assets and also included a Demo Scene.

* If You download this project and  open it with Unity then it may works perfectly but sometimes may not works the way because of layers absence in the project then you need to add  corresponding layers and set by the below instruction.


* If you use this project with your old project then first put '_Zombie_ai_Fsm' folder in your project then create and add the layers in your project by below instruction.
Zombie NPC is a navmesh agent which detect player by using vision sensor and sound sensor.Vison Sensor have a sensory memory to memorize sense which can be set by config scriptable object.

* vison sensor can sense **Character** layers which is attached to the player prefab.

* The NPC Zombie have different inter related states you can manage those states by set up in config scriptable object found in the project.

* Project setup instructions:
---
1. Add following layers in the following orders 

- [x] Layer 3 - **Player**
- [x] Layer 6 - **NPC**
- [x] Layer 13 - **Character**
- [x] Layer 14 - **Mini Map**

2. NPC  : Change Default layer of  Zombie/Romero Prefab into **NPC**, and also
 Change Tag  of  Zombie/Romero Prefab into **NPC**.

3. Change Layer of **Player** into **Character** which will be seen by NPCs, and also
Change Tag of **Player** with "**Player**".

4. Change Layer of all prefabs **indicator plane** into "**Mini Map**" Layer.Which will be seen only by Mini Map Camera.

5. See **NPCVisionSensor** Script which attached with npcs i.e. zombie/Romero prefabs and change its **Occulation Layer** with corresponding
**Ground Layer** i.e. if ground plain be **Defult** then change into **Defult** Layer.

6. See NPCVisionSensor.cs Script which attached with npcs i.e. zombie/Romero prefabs and change its **Target Layer** into **Character** Layer which is the Layer of Player.So NPCs can see the player by vision sensor.


7. Bake Navmesh with Humanoid Agent which should be in NavMeshAgent(Which attached to the Zombie Prefab).

8. Now put zombie prefab and player prefab in your scene.Player has attached a Health script which is damageable by Zombie/Romero.

9. Zombie also has attached a Health Script which can be damagable by external player which has a weapon which can be used to damage zombies health.

10. Change or tweak zombie behavior by setting up zombie config scriptable object.

11. To Change custom sensor detection layer edit 'NPCSensoryMemory.cs' file

12. If you don't see the npcs then you need to add 'NPC' layer into the culling mask section of FPSCamera which have attached to theplayer prefab

## Zombie sensor sense *Character* Layer for this NPCSensoryMemory.cs Script.
Find **"NPCSensoryMemory.cs"** Script inside Scripts folder.
* Zombie_Ai
   * Assets
      - Zombie_ai
         - Zombie_NPC
            - Scripts
               -  NPCSensoryMemory.cs

```csharp
   ...
   public void UpdateSenses(NPCVisionSensor sensor)
   {
      int targets = sensor.Filter(characters, 'TargetLayer');
      //Here put the player layer name in 'TargetLayer'
      //Here I have use 'Character' as Player Object Layer is that.
      ....
   }
```

<img src="ScreenShots/set_sensor_layer.png" alt="Changing Target Layer" width="300" height="300">


* This Project has a Demo Scene with necessary setup.
## License:
* [GNU GPL v-3.0 License](LICENSE.md)
But you are requested to see the delendency assets licences.

## Credits 😊:
1. I have get ideas from  Youtuber 'Kiwi Coder's  tutorials
   [1](https://www.youtube.com/watch?v=znZXmmyBF-o&t=629s)
   [2](https://www.youtube.com/watch?v=1H9jrKyWKs0)

3. I have get ideas from  Youtuber ['Dev/GameDevelopment'](https://www.youtube.com/watch?v=UjkSFoLxesw&t=7s)s  tutorials

4. [Unity Learn - BehaviorTree](https://learn.unity.com/tutorial/introducing-behaviour-trees?uv=2020.2&projectId=60645258edbc2a001f5585aa)   
   
5. Sound Effect from <a href="https://pixabay.com/sound-effects/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=6419">Pixabay</a>

6. [Mixamo Character](https://www.mixamo.com)

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

## Contact:
![Gmail](https://img.shields.io/badge/Gmail-baponkar%40gmail.com-red?logo=gmail)
[![X](https://img.shields.io/badge/X-%40baponkar-maker?logo=x&logoColor=black&labelColor=red&color=black
)](https://x.com/kar_bapon)
[![LinkedIn](https://img.shields.io/badge/linkedin-%230077B5.svg?logo=linkedin&logoColor=white)](https://in.linkedin.com/in/bapon-kar-815098200)
[![YouTube](https://img.shields.io/badge/YouTube-%23FF0000.svg?logo=YouTube&logoColor=white)](https://youtube.com/@gamingjam8394?si=cElodqeKqe5PgX_o)

----
Copyright © [baponkar](https://github.com/baponkar) 2024



# Project Directory

- **src**
  - **components**
    - `Header.js`
    - `Footer.js`
  - **utils**
    - `helpers.js`
    - `api.js`
  - `index.js`
- **public**
  - `index.html`
  - `favicon.ico`
- **assets**
  - **images**
    - `logo.png`
    - `background.jpg`
  - **styles**
    - `main.css`
    - `theme.css`
- `package.json`
- `README.md`
