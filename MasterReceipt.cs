using System;
using System.Collections.Generic;

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
        public string MasterName { get; set; }
        public double MasterPercent { get; set; }

        public MasterReceipt(int number, string equipment, int money, bool discount)
        {
            Date = DateTime.Now;
            Number = number;
            Equipment = equipment;
            Discount = discount;
            MasterName = Master.Name;
            MasterPercent = Master.Percent;
            if (!Discount)
            {
                AllMoney = money;
            }
            else
            {
                AllMoney = (money * 0.9);
            }
            MyMoney = AllMoney * MasterPercent;
        }

        public MasterReceipt() { }

        public MasterReceipt(int number, string equipment, int money)
        {
            Date = DateTime.Now;
            Number = number;
            Equipment = equipment;
            if (!Discount)
            {
                AllMoney = money;
            }
            else
            {
                AllMoney = (money * 0.9);
            }
            MyMoney = AllMoney * 0.4;
        }

        public virtual ICollection<Component> Components { get; set; }

       
    }
}
