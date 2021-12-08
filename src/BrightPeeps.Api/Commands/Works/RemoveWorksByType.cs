using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Works
{
    public static class RemoveWorksByType
    {
        public sealed class Request : IRequest<QueryResponse>
        {
            public string Type { get; set; }

            public Request(string type)
            {
                Type = type;
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
                    var toDelete = (await Data.Works.GetAllAsync())
                       .Where(w => w.WorkType.Equals(request.Type));

                    foreach (var work in toDelete)
                    {
                        await Data.Works.DeleteAsync(work.Id);
                    }

                    return new QueryResponse
                    {
                        Successful = true,
                        Message = "Data retrieved successfully."
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
