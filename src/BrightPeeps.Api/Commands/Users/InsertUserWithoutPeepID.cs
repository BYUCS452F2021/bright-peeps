using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
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
            private readonly ISqlDataAccessService Data;
            private readonly ILogger<Handler> Logger;

            public Handler(ISqlDataAccessService dataAccess, ILogger<Handler> logger)
            {
                Data = dataAccess;
                Logger = logger;
            }

            public async Task<CommandResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await Data.ExecuteStoredProcedure<ImageData, Request>(
                        procedureId: "AddUserWithoutPeepID",
                        parameters: request
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Data inserted successfully.",
                        Result = result
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