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
        static ParkingEmulator p = ParkingEmulator.GetInstanse();
        static void Main(string[] args)
        {
            
        }

        //static void doSmth(object obj)
        //{
        //    try
        //    {

        //        //Console.WriteLine("Last money: "+p.GetLastEarnedMoney().GetAwaiter().GetResult());
        //        Console.WriteLine("Free places: " + p.FreePlaces.ToString());
        //        Console.WriteLine("Engaged places: " + p.EngagedPlaces.ToString());
        //        Console.WriteLine("Log: " + p.GetTransactionsLog().GetAwaiter().GetResult());
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: \n"+e.Message);
        //    }
        //}


    }
}
