using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Peeps
{
    public static class InsertPeep
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string ShortDescription { get; set; }
            public string LongDescription { get; set; }

            /*
            TODO: Fix me
            */
            public static Request FromUserData(CreateUserRequest model)
                => new Request
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription
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
                    var result = await Data.ExecuteStoredProcedure<PersonProfile, dynamic>(
                        procedureId: "AddPeep",
                        parameters: request
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Peep inserted successfully.",
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