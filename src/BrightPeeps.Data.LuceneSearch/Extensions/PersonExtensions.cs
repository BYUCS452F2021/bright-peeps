using BrightPeeps.Core.Models;
using Lucene.Net.Documents;

namespace BrightPeeps.Data.LuceneSearch.Extensions
{
    public static class PersonExtensions
    {
        public static Document ToDocument(this Person model)
        {
            // TODO: Define what data needs to be indexed per Person model for searching purposes.
            return new Document
            {
                new TextField(
                    name: "id",
                    value: model.Id,
                    store: Field.Store.YES
                ),
                new TextField(
                    name: "name",
                    value: model.FullName,
                    store: Field.Store.YES
                ),
                new TextField(
                    name: "profilePictureUrl",
                    value: model.ProfilePicture.ImageUrl,
                    store: Field.Store.YES
                ),
                new TextField(
                    name: "shortDescription",
                    value: model.ShortDescription,
                    store: Field.Store.YES
                ),
            };
        }
    }
}