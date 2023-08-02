using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.Abstract;
using Udemy.DataAccess.Abstract;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private ITeacherRepository _repository;

        public TeacherManager(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public void Add(Teacher entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Teacher entity)
        {
            _repository.Delete(entity);
        }

        public List<Teacher> GetAll()
        {
            return _repository.GetAll();
        }

        public Teacher GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
