using System;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.News.Commands.CreateNews
{
    public class CreateNewsItemCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class CreateNewsItemCommandHandler : IRequestHandler<CreateNewsItemCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateNewsItemCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateNewsItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new NewsItem
            {
                Title = request.Title,
                Description = request.Description,
                Autor = _currentUserService.UserId
            };

            _context.NewsItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
