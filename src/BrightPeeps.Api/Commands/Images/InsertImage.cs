using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Images
{
    public static class InsertImage
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public int PeepId { get; set; }
            public string Title { get; set; }
            public string ImageUrl { get; set; }
            public string Caption { get; set; }
            public bool IsProfile { get; set; }

            public static Request FromImageData(ImageData model)
                => new Request
                {
                    PeepId = model.PeepId,
                    Title = model.Title,
                    ImageUrl = model.ImageUrl,
                    Caption = model.Caption,
                    IsProfile = model.IsProfile
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
                        procedureId: "InsertImage",
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