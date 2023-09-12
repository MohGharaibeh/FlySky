using FlySky.Core.Data;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Service
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public bool UpdateAbout(About about)
        {
            return _aboutRepository.UpdateAbout(about);
        }
        public List<About> GetAll()
        {
            return _aboutRepository.GetAll();
        }
    }
}
