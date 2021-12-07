namespace BrightPeeps.Core.Models
{
    public sealed class CreateUserRequest
    {
        public string PeepID { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}