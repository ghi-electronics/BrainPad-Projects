// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace HighLowThermometer {
    class Program {
        static double CurrentTemperature, MaximumTemperature, MinimumTemperature, TemperaturePosition;

        static void Main() {
            CurrentTemperature = BrainPad.TemperatureSensor.ReadTemperatureInFahrenheit();
            MinimumTemperature = CurrentTemperature;
            MaximumTemperature = CurrentTemperature;

            while (true) {
                CurrentTemperature = BrainPad.TemperatureSensor.ReadTemperatureInFahrenheit();
                if (CurrentTemperature > MaximumTemperature)
                    MaximumTemperature = CurrentTemperature;
                if (CurrentTemperature < MinimumTemperature)
                    MinimumTemperature = CurrentTemperature;

                BrainPad.Display.Clear();

                BrainPad.Display.DrawSmallText(39, 0, "Current");
                BrainPad.Display.DrawText(37, 12, (CurrentTemperature.ToString("F1")));

                BrainPad.Display.DrawSmallText(2, 34, "Minimum");
                BrainPad.Display.DrawText(0, 46, (MinimumTemperature.ToString("F1")));

                BrainPad.Display.DrawSmallText(72, 34, "Maximum");
                BrainPad.Display.DrawText(70, 46, (MaximumTemperature.ToString("F1")));

                if ((MaximumTemperature - MinimumTemperature) > 0) {
                    TemperaturePosition = (CurrentTemperature - MinimumTemperature) / (MaximumTemperature - MinimumTemperature) * 127;
                    BrainPad.Display.DrawLine(0, 63, (int)TemperaturePosition, 63);
                    BrainPad.Display.DrawPoint(0, 62);
                    BrainPad.Display.DrawPoint(127, 62);

                    BrainPad.LightBulb.TurnColor(TemperaturePosition / 32, 0, (127 - TemperaturePosition) / 16);
                }

                BrainPad.Display.RefreshScreen();
                BrainPad.Wait.Milliseconds(250);
            }
        }
    }
}
