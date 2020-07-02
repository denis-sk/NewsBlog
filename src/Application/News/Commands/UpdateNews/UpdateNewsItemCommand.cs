using System;
using System.Security.Authentication;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.News.Commands.UpdateNews
{
    public partial class UpdateNewsItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class UpdateNewsItemCommandHandler : IRequestHandler<UpdateNewsItemCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateNewsItemCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(UpdateNewsItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.NewsItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NewsItem), request.Id);
            }

            if (entity.Autor != _currentUserService.UserId)
            {
                throw new AuthenticationException();
            }

            entity.Title = request.Title;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
