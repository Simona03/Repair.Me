using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class ProblemBusiness
    {
        private RepairContext repairContext;

        public List<Problem> GetAll()
        {
            using (repairContext = new RepairContext())
            {
                return repairContext.Problems.ToList();
            }
        }

        public Problem Get(int id)
        {
            using (repairContext = new RepairContext())
            {
                return repairContext.Problems.Find(id);
            }
        }

        public void Add(Problem Problem)
        {
            using (repairContext = new RepairContext())
            {
                repairContext.Problems.Add(Problem);
                repairContext.SaveChanges();
            }
        }

        public void Update(Problem Problem)
        {
            using (repairContext = new RepairContext())
            {
                var item = repairContext.Problems.Find(Problem.Id);
                repairContext.Entry(item).CurrentValues.SetValues(Problem);
                repairContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (repairContext = new RepairContext())
            {
                var item = repairContext.Problems.Find(id);
                if (item != null)
                {
                    repairContext.Problems.Remove(item);
                    repairContext.SaveChanges();
                }
            }
        }
    }
}
