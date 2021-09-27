using System.Collections.Generic;

namespace BrightPeeps.Core.Models
{
    public partial class PersonProfile
    {
        public PersonData Data { get; set; }
        public ImageData ProfilePicture { get; set; }
        public IEnumerable<Accomplishment> Accomplishments { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }
        public IEnumerable<Work> Works { get; set; }

        public string FullName => Data?.FullName;
        public string Id
        {
            get => Data.Id;
            set => Data.Id = value;
        }
        public string ShortDescription
        {
            get => Data.ShortDescription;
        }

    }
}