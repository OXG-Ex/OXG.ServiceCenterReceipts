using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXG.ServiceCenterReceipts
{
    class ComponentList
    {  
        [Key]
        [ForeignKey ("MasterReceipt")]
        public int ID { get; set; }
        public List<Component> Components { get; set; }
        public int MasterReceiptID { get; set; }
        public ComponentList(List<Component> components)
        {
            Components = components;
        }
        public ComponentList()
        {
            Components = new List<Component>();
        }

        public virtual MasterReceipt MasterReceipt { get; set; }
    }
}
