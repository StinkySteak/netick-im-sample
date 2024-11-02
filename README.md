# Netick IM Sample

This sample demonstrates on how to use Interest Management (using Area of Interest), with the usage of Sandboxing too.

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

## Controls
| Controls                	| Action      	|
|-------------------------	|-------------	|
| WASD                    	| Move        	|
| Q/E                     	| Rotate      	|
| Left/Right Mouse Button 	| Fly Up/Down 	|

### How to test Narrow Phase Filter
- Enable Props `NetworkObject` `NarrowPhaseFilter` in the inspector
- Click either "Set Interest to None" or "Set Interest to All" in the bottom right corner (Narrow Phase Filter only)