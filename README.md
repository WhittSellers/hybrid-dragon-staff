# hybrid-dragon-staff
Unity Visual Effects project that uses SteamVR hardware tracking data and a Dragon Staff to drive interactive visual effects.

![CelestialBodies](https://user-images.githubusercontent.com/44481407/172655543-b405bd81-6674-439e-99c1-094ecf4ceff9.jpg)

This project was created to drive the visuals for my Parsons Design & Technology MFA Thesis Embers, performed live on May 16th, 2022 at Kellen Auditorium and set up as an interactive installation on May 17th, 2022.

![EmbersHero00](https://user-images.githubusercontent.com/44481407/172657362-540a57eb-39ae-4224-8f07-81be6ebb2471.jpg)

This Unity project is comprised of a mountain forest scene that I created with terrain tools and MTree plugin, a library of fire/embers inspired VFX and some other other fun ones, and a cinemachine environment with multiple camera position that can be controlled dynamically. There is also included functionality for audio reactivity to be incorporated into VFX or controlling other visuals and midi/osc control using Keijiro Takahashi's LASP and Minis plugins respectively, and has a few other other of his plugins that aren't currently being used.

![UnityVFXScreenShot](https://user-images.githubusercontent.com/44481407/172657795-d45dd8b2-8659-4471-850b-893800989e80.jpg)

It is designed to be used with any SteamVR compatible tracker, like Vive or Tundra trackers, attached to the end of a dragon staff flow toy. For my performance I designed and 3d printed a bracket plate for a tundra tracker to keep it securelly attached. It currently uses OpenXR + an unofficial script to integrate VR Trackers to handle VR functionality, but previous versions were built with OpenVR. It could still be rolled back to that, but you will need to download the openvr plugin from valve and modify the manifest file of this project to tell it where to look for the plugin locally.

![TundraTrackerBase](https://user-images.githubusercontent.com/44481407/172661574-20d78b59-abba-4fd8-8778-3919c6018239.jpg)


There are two main scenes in the project- Embers and Inferno.

Embers Scene-
This scene runs off of an animation timeline that triggers the beginning of the performance and activates/deactivates effects, switches camera angles, and adjusts paramenters at set times to align with a choreographed performance where the camera view is projected behind the performer. The animation calls methods in the Show Control script, where each method fires off a number of different events that a camera manager, different vfx components, and audio players are listening for. This is done to centralize where things are getting adjusted while still keeping them independent of one another, and to leave the underlying system open to midi or OSC input in the future.

Inferno Scene-
This scene is largely identical, but does not run off of an animation timeline and is designed to be used for interactive installations or improvised/free-style performances, as well as for live viewing in VR. Currently still needs some more work to be totally controlled by a midi/osc interface. It also includes more functionality for the dragon staff spinner to trigger effects using colliders positioned around performer. There are also GUI buttons to trigger certain transitions/parameter changes, but a little more tweaking is needed to make sure things reset correctly.


Continued Development & Loose Roadmap

Continued Development for the project sees me continue to flesh out the Unity enviroment with more lighting and VFX and integrating OSC/Midi control, integrate Unity with external software like Chateigne for FlowToy LED control, to while also developing the hardware/physical interface of the dragon staff to create more modes of interaction.


Unity-

Create flame throwers and particle strips vfx tied to staff spoke positions

Recieve messages from TouchOSC or Midi board, either directly or through OSC Querry

Program movement patterns for stage lighting ring and create methods to trigger each pattern with adjustable parameters

Integrate LIV for mixed reality recording/streaming

Adding Full Body tracking for performer avatars

Figure out how to make this a social vr experience for VRChat



External Software-

Create custom TouchOSC interface on Ipad and successfully send messages to Unity & Chataigne

Integrate with OSC messages from Chataigne to trigger effects and adjust parameters in Unity while simultaneously controlling Dragon Staff FlowToys capsule LEDs

Continue Debugging VAC virtual audio cable input for audio reactivity



Dragon Staff-

create capacitive touch zones along the staff grip to act as buttons

design new hubs/spoke ends that integrate VR tracker attachment point and experiment with 3 spoke and 4 spoke designs incorporating Flowtoys Capsules lights

creating a custom ESP32 device with IMU remove reliance on VR hardware and open the posibility of using the project with fire props



Thanks for checking out my project and feel free to reach out with questions!
