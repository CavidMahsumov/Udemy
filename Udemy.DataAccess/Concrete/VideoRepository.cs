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
    public class VideoRepository : IVideoRepository
    {
        private UdemyContext _context;

        public VideoRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(Video entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Video entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }

        public Video GetById(int id)
        {
            return _context.Videos.Find(id);
        }

        public void Update(Video entity)
        {
            throw new NotImplementedException();
        }
    }
}
