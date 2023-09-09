using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface IPageRepository
    {
        public List<Page> AllPages();
        public bool UpdatePage(Page page);

    }
}
