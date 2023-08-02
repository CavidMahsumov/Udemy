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
    public class CommentManager : ICommentService
    {
        private ICommentRepository _repository;

        public CommentManager(ICommentRepository repository)
        {
            _repository = repository;
        }

        public void Add(Comment entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Comment entity)
        {
            _repository?.Delete(entity);
        }

        public List<Comment> GetAll()
        {
            return _repository.GetAll();
        }

        public Comment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
