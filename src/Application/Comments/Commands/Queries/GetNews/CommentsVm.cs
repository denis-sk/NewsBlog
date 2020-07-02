using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Comments.Commands.Queries.GetNews
{
    public class CommentsVm
    {
        public IList<CommentDto> List { get; set; }
    }
}
