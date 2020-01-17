using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXG.ServiceCenterReceipts
{
    class ServiceCenterDbContext : DbContext
    {
        public ServiceCenterDbContext() : base("DbConnection") { }

        public DbSet<MasterReceipt> MasterReceipts { get; set; }
        public DbSet<ComponentList> ComponentsLists { get; set; }
    }
}
