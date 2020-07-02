using System;
using System.Security.Authentication;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.News.Commands.DeleteNews
{
    public class DeleteNewsItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteNewsItemCommandHandler : IRequestHandler<DeleteNewsItemCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteNewsItemCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteNewsItemCommand request, CancellationToken cancellationToken)
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

            _context.NewsItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
