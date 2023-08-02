using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface ISubCategoryService
    {
        SubCategory GetById(int id);
        List<SubCategory> GetAll();
        void Add(SubCategory entity);
        void Delete(SubCategory entity);
        void Update(SubCategory entity);
        List<SubCategory> GetBySubCategory(int subCategoryId);
    }
}
