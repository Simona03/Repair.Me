using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RepairShop
    {
        public RepairShop()
        {
            this.RepairTypes = new HashSet<RepairType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name="Видове ремонти")]
        public virtual ICollection<RepairType> RepairTypes { get; set; }
    }
}
