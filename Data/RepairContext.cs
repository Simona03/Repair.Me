using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class RepairContext : DbContext
    {
        public RepairContext(): base("name=RepairContext")
        {

        }

        public DbSet<RepairType> RepairTypes { get; set; }
        public DbSet<CarBrand> Brands { get; set; }
        public DbSet<RepairShop> RepairShops { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Problem> Problems { get; set; }
    }
}
