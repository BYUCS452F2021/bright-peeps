using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Works {
    public static class UpdateWork {
        public sealed class Request : IRequest<QueryResponse> {
            public int Id { get; set; }
            public int PeepId { get; set; }
            public string WorkType { get; set; }
            public string WorkDesc { get; set; }
            public string WorkUrl { get; set; }
            public string WorkTitle { get; set; }

            public Request(int id, int peepId, string type, string desc, string url, string title) {
                Id = id;
                PeepId = peepId;
                WorkType = type;
                WorkDesc = desc;
                WorkUrl = url;
                WorkTitle = title;
            }
        }

        public class Handler : IRequestHandler<Request, QueryResponse> {
            private readonly MongoDBDataAccessService Data;
            private readonly ILogger<Handler> Logger;

            public Handler(MongoDBDataAccessService dataAccess, ILogger<Handler> logger) {
                Data = dataAccess;
                Logger = logger;
            }

            public async Task<QueryResponse> Handle(Request request, CancellationToken cancellationToken) {
                try {
                    await Data.Works.UpdateAsync(
                        new BrightPeeps.Data.MongoDB.Models.WorkData
                        {
                            Id = request.Id.ToString(),
                            PeepID = request.PeepId.ToString(),
                            WorkType = request.WorkType,
                            WorkDescription = request.WorkDesc,
                            WorkUrl = request.WorkUrl,
                            WorkTitle = request.WorkTitle
                        }
                    );

                    return new QueryResponse {
                        Successful = true,
                        Message = "Data retrieved successfully."
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

