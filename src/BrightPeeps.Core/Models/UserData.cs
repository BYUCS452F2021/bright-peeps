namespace BrightPeeps.Core.Models
{
    public sealed class UserData
    {
        public int Id { get; init; }
        public int PeepID { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}