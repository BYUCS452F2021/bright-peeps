using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Peeps
{
    public static class RemoveAllPeeps
    {
        public sealed class Request : IRequest<QueryResponse> { }

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
                    await Data.Peeps.Collection.DeleteMany();

                    return new QueryResponse
                    {
                        Successful = true,
                        Message = "Data removed successfully.",
                    };
                }
                catch (System.Exception e)
                {
                    Logger?.LogError($"Could not remove data from database. Error was {e}");

                    return new QueryResponse
                    {
                        Successful = false,
                        Message = "Could not remove data from database. Check logs for more details.",
                        Result = default
                    };
                }
            }
        }
    }
}