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
    public class ObjectiveManager : IObjectiveService
    {
        private IObjectiveRepository _repository;

        public ObjectiveManager(IObjectiveRepository repository)
        {
            _repository = repository;
        }

        public void Add(ObjectiveAndOutcomes entity)
        {
            _repository.Add(entity);
        }

        public void Delete(ObjectiveAndOutcomes entity)
        {
            _repository.Delete(entity);
        }

        public List<ObjectiveAndOutcomes> GetAll()
        {
            return _repository.GetAll();
        }

        public ObjectiveAndOutcomes GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(ObjectiveAndOutcomes entity)
        {
            throw new NotImplementedException();
        }
    }
}
