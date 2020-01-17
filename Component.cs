using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXG.ServiceCenterReceipts
{
    class Component
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        

        public Component() { }

        public Component(string name, int price)
        {
            Name = name;
            Price = price;
        }

        
    }
}
