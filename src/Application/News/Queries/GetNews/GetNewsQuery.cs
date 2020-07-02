using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.News.Queries.GetNews
{
    public class GetNewsQuery : IRequest<NewsVm>
    {
    }

    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, NewsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public GetNewsQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<NewsVm> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.NewsItems.ProjectTo<NewsItemDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken);

            foreach (var news in list)
            {
                news.Autor = await _identityService.GetUserNameAsync(news.Autor);
            }
            return new NewsVm
            {
                List = list
            };
        }
    }
}
