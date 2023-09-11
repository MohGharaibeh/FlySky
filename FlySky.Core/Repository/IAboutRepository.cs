using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface IAboutRepository
    {
        public bool UpdateAbout(About about);
        public List<About> GetAll();
    }
}
