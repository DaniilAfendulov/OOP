using System;

namespace Plowing
{
    public class Printer
    {
        public void PrintPlot(string plot)
        {
            Console.WriteLine("Участок: " + plot);
        }

        public void PrintPlowingMachine(string plowingMachine)
        {
            Console.WriteLine("Машина для вспашки: " + plowingMachine);
        }
    }
}