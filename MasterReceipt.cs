using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXG.ServiceCenterReceipts
{
    class MasterReceipt
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string Equipment { get; set; }
        public double AllMoney { get; set; }
        public double MyMoney { get; set; }
        public bool Discount { get; set; } = false;

        public MasterReceipt(int number, string equipment, int money, bool discount)
        {
            Date = DateTime.Now;
            Number = number;
            Equipment = equipment;
            Discount = discount;
            if (Discount)
            {
                AllMoney = money;
            }
            else
            {
                AllMoney = money * 0.9;
            }
            MyMoney = AllMoney * 0.4;
        }

        public MasterReceipt() { }

        public MasterReceipt(int number, string equipment, int money)
        {
            Date = DateTime.Now;
            Number = number;
            Equipment = equipment;
            if (Discount)
            {
                AllMoney = money;
            }
            else
            {
                AllMoney = money * 0.9;
            }
            MyMoney = AllMoney * 0.4;
        }

        public virtual ICollection<ComponentsList> ComponentsLists { get; set; }
    }
}
