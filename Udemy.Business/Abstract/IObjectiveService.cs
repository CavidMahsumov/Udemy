using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface IObjectiveService
    {
        ObjectiveAndOutcomes GetById(int id);
        List<ObjectiveAndOutcomes> GetAll();
        void Add(ObjectiveAndOutcomes entity);
        void Delete(ObjectiveAndOutcomes entity);
        void Update(ObjectiveAndOutcomes entity);
    }
}
