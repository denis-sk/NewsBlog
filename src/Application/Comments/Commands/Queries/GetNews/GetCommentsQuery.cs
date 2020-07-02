using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Comments.Commands.Queries.GetNews
{
    public class GetCommentsQuery : IRequest<CommentsVm>
    {
        public Guid NewsItemId { get; set; }
    }

    public class GetNewsQueryHandler : IRequestHandler<GetCommentsQuery, CommentsVm>
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

        public async Task<CommentsVm> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _context.Comments
                .Where(m => m.NewsItemId == request.NewsItemId)
                .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Created)
                .ToListAsync(cancellationToken);

            foreach (var comment in comments)
            {
                comment.Autor = await _identityService.GetUserNameAsync(comment.Autor);
            }

            return new CommentsVm()
            {
                List = comments
            };
        }
    }
}
