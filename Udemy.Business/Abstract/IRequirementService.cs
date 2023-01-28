using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface IRequirementService
    {
        Requirement GetById(int id);
        List<Requirement> GetAll();
        void Add(Requirement entity);
        void Delete(Requirement entity);
        void Update(Requirement entity);
        List<Category> GetByRequirement(int requirementId);
    }
}
