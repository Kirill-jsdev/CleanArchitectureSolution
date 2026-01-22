using Application.Activities.DTOs;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Activities.Queries
{
    public class GetActivityList
    {
        public class Query : IRequest<Result<List<ActivityDto>>>
        {
        }

        public class Handler(AppDbContext context, IMapper mapper) :
            IRequestHandler<Query, Result<List<ActivityDto>>>
        {
            public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var activities = await context.Activities
                        .ProjectTo<ActivityDto>(mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    return Result<List<ActivityDto>>.Success(activities);
                }
                catch (Exception)
                {
                    // Log the error here if you have a logger (e.g., _logger.LogError(ex, "Database connection failed"))

                    return Result<List<ActivityDto>>.Failure("Server error: Unable to connect to the database.", 500);
                }
            }
        }
    }
}
