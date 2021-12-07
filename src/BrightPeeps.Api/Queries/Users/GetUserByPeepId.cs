using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Queries.Users
{
    public static class GetUserByPeepId
    {
        public sealed class Request : IRequest<QueryResponse>
        {
            public string PeepID { get; set; }
        }

        public class Handler : IRequestHandler<Request, QueryResponse>
        {
           // Change the property to use MongoDBDataAccessService
            private readonly MongoDBDataAccessService Data;
            private readonly ILogger<Handler> Logger;

            // Change the Dependency Injection Service you subscribe to
            public Handler(MongoDBDataAccessService dataAccess, ILogger<Handler> logger)
            {
                Data = dataAccess;
                Logger = logger;
            }

            public async Task<QueryResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                try
                {
                    var results = await Data.Users.GetAllAsync();

                    foreach(var result in results)
                    {
                        if (result.PeepID == request.PeepID)
                        {
                            return new QueryResponse
                            {
                                Successful = true,
                                Message = "Data retrieved successfully.",
                                Result = result
                            };
                        }
                    }

                    return new QueryResponse
                    {
                        Successful = false,
                        Message = "Data not retrieved successfully.",
                    };
                }
                catch (System.Exception e)
                {
                    Logger?.LogError($"Could not retrieve data from database. Error was {e}");

                    return new QueryResponse
                    {
                        Successful = false,
                        Message = "Could not retrieve data from database. Check logs for more details.",
                        Result = default
                    };
                }
            }
        }
    }
}