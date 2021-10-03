using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Queries
{
    public static class TestDatabaseConnection
    {
        public sealed class Request : IRequest<QueryResponse> { }

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
                    await Data.TestConnection();

                    return new QueryResponse
                    {
                        Successful = true,
                        Message = "Connection is working properly.",
                        Result = null
                    };
                }
                catch (System.Exception e)
                {
                    Logger?.LogError($"Could not connect to database. Error was {e}");

                    return new QueryResponse
                    {
                        Successful = false,
                        // Message = "Could not connect to database. Check logs for more details.",
                        Message = e.ToString(),
                        Result = default
                    };
                }
            }
        }
    }
}