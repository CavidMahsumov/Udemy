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
    public class RequirementRepository : IRequirementRepository
    {
        private UdemyContext _context;

        public RequirementRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(Requirement entity)
        {
            _context.Requirements.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Requirement entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<Requirement> GetAll()
        {
            return _context.Requirements.ToList();
        }

        public Requirement GetById(int id)
        {
            return _context.Requirements.Find(id);
        }

        public void Update(Requirement entity)
        {
            throw new NotImplementedException();
        }
    }
}
