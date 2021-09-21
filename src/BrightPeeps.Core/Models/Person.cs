using System.Collections.Generic;

namespace BrightPeeps.Core.Models
{
    public partial class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public ImageData ProfilePicture { get; set; }
        public IEnumerable<Accomplishment> Accomplishments { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }
        public IEnumerable<Work> Works { get; set; }

        public string FullName
            => string.IsNullOrEmpty(MiddleName)
                ? $"{FirstName} {LastName}"
                : $"{FirstName} {MiddleName} {LastName}";
    }
}