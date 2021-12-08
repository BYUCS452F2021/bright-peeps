using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Queries.Works
{
    public static class GetWorksByPeepId
    {
        public sealed class Request : IRequest<QueryResponse>
        {
            public string PeepId { get; set; }

            public Request(string peepId)
            {
                PeepId = peepId;
            }
        }

        public class Handler : IRequestHandler<Request, QueryResponse>
        {
            private readonly MongoDBDataAccessService Data;
            private readonly ILogger<Handler> Logger;

            public Handler(MongoDBDataAccessService dataAccess, ILogger<Handler> logger)
            {
                Data = dataAccess;
                Logger = logger;
            }

            public async Task<QueryResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                try
                {
                    var results = (await Data.Works.GetAllAsync())
                          .Where(w => w.PeepID.Equals(request.PeepId));

                    return new QueryResponse
                    {
                        Successful = true,
                        Message = "Data retrieved successfully.",
                        Result = results
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

