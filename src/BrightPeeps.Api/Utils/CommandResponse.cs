namespace BrightPeeps.Api.Utils
{
    public sealed class CommandResponse
    {
        public bool Successful { get; init; }
        public string Message { get; init; }
        public dynamic Result { get; init; }
    }
}