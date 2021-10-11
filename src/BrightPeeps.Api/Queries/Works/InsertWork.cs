using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Queries.Works {
    public static class InsertWork {
        public sealed class Request : IRequest<QueryResponse> {
            public int PeepId;
            public string WorkType;
            public string WorkDesc;
            public string WorkUrl;
            public string WorkTitle;

            public Request(int peepId, string workType, string workDesc, string workUrl, string workTitle) {
                this.PeepId = peepId;
                this.WorkType = workType;
                this.WorkDesc = workDesc;
                this.WorkUrl = workUrl;
                this.WorkTitle = workTitle;
            }
        }

        public class Handler : IRequestHandler<Request, QueryResponse> {
            private readonly ISqlDataAccessService Data;
            private readonly ILogger<Handler> Logger;

            public Handler(ISqlDataAccessService dataAccess, ILogger<Handler> logger) {
                Data = dataAccess;
                Logger = logger;
            }

            public async Task<QueryResponse> Handle(Request request, CancellationToken cancellationToken) {
                try {
                    var results = await Data.ExecuteStoredProcedure<PersonProfile, dynamic>(
                        procedureId: "InsertWork",
                        parameters: (request.PeepId, request.WorkType, request.WorkDesc, request.WorkUrl, request.WorkTitle)
                    );

                    return new QueryResponse {
                        Successful = true,
                        Message = "Data retrieved successfully.",
                        Result = results
                    };
                } catch (System.Exception e) {
                    Logger?.LogError($"Could not retrieve data from database. Error was {e}");

                    return new QueryResponse {
                        Successful = false,
                        Message = "Could not retrieve data from database. Check logs for more details.",
                        Result = default
                    };
                }
            }
        }
    }
}

