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
    public class SubCategoryManager : ISubCategoryService
    {
        private ISubCategoryRepository _repository;

        public SubCategoryManager(ISubCategoryRepository repository)
        {
            _repository = repository;
        }

        public void Add(SubCategory entity)
        {
            _repository.Add(entity);
        }

        public void Delete(SubCategory entity)
        {
            if(entity != null)
            {
                _repository.Delete(entity);
            }
        }

        public List<SubCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public SubCategory GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<SubCategory> GetBySubCategory(int subCategoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(SubCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
