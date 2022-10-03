# cockpit-lights
App to sync MSFS variables with Hue lights.

![Screenshot](resources/Default%20Flood%20Mapping.png)

You can switch on your Hue lights from within Microsoft Flight Simulator.
For example you can connect a Hue light to the Dome light in the PMDG Boeing 737, the flood light in the Bonanza G37 or a cabin light!

## Usage

Run the application and it automatically starts to scan for Hue Bridges.

Then you need to press the connect button on the hue bridge you want to connect to and press the according Register button.

Now your Hue lights are listed and you can select the light you want to control.

You can create multiple profiles for different aircrafts.

The next step is to find the SimConnect variable that represents the light state in MSFS. 

| Aircraft | Switch | Variable | Factor | Bit |
|----------|:------:|:--------:|:------:|----:|
|Bonanza G36|Flood|LIGHT STATES ON|255|11 |
|PMDG Boeing 737|Dome|LIGHT POTENTIOMETER:13|300|0|

The Factor is a number to scale the value from the simulator to 0-255 for the Hue light.
So you can control the maximum brightness with this setting.

The bit setting is required when the light state is represented by a bit in the value from the simulator. 0 indicates that the bit setting is not used.

With the color setting you can control the color of the Hue light.

## Stored Settings

Your settings are stored within "%AppData%\cockpit-lights"
