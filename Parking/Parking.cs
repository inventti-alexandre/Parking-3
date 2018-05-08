using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    class Parking
    {
        private Settings settings;
        public List<Car> CarsList { get; }
        public List<Transaction> TransactionsList { get; }
        public int EarnedMoney { get; set; }
             
        public Parking(Settings settings)
        {
            this.settings = settings;
            CarsList = new List<Car>();
            TransactionsList = new List<Transaction>();
        }
    }
}
