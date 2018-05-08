﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Parking
{   
    /// <summary>
    /// Represents a set of settings used in <see cref="Parking"/> class instances
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Timeout value in ms.
        /// </summary>
        public static int Timeout { get; }
        /// <summary>
        /// Store a price set for each value of <see cref="CarType"/>.
        /// </summary>
        public static Dictionary<CarType, int> PriceSet { get; } = new Dictionary<CarType, int>
        {
            {CarType.Truck,5 },
            {CarType.Passenger,3 },
            {CarType.Bus,2 },
            {CarType.Motorcycle,1 }
        };
        /// <summary>
        /// Initial size of parking.
        /// </summary>
        public static int ParkingSpace { get; }
        /// <summary>
        /// Fine coefficient.
        /// </summary>
        public static double Fine { get; }
        static Settings()
        {
            Timeout = 5000;
            ParkingSpace = 15;
            Fine = 2;
        }
    }
}
