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

**25 July 2019 15:41:34 - **

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