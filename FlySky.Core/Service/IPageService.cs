﻿using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Service
{
    public interface IPageService
    {
        public List<Page> AllPages();
        public bool UpdatePage(Page page);
        public Page GetPage();
    }
}
