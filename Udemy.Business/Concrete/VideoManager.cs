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
    public class VideoManager : IVideoService
    {
        private IVideoRepository _videoRepository;

        public VideoManager(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public void Add(Video entity)
        {
            _videoRepository.Add(entity);
        }

        public void Delete(Video entity)
        {
            _videoRepository.Delete(entity);
        }

        public List<Video> GetAll()
        {
            return _videoRepository.GetAll();
        }

        public Video GetById(int id)
        {
            return _videoRepository.GetById(id);
        }

        public void Update(Video entity)
        {
            throw new NotImplementedException();
        }
    }
}
