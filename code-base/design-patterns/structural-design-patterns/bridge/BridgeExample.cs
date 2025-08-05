namespace code_base.design_patterns.structural_design_patterns.bridge
{
    /// <summary>
    /// The Bridge Pattern
    ///
    /// Intent: Decouple an abstraction from its implementation so that the two can vary independently.
    /// This pattern involves an interface (the "Bridge") that makes the two independent. It's useful when
    /// you have a class and its implementation that should be extensible through subclassing, but you want
    /// to avoid a combinatorial explosion of classes.
    ///
    /// Analogy: A remote control (Abstraction) and a device (Implementation). You can have different
    /// types of remotes (basic, advanced) and different types of devices (TV, Radio). The Bridge pattern
    /// allows you to combine any remote with any device without creating a specific class for each pair.
    ///
    /// Key Components:
    /// 1. Abstraction: Defines the abstraction's interface and maintains a reference to an Implementor object.
    /// 2. Refined Abstraction: Extends the Abstraction to provide variant-specific logic.
    /// 3. Implementor: Defines the interface for implementation classes. This interface doesn't have to correspond exactly to Abstraction's interface.
    /// 4. Concrete Implementor: Implements the Implementor interface and defines its concrete implementation.
    /// </summary>
    public class BridgeExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Bridge Pattern Demonstration ---\n");

            // Create a TV device
            IDevice tv = new Tv();
            // Control the TV with a basic remote
            Console.WriteLine("Testing Basic Remote with a TV:");
            var basicRemote = new RemoteControl(tv);
            basicRemote.TogglePower();
            basicRemote.VolumeUp();
            Console.WriteLine(tv); // Output TV status

            Console.WriteLine("\n-------------------------------------\n");

            // Create a Radio device
            IDevice radio = new Radio();
            // Control the Radio with an advanced remote
            Console.WriteLine("Testing Advanced Remote with a Radio:");
            var advancedRemote = new AdvancedRemoteControl(radio);
            advancedRemote.TogglePower();
            advancedRemote.VolumeUp();
            advancedRemote.Mute();
            Console.WriteLine(radio); // Output Radio status
            
            Console.WriteLine("\n--- End of Demonstration ---");
        }
    }

    // 3. The Implementor Interface
    // Defines the interface for the implementation part.
    public interface IDevice
    {
        bool IsEnabled();
        void Enable();
        void Disable();
        int GetVolume();
        void SetVolume(int percent);
    }

    // 4. Concrete Implementor A
    public class Tv : IDevice
    {
        private bool _on = false;
        private int _volume = 30;

        public bool IsEnabled() => _on;
        public void Enable() => _on = true;
        public void Disable() => _on = false;
        public int GetVolume() => _volume;
        public void SetVolume(int percent) => _volume = Math.Clamp(percent, 0, 100);

        public override string ToString() => $"Device: TV, Status: {(_on ? "On" : "Off")}, Volume: {_volume}%";
    }

    // 4. Concrete Implementor B
    public class Radio : IDevice
    {
        private bool _on = false;
        private int _volume = 15;

        public bool IsEnabled() => _on;
        public void Enable() => _on = true;
        public void Disable() => _on = false;
        public int GetVolume() => _volume;
        public void SetVolume(int percent) => _volume = Math.Clamp(percent, 0, 100);
        
        public override string ToString() => $"Device: Radio, Status: {(_on ? "On" : "Off")}, Volume: {_volume}%";
    }


    // 1. The Abstraction
    // It contains a reference to the Implementor (IDevice).
    // It delegates the actual work to the referenced device.
    public class RemoteControl
    {
        // The "bridge" is the reference to the implementation.
        protected readonly IDevice _device;

        public RemoteControl(IDevice device)
        {
            _device = device;
        }

        public void TogglePower()
        {
            if (_device.IsEnabled())
            {
                _device.Disable();
                Console.WriteLine("Remote: Power Off");
            }
            else
            {
                _device.Enable();
                Console.WriteLine("Remote: Power On");
            }
        }

        public void VolumeDown()
        {
            _device.SetVolume(_device.GetVolume() - 10);
            Console.WriteLine("Remote: Volume Down");
        }

        public void VolumeUp()
        {
            _device.SetVolume(_device.GetVolume() + 10);
            Console.WriteLine("Remote: Volume Up");
        }
    }

    // 2. The Refined Abstraction
    // You can extend the Abstraction without changing the Implementor classes.
    public class AdvancedRemoteControl : RemoteControl
    {
        private int _lastVolume;

        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public void Mute()
        {
            Console.WriteLine("Advanced Remote: Mute");
            _lastVolume = _device.GetVolume();
            _device.SetVolume(0);
        }

        public void Unmute()
        {
            Console.WriteLine("Advanced Remote: Unmute");
            _device.SetVolume(_lastVolume);
        }
    }
}