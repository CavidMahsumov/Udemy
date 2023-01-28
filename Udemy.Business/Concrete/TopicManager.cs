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
    public class TopicManager : ITopicService
    {
        private ITopicRepository _repository;

        public TopicManager(ITopicRepository repository)
        {
            _repository = repository;
        }

        public void Add(Topic entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Topic entity)
        {
            if (entity != null)
            {
                _repository.Delete(entity);
            }
        }

        public List<Topic> GetAll()
        {
            return _repository.GetAll();
        }

        public Topic GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Topic> GetByTopic(int topicId)
        {
            throw new NotImplementedException();
        }

        public void Update(Topic entity)
        {
            throw new NotImplementedException();
        }
    }
}
