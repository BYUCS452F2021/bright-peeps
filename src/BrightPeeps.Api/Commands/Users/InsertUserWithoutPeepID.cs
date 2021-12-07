using System.Linq;
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
    public static class InsertUserWithoutPeepID
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public static Request FromUserData(CreateUserRequest model)
                => new Request
                {
                    Username = model.Username,
                    Password = model.Password
                };
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
                    await Data.Users.InsertAsync(
                        new Data.MongoDB.Models.UserData
                        {
                            Username = request.Username,
                            Password = request.Password
                        }
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Data inserted successfully.",
                    };
                }
                catch (System.Exception e)
                {
                    Logger?.LogError($"Could not insert data into database. Error was {e}");

                    return new CommandResponse
                    {
                        Successful = false,
                        Message = "Could not insert data into database. Check logs for more details.",
                        Result = default
                    };
                }
            }
        }
    }
}