# Netick IM Sample

This sample demonstrates on how to use Interest Management (using Area of Interest), with the usage of Sandboxing too.  
There are 2 Available Samples: 3D and 2D

![Preview](https://github.com/StinkySteak/netick-im-sample/blob/docs/overview.gif)

| Version | Release Date |
| :-------- | :------- 
| 0.1.0 | 02/11/2024  |

## Technical Info
- Unity: 2021.3.21f1
- Netick 2 Beta 0.12.50 [Pro]
- Platforms: PC (Windows)

## Highlights
- AoI (Broad Phase Filtering)
- A small usage of Narrow Phase Filtering
- Sandboxing compatible
- Late OnChanged Test

## How to Test?

### Controls
| Controls                	| Action      	|
|-------------------------	|-------------	|
| WASD                    	| Move        	|
| Q/E                     	| Rotate      	|
| Left/Right Mouse Button 	| Fly Up/Down 	|

### Setup
1. Enable Gizmos in the Game Window
1. Choose a scene to test (Game3D or Game2D)
1. Test Late OnChanged by clicking "Random Props Color" on IMGUI

### Multi-Sample Setup
- `GameStarterNetickConfig` is attached to the GameStarter, and it changed the Netick Config such as `PhysicsType` and the IM World size when `Start()` is called

### How to test Narrow Phase Filter
- Enable Props `NetworkObject` `NarrowPhaseFilter` in the inspector
- Click either "Set Interest to None" or "Set Interest to All" in the bottom right corner (Narrow Phase Filter only)