using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.DataAccess.Abstract;
using Udemy.DataAccess.Concrete.EntityFramework;
using Udemy.Entity.Concrete;

namespace Udemy.DataAccess.Concrete
{
    public class ObjectiveRepository : IObjectiveRepository
    {

        private UdemyContext _context;

        public ObjectiveRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(ObjectiveAndOutcomes entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(ObjectiveAndOutcomes entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<ObjectiveAndOutcomes> GetAll()
        {
            return _context.Objectives.ToList();
        }

        public ObjectiveAndOutcomes GetById(int id)
        {
            return _context.Objectives.Find(id);
        }

        public void Update(ObjectiveAndOutcomes entity)
        {
            throw new NotImplementedException();
        }
    }
}
