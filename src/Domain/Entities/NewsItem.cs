using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class NewsItem : AuditableEntity
    {
        public NewsItem()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
