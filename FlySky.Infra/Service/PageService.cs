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
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public List<Page> AllPages()
        {
            return _pageRepository.AllPages();
        }
        public bool UpdatePage(Page page)
        {
            return _pageRepository.UpdatePage(page);
        }
    }
}
