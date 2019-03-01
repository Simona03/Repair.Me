using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Problem
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public RepairType RepairType { get; set; }
        public RepairShop RepairShop { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeSolved { get; set; }
    }
}
