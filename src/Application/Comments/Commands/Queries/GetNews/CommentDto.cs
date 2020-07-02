using CleanArchitecture.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Comments.Commands.Queries.GetNews
{
    public class CommentDto : IMapFrom<Comment>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Autor { get; set; }
        public DateTime Created { get; set; }
    }
}
