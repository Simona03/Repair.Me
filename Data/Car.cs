using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Car
    {
        public int Id { get; set; }
        public string VinNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public CarBrand Brand { get; set; }
        public int ManufacturedYear { get; set; }
    }
}
