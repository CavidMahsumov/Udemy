using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface IVideoService
    {
        Video GetById(int id);
        List<Video> GetAll();
        void Add(Video entity);
        void Delete(Video entity);
        void Update(Video entity);
    }
}
