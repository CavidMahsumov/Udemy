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
    public class CommentRepository : ICommentRepository
    {
        private UdemyContext _context;

        public CommentRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(Comment entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
