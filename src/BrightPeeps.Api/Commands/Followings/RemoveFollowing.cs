using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Followings
{
    public static class RemoveFollowing
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public int FollowerId { get; set; }
            public int FolloweeId { get; set; }
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
                    var result = await Data.ExecuteStoredProcedure<dynamic, Request>(
                        procedureId: "RemoveFollowing",
                        parameters: request
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Data deleted successfully.",
                        Result = null
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