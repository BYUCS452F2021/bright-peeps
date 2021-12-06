namespace BrightPeeps.Data.MongoDB.Models
{
    public partial class ImageData : Entry
    {
        public string PeepId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public bool IsProfile { get; set; }
    }
}