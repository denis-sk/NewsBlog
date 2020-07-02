using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.News.Queries.GetNews
{
    public class NewsItemDto : IMapFrom<NewsItem>
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int CommentsCount { get; set; }
    }
}
