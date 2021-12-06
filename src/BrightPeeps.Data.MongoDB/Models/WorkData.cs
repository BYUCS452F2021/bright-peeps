namespace BrightPeeps.Data.MongoDB.Models
{
    public sealed class WorkData : Entry
    {
        public string PeepID { get; init; }
        public string WorkType { get; init; }
        public string WorkDescription { get; init; }
        public string WorkUrl { get; init; }
        public string WorkTitle { get; init; }
    }
}