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
    public class TopicRepository : ITopicRepository
    {
        private UdemyContext _context;

        public TopicRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(Topic entity)
        {
            _context.Topics.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Topic entity)
        {
            _context.Topics.Remove(entity);
            _context.SaveChanges();
        }

        public List<Topic> GetAll()
        {
            return _context.Topics.ToList();
        }

        public Topic GetById(int id)
        {
            return _context.Topics.Find(id);
        }

        public void Update(Topic entity)
        {
            throw new NotImplementedException();
        }
    }
}
