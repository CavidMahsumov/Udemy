using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface ICommentService
    {
        Comment GetById(int id);
        List<Comment> GetAll();
        void Add(Comment entity);
        void Delete(Comment entity);
        void Update(Comment entity);
    }
}
