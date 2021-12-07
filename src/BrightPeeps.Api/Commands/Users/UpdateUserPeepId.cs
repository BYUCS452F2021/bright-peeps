using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Users
{
    public static class UpdatePeepId
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public UpdateUserPeepIdData Model { get; init; }
        }

        public class Handler : IRequestHandler<Request, CommandResponse>
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

            public async Task<CommandResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                try
                {
                    await Data.Users.UpdateAsync(
                        new Data.MongoDB.Models.UserData
                        {
                            Username = request.Model.Username,
                            PeepID = request.Model.PeepID,
                        }
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Data updated successfully.",
                    };
                }
                catch (System.Exception e)
                {
                    Logger?.LogError($"Could not update data into database. Error was {e}");

                    return new CommandResponse
                    {
                        Successful = false,
                        Message = "Could not update data into database. Check logs for more details.",
                        Result = default
                    };
                }
            }
        }
    }
}