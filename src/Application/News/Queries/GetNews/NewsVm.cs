using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.News.Queries.GetNews
{
    public class NewsVm
    {
        public IList<NewsItemDto> List { get; set; }
    }
}
