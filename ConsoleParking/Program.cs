using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking;
using System.Threading;

namespace ConsoleParking
{
    class Program
    {
        static ParkingEmulator parking = ParkingEmulator.GetInstanse();
        static void Main(string[] args)
        {
            ParkingMenu menu = new ParkingMenu(parking);
            menu.Run();
        }
        
       


    }
}
