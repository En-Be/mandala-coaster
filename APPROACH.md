# APPROACH

## Session 01

**To do**
- Set up repo
- Write spec
- Write starting user stories

**Done**
- Set up repo
- Write spec
- Write starting user stories

## Session 02

**25 July 2019 15:09:38 - 25 July 2019 15:37:02**

**To do**
- Set up unity project to deploy to phone as vr app
    - Generate ossig file
    - Test build
- Write first test


**Done**
- Generated ossig file and placed it in the new plugins directory
- Tried deploying but getting errors that I think are to do with the Unity version. Downloading the same one used on Hide and Go Beetroot.
- Read some documentation on testing in Unity

## Session 03

**25 July 2019 15:41:34 - Thu Jul 25 16:14:19 DST 2019**

**To do**
- Restart Unity project with different version
- Set up project as vr
- Deploy to headset

**Done**
- Restart Unity project with different version
- Got the same build error:
```
FormatException: Input string was not in a correct format....
```
- Googled it, recommended to update android sdk
- Working!
- touched a .gitignore file, because Unity makes alot of temp things I don't want to commit
- looked up how to add whole folders, hopefully it will work
- missed the library temp files, will have to add those to ignore and remove tracking
```
git rm -r --cached .
```
- committed sans temp files

## Session 04

**Thu Jul 25 16:37:55 DST 2019 - Thu Jul 25 17:56:46 DST 2019**

**To do**
- Change scene to no lighting
- Test camera is present
- Design document

**Done**
- Researching no lighting set up but no good results
- Removing any lighting settings I can find in the settings and scene
- Researched anisotropic texturing. Since I think I will just use flat material colours in this project, I'll disable it.
- Disabled shadows
- Added a grid as reference in the scene
- Built to test
- Resized grid items
- Installed Oculus integration package for in-editor playtesting
- That didn't have the editor emulator I expected, installed googleVR package instead
- Couldn't install only the parts I wanted without breaking dependencies, so going to try and do without.
- Deployed to test nothing broke
- Resized grid points again
- Enabled 2x antialiasing
- Deployed to judge grid