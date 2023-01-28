using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface ITeacherService
    {
        Teacher GetById(int id);
        List<Teacher> GetAll();
        void Add(Teacher entity);
        void Delete(Teacher entity);
        void Update(Teacher entity);
    }
}
