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

        public DbSet<MasterPassword> MasterPasswords { get; set; }

        public DbSet<MasterReceipt> MasterReceipts { get; set; }
        
        public DbSet<Component> Components { get; set; }
    }
}
