using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Queries.Works
{
    public static class GetWorksByType
    {
        public sealed class Request : IRequest<QueryResponse> {
            public string Type {get; set;}

            public Request(string type) {
                this.Type = type;
            }
        }

        public class Handler : IRequestHandler<Request, QueryResponse>
        {
            private readonly ISqlDataAccessService Data;
            private readonly ILogger<Handler> Logger;

            public Handler(ISqlDataAccessService dataAccess, ILogger<Handler> logger)
            {
                Data = dataAccess;
                Logger = logger;
            }

            public async Task<QueryResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                try
                {
                    var results = await Data.ExecuteStoredProcedure<WorkData, Request>(
                        procedureId: "GetWorksByType",
                        parameters: request
                    );

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