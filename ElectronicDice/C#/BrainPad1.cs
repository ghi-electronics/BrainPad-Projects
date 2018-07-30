using GHIElectronics.TinyCLR.BrainPad;
using System.Diagnostics;

namespace ElectronicDice {
    [DebuggerNonUserCode]
    public static class BrainPad {
        public static void WriteToComputer(string message) => Debug.WriteLine(message);
        public static void WriteToComputer(int message) => BrainPad.WriteToComputer(message.ToString("N0"));
        public static void WriteToComputer(double message) => BrainPad.WriteToComputer(message.ToString("N4"));

        public static Accelerometer Accelerometer { get; } = new Accelerometer();
        public static Buttons Buttons { get; } = new Buttons();
        public static Buzzer Buzzer { get; } = new Buzzer();
        public static Display Display { get; } = new Display();
        public static Expansion Expansion { get; } = new Expansion();
        public static LightBulb LightBulb { get; } = new LightBulb();
        public static LightSensor LightSensor { get; } = new LightSensor();
        public static ServoMotors ServoMotors { get; } = new ServoMotors();
        public static TemperatureSensor TemperatureSensor { get; } = new TemperatureSensor();
        public static Wait Wait { get; } = new Wait();
    }
}
