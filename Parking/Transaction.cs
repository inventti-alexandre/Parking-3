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
        public int SpentMoney { get; }

        public Transaction(string carId,int spentMoney)
        {
            TransactionTime = DateTime.Now;
            CarId = carId;
            SpentMoney = spentMoney;
        }
    }
}
