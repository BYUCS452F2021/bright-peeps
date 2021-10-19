namespace BrightPeeps.Core.Models
{
    public sealed class CreateUserRequest
    {
        public int PeepID { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}