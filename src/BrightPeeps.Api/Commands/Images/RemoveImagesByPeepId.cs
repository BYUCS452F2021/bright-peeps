using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using BrightPeeps.Data.MongoDB.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

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
                    var toDelete = (await Data.Images.GetAllAsync())
                       .Where(i => i.PeepId.Equals(request.PeepId));

                    foreach (var img in toDelete)
                    {
                        await Data.Images.DeleteAsync(img.Id);
                    }

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