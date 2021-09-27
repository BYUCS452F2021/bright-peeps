using System.Collections.Generic;

namespace BrightPeeps.Core.Models
{
    public partial class PersonData
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }

        public string FullName
            => string.IsNullOrEmpty(MiddleName)
                ? $"{FirstName} {LastName}"
                : $"{FirstName} {MiddleName} {LastName}";
    }
}