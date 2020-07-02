using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.News.Commands.CreateNews;
using CleanArchitecture.Application.News.Commands.DeleteNews;
using CleanArchitecture.Application.News.Commands.UpdateNews;
using CleanArchitecture.Application.News.Queries.GetNews;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class NewsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<NewsVm>> Get()
        {
            return await Mediator.Send(new GetNewsQuery());
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateNewsItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateNewsItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteNewsItemCommand { Id = id });

            return NoContent();
        }
    }
}
