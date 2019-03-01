using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business
{
    public class RepairTypeBusiness
    {
        private RepairContext repairContext;

        public List<RepairType> GetAll()
        {
            using (repairContext = new RepairContext())
            {
                return repairContext.RepairTypes.ToList();
            }
        }

        public RepairType Get(int id)
        {
            using (repairContext = new RepairContext())
            {
                return repairContext.RepairTypes.Find(id);
            }
        }

        public void Add(RepairType repairType)
        {
            using (repairContext = new RepairContext())
            {
                repairContext.RepairTypes.Add(repairType);
                repairContext.SaveChanges();
            }
        }

        public void Update(RepairType repairType)
        {
            using (repairContext = new RepairContext())
            {
                var item = repairContext.RepairTypes.Find(repairType.Id);
                repairContext.Entry(item).CurrentValues.SetValues(repairType);
                repairContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (repairContext = new RepairContext())
            {
                var item = repairContext.RepairTypes.Find(id);
                if (item != null)
                {
                    repairContext.RepairTypes.Remove(item);
                    repairContext.SaveChanges();
                }
            }
        }

    }
}
