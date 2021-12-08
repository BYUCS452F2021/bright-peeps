using System.Linq;
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
    public static class RemovePeepById
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Request, CommandResponse>
        {
            private readonly MongoDBDataAccessService Data;
            private readonly ILogger<Handler> Logger;

            public Handler(MongoDBDataAccessService dataAccess, ILogger<Handler> logger)
            {
                Data = dataAccess;
                Logger = logger;
            }

            public async Task<CommandResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                try
                {
                    await Data.Peeps.DeleteAsync(id: request.Id);

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Peep removed successfully.",
                    };
                }
                catch (System.Exception e)
                {
                    Logger?.LogError($"Could not remove data from database. Error was {e}");

                    return new CommandResponse
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