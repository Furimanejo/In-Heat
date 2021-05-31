# In Heat
A windows application to control sex toys based on the user's performance in Overwatch (On-fire Meter)

Here's a list of suported devices (only vibrating toys will work for now): https://iostindex.com/?filter0ButtplugSupport=7

## Warnings 

- This application is not a cheat nor does it inject any code into Overwatch, but Blizzard's End User Licence Agreement is vague, so I can't guarantee you won't be banned. _**Use In Heat at your own risk**_.
- Remember to always play safe, sane and consensual. Please, _**do not drag unsuspecting players into your play**_.

## Making It Run

 Video Tutorial: https://youtu.be/tNbJhKMKyC4

- Dowload and install [Intiface Desktop](https://intiface.com/desktop/).
- Download a release(.zip file) of [In Heat](https://github.com/Furimanejo/In-Heat/releases) and extract it to a folder.
- Open Intiface Desktop and start the server, the computer icon on the top right should turn green.
- Turn on (Bluetooth) or connect (USB) your devices.
- Open the InHeat executable inside the folder and click connect. Intiface's phone icon should turn green and a list of connected devices should appear.
- Open the game and test it. You can easily do so by creating a game with bots (Play > Game Browser > Create > Add IA).

## Bugs And Observations

- The game/image must be open in your main screen (in case you have more than one monitor).
- The game must be running in borderless mode for the overlay to work.
- Only tested on 1920x1080 screen/game resolution, let me know if it works on a different resolution.
- Only tested on the game's default color scheme, if you want to use a colorblind color scheme please let me know.
- In Heat only works with vibrating devices for now, more types of activation (rotation, stroking, etc) might be added later.
- If you want to use XInput devices (gamepads) as vibrators you'll have to follow [this workaround](https://www.reddit.com/r/Overwatch/comments/826tda/how_do_i_make_x360ce_work_for_overwatch/?utm_source=share&utm_medium=web2x&context=3) to disable the game's control over the gamepads.

## Support

If you want to make a comment or need suport, feel free to go to my [discord server](https://discord.gg/wz2qvkuEyJ).

If you liked this application and want to support me, you can do so at my [Ko-fi page](https://ko-fi.com/furimanejo) or through Bitcoin (bc1qjt6xq7enqfa2fudc9v2kqw9w7d8cjg5uma477a).

## How It Works

#### Controling Devices

In Heat uses the [Buttplug library](https://buttplug.io/). Buttplug is an open-source standards and software project for controlling intimate hardware, including sex toys, fucking machines, and more.

#### Tracking The On-fire Meter

In Heat uses Emgu CV, a C# image processing library, to locate the brightest cyan spot on the bar area, and calculate the distance from the capture box origin;
