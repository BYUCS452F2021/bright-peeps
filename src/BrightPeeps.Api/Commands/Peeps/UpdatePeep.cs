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
    public static class UpdatePeep
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string ShortDescription { get; set; }
            public string LongDescription { get; set; }

            public static Request FromPersonData(PersonData model)
            {
                return new Request
                {
                    Id = model.Id,
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
                    var result = await Data.ExecuteStoredProcedure<PersonData, Request>(
                        procedureId: "UpdatePeep",
                        parameters: request
                    );

                    return new CommandResponse
                    {
                        Successful = true,
                        Message = "Peep updated successfully.",
                        Result = result
                    };
                }
                catch (System.Exception e)
                {
                    Logger?.LogError($"Could not update data in database. Error was {e}");

                    return new CommandResponse
                    {
                        Successful = false,
                        Message = "Could not update data in database. Check logs for more details.",
                        Result = default
                    };
                }
            }
        }
    }
}