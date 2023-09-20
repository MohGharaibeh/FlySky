using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Service
{
    public interface IAboutService
    {
        public bool UpdateAbout(About about);
        public List<About> GetAll();
        public About GetById();

    }
}
