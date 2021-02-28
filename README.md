# Gorilla Cosmetics Unity Project

A unity project to create your own cosmetics for the [Gorilla Cosmetics](https://github.com/legoandmars/GorillaCosmetics) mod for Gorilla Tag.

## Usage
This project is made with Unity version 2019.3.15f. Higher or lower Unity versions may not work properly, so make sure to download it from the [Unity Archive](https://unity3d.com/get-unity/download/archive) if you don't have it already. It's recommended to use Unity Hub to make managing versions easier.

**Make sure to add android build support to your Unity 2019.3.15f!** This is needed to make sure your bundles properly support quest. Instructions can be found here: https://docs.unity3d.com/Manual/android-sdksetup.html

Once you've opened the unity project, open the sample scene located at `Scenes/SampleScene`

There should be a few examples of both materials and hats in the example scene.

## Materials
Making a material is relatively straightfoward. First, make a cube and put a custom material/shader on it. As long as the material works in Unity, it should work in-game, so go wild!

Once you've applied your custom material to the cube, add a `Gorilla Material Descriptor` component. This component has a couple fields, but they're pretty self-explanatory

* `Material Name` is what you want the material to be called in-game
* `Author Name` is what you want the author to be named - you can put your name there
* `Description` is a description you want shown ingame (currently unused, will be used when UI is added)
* `Custom Colors` is a checkbox that when enabled will change your material's _Color property to the gorilla's custom color
* `Disable Public Lobbies` is a checkbox that when enabled will force disable joining public lobbies in the future

After adding and filling out your descriptor, you can open the Material Exporter under `Window/Material Exporter` and export your material to the `Gorilla Tag/BepInEx/plugins/GorillaCosmetics/Materials` folder. Make sure it works in game by setting your material in the config, and you're all done! Feel free to join the [Modding Discord](https://discord.gg/PfVcua5Qaf) and share it.

## Hats
Making a hat is largely the same as making a material, but with a bit more trial and error to get the size right. 

Make an empty gameobject with everything set to 0 except for the Y position, which should be set to 1 to be right above the head template. This will be the parent GameObject for all the pieces of your hat. 

Make sure the scale/rotation of this GameObject never changes! It'll be automatically positioned and scaled, which could throw things off if your scale/rotation is set to anything besides 0.

Go ahead and put your hat model in this gameobject. Anything besides MonoBehaviours works, so feel free to use animations, fancy shaders, particles, etc. Make sure to position it so that it's right above the Hat Template cube, just sitting on top of it. 

NOTE: Make sure to remove all colliders! These can make the game behave weirdly!

Once your model is done, add a `Hat Descriptor` component. This component is very similar to the material descriptor, and most fields are self-explanatory.

* `Hat Name` is what you want the hat to be called in-game
* `Author Name` is what you want the author to be named - you can put your name there
* `Description` is a description you want shown ingame (currently unused, will be used when UI is added)
* `Custom Colors` is a checkbox that when enabled will change the _Color property of all objects in your hat to the gorilla's custom color
* `Disable Public Lobbies` is a checkbox that when enabled will force disable joining public lobbies in the future

After adding and filling out your descriptor, you can open the Hat Exporter under `Window/Hat Exporter` and export your hat to the `Gorilla Tag/BepInEx/plugins/GorillaCosmetics/Hats` folder. Make sure it works in game by setting your hat in the config, and you're all done! Remember that hats can take a bit more trial and error to position/scale right, so keep adjusting it slightly until it looks really nice on your gorilla. Once you're done, feel free to join the [Modding Discord](https://discord.gg/PfVcua5Qaf) and share it.