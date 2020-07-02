using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Comments.Commands.CreateComment;
using CleanArchitecture.Application.Comments.Commands.Queries.GetNews;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class CommentsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<CommentsVm>> Get(Guid newsId)
        {
            return await Mediator.Send(new GetCommentsQuery {NewsItemId = newsId});
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateCommentCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
