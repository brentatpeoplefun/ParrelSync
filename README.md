# ParrelSync - Forked version for personal control
[![Release](https://img.shields.io/github/v/release/VeriorPies/ParrelSync?include_prereleases)](https://github.com/VeriorPies/ParrelSync/releases) 
<br>

![ShortGif](https://raw.githubusercontent.com/VeriorPies/ParrelSync/master/Images/Showcase%201.gif)
<p align="center">
<b>Test project changes on clients and server within seconds - both in editor
</b>
<br>
</p>

## Features
1. Test multiplayer gameplay without building the project
2. GUI tools for managing all project clones
3. Protected assets from being modified by other clone instances
4. Handy APIs to speed up testing workflows
### UPM Package
Add the following to Package Manager via git url.
```
https://github.com/brentatpeoplefun/ParrelSync.git?path=/ParrelSync
```  

## Supported Platform
Currently, ParrelSync supports Windows, macOS and Linux editors.  

ParrelSync has been tested with the following Unity version. However, it should also work with other versions as well.
* *2020.3.1f1*
* *2019.3.0f6*
* *2018.4.22f1*

## APIs
There's some useful APIs for speeding up the multiplayer testing workflow.
Here's a basic example: 
```
if (ClonesManager.IsClone()) {
  // Automatically connect to local host if this is the clone editor
}else{
  // Automatically start server if this is the original editor
}
```
Check out [the doc](https://github.com/brentatpeoplefun/ParrelSync/wiki/List-of-APIs) to view the complete API list.

## How does it work?
For each clone instance, ParrelSync will make a copy of the original project folder and reference the ```Asset```, ```Packages``` and ```ProjectSettings``` folder back to the original project with [symbolic link](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/mklink). Other folders such as ```Library```, ```Temp```, and ```obj``` will remain independent for each clone project.

All clones are placed right next to the original project with suffix *```_clone_x```*, which will be something like this in the folder hierarchy. 
```
/ProjectName
/ProjectName_clone_0
/ProjectName_clone_1
...
```
## Discord Server
We have a [Discord server](https://discord.gg/TmQk2qG).

## Need Help?
Some common questions and troubleshooting can be found under the [Troubleshooting & FAQs](https://github.com/brentatpeoplefun/ParrelSync/wiki/Troubleshooting-&-FAQs) page.  
You can also [create a question post](https://github.com/brentatpeoplefun/ParrelSync/issues/new/choose), or ask on [Discord](https://discord.gg/TmQk2qG) if you prefer to have a real-time conversation.

## Support this project 
A star will be appreciated :)

## Credits
This project is originated from hwaet's [UnityProjectCloner](https://github.com/hwaet/UnityProjectCloner)
