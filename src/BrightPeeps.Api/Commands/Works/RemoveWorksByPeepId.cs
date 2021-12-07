﻿using System.Threading;
using System.Threading.Tasks;
using BrightPeeps.Api.Utils;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrightPeeps.Api.Commands.Works {
    public static class RemoveWorksByPeepId {
        public sealed class Request : IRequest<QueryResponse> {
            public int PeepId { get; set; }

            public Request(int peepId) {
                this.PeepId = peepId;
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
                    await Data.Works.Collection.DeleteManyAsync(
                        filter: $"{{ peepId : '{request.PeepId.ToString()}' }}"
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

