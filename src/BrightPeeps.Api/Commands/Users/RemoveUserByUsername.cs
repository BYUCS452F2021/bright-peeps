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
    public static class RemoveUserByUsername
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public string Username { get; init; }
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
                    await Data.Users.DeleteAsync(
                        new Data.MongoDB.Models.UserData
                        {
                            Username = request.Username
                        }
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