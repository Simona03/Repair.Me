using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RepairType
    {
        public RepairType()
        {
            this.RepairShops = new HashSet<RepairShop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RepairShop> RepairShops { get; set; }
    }
}
