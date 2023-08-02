using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface ITopicService
    {
        Topic GetById(int id);
        List<Topic> GetAll();
        void Add(Topic entity);
        void Delete(Topic entity);
        void Update(Topic entity);
        List<Topic> GetByTopic(int topicId);
    }
}
