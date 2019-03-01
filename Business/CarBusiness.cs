using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class CarBusiness
    {
        private RepairContext repairContext;

        public List<Car> GetAll()
        {
            using (repairContext = new RepairContext())
            {
                return repairContext.Cars.ToList();
            }
        }

        public Car Get(int id)
        {
            using (repairContext = new RepairContext())
            {
                return repairContext.Cars.Find(id);
            }
        }

        public void Add(Car Car)
        {
            using (repairContext = new RepairContext())
            {
                repairContext.Cars.Add(Car);
                repairContext.SaveChanges();
            }
        }

        public void Update(Car Car)
        {
            using (repairContext = new RepairContext())
            {
                var item = repairContext.Cars.Find(Car.Id);
                repairContext.Entry(item).CurrentValues.SetValues(Car);
                repairContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (repairContext = new RepairContext())
            {
                var item = repairContext.Cars.Find(id);
                if (item != null)
                {
                    repairContext.Cars.Remove(item);
                    repairContext.SaveChanges();
                }
            }
        }
    }
}
