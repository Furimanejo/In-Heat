# In Heat
An application to control sex toys based on the user's performance in Overwatch (On-fire Meter)

## How It Works

#### Controling Devices
In Heat uses the Buttplug library (https://buttplug.io/). Buttplug is an open-source standards and software project for controlling intimate hardware, including sex toys, fucking machines, and more.

Here's a list of suported devices: https://iostindex.com/?filter0ButtplugSupport=7

In Heat is a Buttplug client and must connect to a Buttplug server (https://intiface.com/desktop/) to work.

#### Tracking The On-fire Meter

In Heat uses Emgu CV, a C# image processing library.

The basic computer vision flow is: 
- Screenshot the user's screen around the On-fire Meter area.
- Locate the actual bar and create a mask of it.
- Use the mask to count the number of cyan and white pixels in the bar.

## Making It Run

- Open Intiface Desktop (https://intiface.com/desktop/) and start the server, the computer icon on the top right should turn green.
- Open In Heat and click connect, Intiface's phone icon should turn green and a list of connected devices should appear in the Server Status tab.
- Open the game and enter the Practice Range, or alternatively open a Image/Video of the game in full screen.
- In Heat should now be tracking the On-fire Meter and updating the read value to the connected devices.

## Bugs And Observations

- The game/image must be open in your main screen (in case you have more than one monitor).
- Only tested on 1920x1080 screen/game resolution, let me know if it works on a different resolution.
- Only tested on the game's default color scheme, if you want to use a colorblind color scheme please let me know.
- In Heat only works with vibrating devices by now, more types of activation will be added later.
- Even tho XInput devices (gamepads) can be controled by Buttplug, Overwatch detects them as gamepads and override the inputs when its window is focused.
