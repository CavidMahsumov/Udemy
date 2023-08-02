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
    public class RequirementManager : IRequirementService
    {
        private IRequirementRepository _repository;

        public RequirementManager(IRequirementRepository repository)
        {
            _repository = repository;
        }

        public void Add(Requirement entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Requirement entity)
        {
            _repository.Delete(entity);
        }

        public List<Requirement> GetAll()
        {
            return _repository.GetAll();
        }

        public Requirement GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Category> GetByRequirement(int requirementId)
        {
            throw new NotImplementedException();
        }

        public void Update(Requirement entity)
        {
            throw new NotImplementedException();
        }
    }
}
