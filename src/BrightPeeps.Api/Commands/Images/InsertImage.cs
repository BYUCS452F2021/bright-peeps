using System.Linq;
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
    public static class InsertImage
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public string PeepId { get; set; }
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
                    // Unfortunately, you will need to initialize the MongoDB version of the data
                    // you are trying to pass in like this. Tedious, but what can you do. 
                    await Data.Images.InsertAsync(
                        new Data.MongoDB.Models.ImageData
                        {
                            PeepId = request.PeepId.ToString(),
                            Title = request.Title,
                            ImageUrl = request.ImageUrl,
                            Caption = request.Caption,
                            IsProfile = request.IsProfile
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