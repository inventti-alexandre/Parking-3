using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Transaction
    {
        public DateTime TransactionTime { get; }
        public string CarId { get; }
        public double SpentMoney { get; }

        public Transaction(string carId,double spentMoney)
        {
            TransactionTime = DateTime.Now;
            CarId = carId;
            SpentMoney = spentMoney;
        }
    }
}
