namespace BrightPeeps.Data.MongoDB.Models
{
    public sealed class UserData : Entry
    {
        public string PeepID { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}