using Application.Activities.DTOs;
using Application.Core;
using Application.RandomStuff.DTOs;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.RandomStuff.Queries
{
    public class GetJsonPlaceholderPost
    {
        public class Query : IRequest<Result<JsonPlaceholderPostDto>>
        {
        }

        public class Handler(JsonPlaceholderService jsonPlaceholder) :
            IRequestHandler<Query, Result<JsonPlaceholderPostDto>>
        {
            public async Task<Result<JsonPlaceholderPostDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var jsonData = await jsonPlaceholder.GetData();
                    var post = JsonSerializer.Deserialize<JsonPlaceholderPostDto>(jsonData);

                    if (post == null)
                    {
                        return Result<JsonPlaceholderPostDto>.Failure("Failed to deserialize post data.", 500);
                    }

                    return Result<JsonPlaceholderPostDto>.Success(post);
                }
                catch (HttpRequestException ex)
                {
                    return Result<JsonPlaceholderPostDto>.Failure($"External API error: {ex.Message}", 502);
                }
                catch (Exception ex)
                {
                    return Result<JsonPlaceholderPostDto>.Failure($"Server error: {ex.Message}", 500);
                }
            }
        }
    }
}
