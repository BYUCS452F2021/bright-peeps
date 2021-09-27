using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Persons
{
    public static class InsertPerson
    {
        public sealed class Request : IRequest<CommandResponse>
        {
            public PersonProfile Model { get; init; }
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
                var response = await Data.ExecuteStoredProcedure<string, PersonProfile>(
                    procedureId: "insertPerson",
                    parameters: request.Model
                );

                request.Model.Id = response.ToList().FirstOrDefault() ?? "-1";

                return new CommandResponse
                {
                    Successful = true,
                    Message = "Command executed successfully.",
                    Result = request.Model
                };
            }
        }
    }
}