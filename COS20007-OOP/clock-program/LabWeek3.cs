namespace Clock
{
    public class LabWeek3
    {
        public static void Main(string[] args)
        {
            Clock clock = new Clock();
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(clock.ShowTime);
                Console.WriteLine("clock tick");
                clock.Tick();
            }
        }
    }
}
