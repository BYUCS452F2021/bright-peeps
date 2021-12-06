namespace BrightPeeps.Data.MongoDB.Models
{
    public sealed class PeepData : Entry
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}