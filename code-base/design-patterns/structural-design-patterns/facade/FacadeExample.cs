namespace code_base.design_patterns.structural_design_patterns.facade
{
    /// <summary>
    /// The Facade Pattern
    ///
    /// Intent: Provide a unified interface to a set of interfaces in a subsystem.
    /// Facade defines a higher-level interface that makes the subsystem easier to use.
    /// </summary>
    public class FacadeExample
    {
        public static void Run()
        {
            Console.WriteLine("--- Facade Pattern Demonstration ---\n");

            // Create subsystem objects
            var amp = new Amplifier();
            var dvd = new DvdPlayer();
            var projector = new Projector();

            // Create the facade
            var homeTheater = new HomeTheaterFacade(amp, dvd, projector);

            // Use the facade to watch a movie
            homeTheater.WatchMovie("Inception");

            Console.WriteLine("\n--- End of Demonstration ---");
        }
    }

    // Subsystem classes
    public class Amplifier
    {
        public void On() => Console.WriteLine("Amplifier: On");
        public void SetVolume(int level) => Console.WriteLine($"Amplifier: Volume set to {level}");
        public void Off() => Console.WriteLine("Amplifier: Off");
    }

    public class DvdPlayer
    {
        public void On() => Console.WriteLine("DVD Player: On");
        public void Play(string movie) => Console.WriteLine($"DVD Player: Playing \"{movie}\"");
        public void Off() => Console.WriteLine("DVD Player: Off");
    }

    public class Projector
    {
        public void On() => Console.WriteLine("Projector: On");
        public void WideScreenMode() => Console.WriteLine("Projector: Wide Screen Mode");
        public void Off() => Console.WriteLine("Projector: Off");
    }

    // The Facade
    public class HomeTheaterFacade
    {
        private readonly Amplifier _amp;
        private readonly DvdPlayer _dvd;
        private readonly Projector _projector;

        public HomeTheaterFacade(Amplifier amp, DvdPlayer dvd, Projector projector)
        {
            _amp = amp;
            _dvd = dvd;
            _projector = projector;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            _amp.On();
            _amp.SetVolume(5);
            _projector.On();
            _projector.WideScreenMode();
            _dvd.On();
            _dvd.Play(movie);
        }
    }
}