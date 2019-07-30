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

## Session 05

**Fri 26 Jul 2019 15:36:25 - Fri 26 Jul 2019 16:52:04**

**To do**
- Write and run a test in Unity

**Done**
- Wrote three tests in Play mode but they don't test the current scene
- Tried to find out why, went down a rabbit hole of Data Oriented Design

## Session 06

**28 July 2019 13:16:38 - 28 July 2019 13:46:21**

**To do**
- Edit spec to remove testing
- Design document
- First emitter

**Done**
- Removed testing
- Started a new scene
- Reimported googleVR package for editor emulator
- Added googleVR package to gitignore
- Created a navel, intended to be the main emitter of the mandala
- Calculates the angles between emissions on the navel

## Session 07

**28 July 2019 14:02:56 - Sun Jul 28 15:25:32**

**To do**
- First emitter
    - Add simple movement to point
    - Repeat emission at interval

**Done**
- Prefab emitted at interval angle
- Added simple movement to point
- Found workflow (not ideal) for making gifs on windows
- Found a better workflow (downloaded a screen to gif programme)

![wip001](./images/wip/001.gif)

## Session 08

**Sun Jul 28 20:25:32 - Sun Jul 28 21:07:42**

**To do**
- Simple motion of player through space
    - Add a script to move whichever way the camera is looking
    - Attach the navel to move with the gaze

**Done**
- Tried moving camera directly but had to attach it to a parent and move that
- Tried having the parent rotate with the child but that added them together into a spin
- Added the grid back for better spatial awareness
- Added adjustable speeds to the player, emitter, and points

![wip002](./images/wip/002.gif)

## Session 09

**Mon 29 Jul 2019 14:58:00 - Mon 29 Jul 2019 15:49:54**

**To do**
- Make grid created relative to player
- Make player look change move direction

**Done**
- Downloaded and imported the googleVR package  from
[googleVR](https://github.com/googlevr/gvr-unity-sdk/releases) since I excluded it from the repo.
- Made the camera copy the player location with a simple script
- Edited the googleVR script to let the camera move, by commenting out lines 219 and 234
- Made the player copy the camera rotation with a simple script
- The points do not inherit their initial layout rotation from the navel
- Hit a blocker on this, not sure how to more proceed. Tried inverting vector3.forward from world space to local but that didn't work.

## Session 10

**Mon 29 Jul 2019 16:05:14 - Mon 29 Jul 2019 17:21:06**

**To do**
- Look inside vector3.forward, see if I can recreate it relative to parent

**Done**
- Vector3.forward never changes, it's just a common vector. WRONG it doesn't change because the script is on a child, which stays at 0 rotation!
- Still not working. Tempted to roll back movement to always be in a straight line
- Finally fixed it. I was overwriting the rotation, rather than rotating.
- Changed the emission interval implementation
- Emission angles rotate around the center
- Realised can just turn off the copy rotation script on the player to make movement linear, if I want to at different times in the game.

![wip003](./images/wip/003.gif)

## Session 11

**Tue 30 Jul 2019 16:17:23 - Tue 30 Jul 2019 17:29:55**

**To do**
- Test leaving a trail instead of generating grid points
- Make a timer and visual indication of duration

**Done**
- Changed naming of point to particle
- Added a simple point prefab
- Added point emitter to navel
- Trying to update adb and android studio so I can deploy again
- Added gif to show previous session progress
- Trying Android File Transfer reinstall
- Trying android software update
- Trying Mac update
- Made a timer script
- Renamed navel to emitter
- Plan refactor of timings away from emitter to timer

![CRC](./planning/mandala-coaster-CRC.png)

## Session 12

**Tue 30 Jul 2019 18:14:14 - Tue 30 Jul 2019 19:31:57**

**To do**
- Refactor to timer
- Design document

**Done**
- Be annoyed at mac not recognising phone, even though adb lists it as a connected device
- Specified device in Unity build
- Deployed but not camera isn't moving with player, may have to go back to parenting it
- Remove points emission, looks crap when the camera doesn't move the emitter
- Added a coroutine to the particles to kill themselves after specified life in seconds
- Refactored to have a beats method on timer trigger the emissions on Emitter
- Simplified scene to remove anything related to the emitter rotating with player look

## Session 13

****

**To do**
- Design document
    - Visual indicator of time progress?
    - Split length into three sections (bars)
    - Collects each beat's emissions into array
    - Play with collections colours and speed
    - Emit from emissions