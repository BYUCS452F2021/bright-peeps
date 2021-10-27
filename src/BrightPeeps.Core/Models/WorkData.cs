namespace BrightPeeps.Core.Models
{
    public sealed class WorkData
    {
        public int Id { get; init; }
        public int PeepID { get; init; }
        public string WorkType { get; init; }
        public string WorkDescription { get; init; }

        public string WorkUrl { get; init; }

        public string WorkTitle { get; init; }
    }
}