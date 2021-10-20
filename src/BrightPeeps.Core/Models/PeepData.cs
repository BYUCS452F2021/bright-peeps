namespace BrightPeeps.Core.Models
{
    public sealed class PeepData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}