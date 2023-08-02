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
    public class CourseManager : ICourseService
    {
        
        private ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Add(Course entity)
        {
            _courseRepository.Add(entity);
        }

        public void Delete(Course entity)
        {
            _courseRepository.Delete(entity);
        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
