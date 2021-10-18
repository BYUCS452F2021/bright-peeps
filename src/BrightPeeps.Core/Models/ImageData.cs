namespace BrightPeeps.Core.Models
{
    public partial class ImageData
    {
        public int Id { get; set; }
        public int PeepId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public bool IsProfile { get; set; }
    }
}