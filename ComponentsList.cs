using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXG.ServiceCenterReceipts
{
    class ComponentsList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int MasterReceiptID { get; set; }

        public virtual MasterReceipt MasterReceipt { get; set; }
    }
}
