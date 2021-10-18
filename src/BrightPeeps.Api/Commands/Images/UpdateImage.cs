using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Images
{
    public static class UpdateImage
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public ImageData Model { get; init; }
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
                    var result = await Data.ExecuteStoredProcedure<ImageData, ImageData>(
                        procedureId: "UpdateImage",
                        parameters: request.Model
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Data updated successfully.",
                        Result = result
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