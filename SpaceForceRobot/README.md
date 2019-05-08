# Space Force Robot
---
![Space force robot](images/space-force.gif)

**Difficulty: More Difficult.**

**Objective: Simple robotics.**

**Note: This project requires the SpaceForce game (or similar) and a fairly strong servo motor. Both are available online (more info at bottom of page). It also requires rods (we used welding rod) to connect the game to the servo motor, and some skill to fabricate a larger horn (control arm) for the servo motor.**

<iframe width="560" height="315" src="https://www.youtube.com/embed/qGrfdTZEsIk?rel=0" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

## How it Works
This project uses the BrainPad and a single servo motor to play the classic Space Force game which dates back to the 1940s.

## The Code
The program for this project is quite simple and code is available for both Microsoft MakeCode and in C# for Microsoft Visual Studio. If you build this project yourself, you may have to adjust the timing and servo motor angles to work properly with your particular setup.

### Microsoft MakeCode
Click [here](https://makecode.com/_3PMH7CidXa6A) to go directly to the program on Microsoft MakeCode. You can also copy and paste the following JavaScript code into Microsoft MakeCode's JavaScript editor.

```
servos.servo1.setAngle(110)
forever(function () {
    display.showString("Place ball and ", 2)
    display.showString("  press down", 4)
    display.showString("    button", 6)

    while (!(input.buttonDown.wasPressed())) {
        pause(20)
    }

    servos.servo1.setAngle(50)
    pause(200)
    for (let i = 0; i <= 60; i++) {
        servos.servo1.setAngle(50 + i)
        pause(14)
    }
})

```

Microsoft MakeCode block program:

![SpaceForce block program](images/spaceforce-blocks.png)

### C# Code
> [!Tip]
> Make sure the namespace in your program matches your project's namespace.  Your project's namespace can be found in the BrainPad Helper file by clicking on the BrainPad1.cs tab.  [**More Info**](../go-beyond/csharp/intro.md#a-few-words-about-namespaces).

```
namespace ModifyThis {
    class Program {
        static void Main() {
            BrainPad.ServoMotors.ServoOne.ConfigureAsPositional(false);
            BrainPad.ServoMotors.ServoOne.ConfigurePulseParameters(0.5, 2.5);

            while (true) {
                BrainPad.ServoMotors.ServoOne.Set(110);
                BrainPad.Display.Clear();
                BrainPad.Display.DrawSmallText(5, 10, "Place ball and press");
                BrainPad.Display.DrawSmallText(30, 25, "down button");
                BrainPad.Display.RefreshScreen();

                while (!BrainPad.Buttons.IsDownPressed()) {
                    BrainPad.Wait.Milliseconds(20);
                }

                BrainPad.ServoMotors.ServoOne.Set(50);
                BrainPad.Wait.Milliseconds(200);
                
                for (int i = 50; i < 111; i++) {
                    BrainPad.ServoMotors.ServoOne.Set(i);
                    BrainPad.Wait.Milliseconds(14);
                }
            }
        }
    }
}
```

## The Space Force Game

The space force game can be found at several online retailers by searching for "Space Force Game" in your favorite search engine. We've found it on both Amazon and eBay. Similar games go by the names "Shoot the Moon," "Space Launch," and "Executive Roll-Up." We have been able to get this program working with both versions of the game we tried. There are also smaller versions of the game that should work and could probably be used with a smaller servo motor.

## The Servo Motor

The servo motor we used is a model number KS-3518 we found on eBay. It is a 180 degree positional servo with a stall torque of 12 kg/cm at 4.8 volts. Any motor with similar specs should work. We feel that this motor had more power than we needed, so slightly smaller motors (less torque) should work as well. As is usually the case, it's better if your motor is a little over powered than under powered. The servo motor simply plugs into the BrainPad's number one servo port with the brown wire closest to the bottom to the bottom of the BrainPad.

## The Horn

We cut the horn (the control arm) out of plexiglass and hot glued it to the largest horn that came with the servo motor. While the horn that came with the motor may have worked, the motor would have had to turn nearly the full 180 degrees to cover the needed distance. We weren't sure that the motor could rotate this far quickly enough to effectively play the game. By using the larger horn the motor only has to move through 60 degrees of rotation, covering the same distance in just over one third of the time.

## Additional Assembly Information

The servo motor was simply hot glued to a two-by-four piece of wood just to keep assembly simple and fast. Large rubber bands were used to hold this two-by-four to the Space Force game so there was no damage to the game and so the game could be quickly and easily restored to original condition and be played manually. 