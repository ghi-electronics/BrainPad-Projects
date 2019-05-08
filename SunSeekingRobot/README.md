# Sun Seeking Robot
---
![Sun Seeking Chick](images/sun-seeker.gif)

**Difficulty: Moderately easy, some assembly required.**

**Objective: Servo control / simple robotics.**

**Note: This project requires a two wheel drive mini robot platform and battery. More details are found at the bottom of this page.**

<iframe width="560" height="315" src="https://www.youtube.com/embed/UZvxMPspZzk?rel=0" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

## How it Works
A toy car is programmed to stay in the sunlight and turn any time the light sensor senses shade. Both rear wheels of the car are driven by continuous servo motors. When the program starts both motors are driving the car forward. When the light sensor detects light below a given threshold, the program will stop one of the rear wheels causing the car to turn. When the sensor once again senses the sunlight both wheels push forward. The program alternates which wheel will stop when the light sensed is below the threshold.

## The Code

### Microsoft Makecode
Click [here](https://makecode.com/_PFX5r3bgLcPh) to go directly to the program on Microsoft MakeCode. You can also copy and paste the following JavaScript code into Microsoft MakeCode's JavaScript editor.

```
let Direction = 0
input.onLightConditionChanged(LightCondition.Dark, function () {
    if (Direction == 0) {
        pins.SERVO2.servoWrite(90)
        Direction = 1
    } else {
        pins.SERVO1.servoWrite(90)
        Direction = 0
    }
})
input.onLightConditionChanged(LightCondition.Bright, function () {
    pins.SERVO1.servoWrite(180)
    pins.SERVO2.servoWrite(0)
})
input.setLightThreshold(LightCondition.Dark, 250)
pins.SERVO1.servoWrite(180)
pins.SERVO2.servoWrite(0)
```

Microsoft MakeCode block program:

![Sun seeker block program](images/sun-seeker-blocks.png)

## The Two Wheel Drive Mini Robot Platform
We found our car chassis on Amazon, but they can also be found on eBay or by searching in your favorite search engine for "2WD Mini Robot Platform Kit." Make sure you get one that looks the same as the chassis in the video to assure it's compatible with the BrainPad and programs on this page.

## The Battery
There are many rechargeable battery packs available that are meant to power devices (like phones) that have a micro USB connector. You can check Amazon, eBay, or even local dollar stores or other retail outlets. The battery is not necessary to make this car work, but without it the car will be tethered by the USB cable to your computer or laptop. In the video above and the picture below you can see our blue battery mounted underneath the BrainPad.

> [!Tip]
> Make sure to push the battery towards the back of the car as far as possible. This will put more weight over the drive wheels and give the car better traction.

![Sun seeking car](images/sun-seeker.jpg)