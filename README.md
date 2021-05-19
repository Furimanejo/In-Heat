# In Heat
An application to control sex toys based on the user's performance in Overwatch (On-fire Meter)

Here's a list of suported devices: https://iostindex.com/?filter0ButtplugSupport=7

## Making It Run

- Download [In Heat](https://github.com/Furimanejo/In-Heat/releases) and [Intiface Desktop](https://intiface.com/desktop/).
- Open Intiface Desktop and start the server, the computer icon on the top right should turn green.
- Turn on (Bluetooth) or connect (USB) your devices.
- Open In Heat and click connect, Intiface's phone icon should turn green and a list of connected devices should appear in the Server Status tab.
- Open the game and enter the Practice Range, or alternatively open a Image/Video of the game in full screen.
- In Heat should now be tracking the On-fire Meter and updating the read value to the connected devices.

## Bugs And Observations

- The game/image must be open in your main screen (in case you have more than one monitor).
- Only tested on 1920x1080 screen/game resolution, let me know if it works on a different resolution.
- Only tested on the game's default color scheme, if you want to use a colorblind color scheme please let me know.
- In Heat only works with vibrating devices by now, more types of activation (e-stim, stroking) might be added later.
- If you want to use XInput devices (gamepads) as vibrators you'll have to follow [this workaround](https://www.reddit.com/r/Overwatch/comments/826tda/how_do_i_make_x360ce_work_for_overwatch/?utm_source=share&utm_medium=web2x&context=3) to disable the game's control over the gamepads.

## How It Works

#### Controling Devices
In Heat uses the [Buttplug library](https://buttplug.io/). Buttplug is an open-source standards and software project for controlling intimate hardware, including sex toys, fucking machines, and more.

In Heat is a Buttplug client and must connect to a Buttplug server to work.

#### Tracking The On-fire Meter

In Heat uses Emgu CV, a C# image processing library, to locate the brightest cyan spot on the bar area, and calculate the distance from the capture box origin;
