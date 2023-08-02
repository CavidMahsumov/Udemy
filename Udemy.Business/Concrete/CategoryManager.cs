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
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryManager(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public void Add(Category entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Category entity)
        {
            if(entity != null)
            {
                _repository.Delete(entity);
            }
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Category> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
