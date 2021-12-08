using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Peeps
{
    public static class InsertPeep
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string ShortDescription { get; set; }
            public string LongDescription { get; set; }

            public static Request FromPersonData(PersonData model)
            {
                return new Request
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription,
                };
            }
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
                    // Unfortunately, you will need to initialize the MongoDB version of the data
                    // you are trying to pass in like this. Tedious, but what can you do. 
                    await Data.Peeps.InsertAsync(
                        new Data.MongoDB.Models.PeepData
                        {
                            FirstName = request.FirstName,
                            MiddleName = request.MiddleName,
                            LastName = request.LastName,
                            ShortDescription = request.ShortDescription,
                            LongDescription = request.LongDescription
                        }
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Peep inserted successfully.",
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