using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Images
{
    public static class RemoveImagesByPeepId
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public string PeepId { get; init; }
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
                    // Mongo Driver parses the json we pass here and deletes all images that match
                    // the definition.
                    await Data.Images.Collection.DeleteManyAsync(
                        filter: $"{{ peepId : '{request.PeepId}' }}"
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Data deleted successfully.",
                    };
                }
                catch (System.Exception e)
                {
                    Logger?.LogError($"Could not delete data from database. Error was {e}");

                    return new CommandResponse
                    {
                        Successful = false,
                        Message = "Could not delete data from database. Check logs for more details.",
                        Result = default
                    };
                }
            }
        }
    }
}