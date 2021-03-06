using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.LuceneSearch.Extensions;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace BrightPeeps.Data.LuceneSearch
{
    public sealed class PersonSearchService : ISearchService<PersonProfile>
    {
        private const LuceneVersion MatchVersion = LuceneVersion.LUCENE_48;

        private readonly Analyzer Analyzer;
        private readonly Directory PersonDirectory;
        private readonly IndexWriter PersonWriter;

        public PersonSearchService(string personSearchDirectory)
        {
            Analyzer = new StandardAnalyzer(MatchVersion);

            PersonDirectory = FSDirectory.Open(personSearchDirectory);

            PersonWriter = new IndexWriter(
                d: PersonDirectory,
                conf: new IndexWriterConfig(
                    matchVersion: MatchVersion,
                    analyzer: Analyzer
                )
            );
        }

        ~PersonSearchService()
        {
            PersonDirectory.Dispose();
            PersonWriter.Dispose();
        }

        public async Task Initialize(IEnumerable<PersonProfile> persons)
        {
            await AddManyAsync(persons);
        }

        public void AddOne(PersonProfile person)
        {
            var document = person.ToDocument();
            PersonWriter.AddDocument(document);

            PersonWriter.Flush(
                triggerMerge: false,
                applyAllDeletes: false
            );
        }

        public Task AddOneAsync(PersonProfile person)
        {
            AddOne(person);

            return Task.CompletedTask;
        }

        public void AddMany(IEnumerable<PersonProfile> persons)
        {
            var documents = persons.Select(Person => Person.ToDocument());
            PersonWriter.AddDocuments(documents);

            PersonWriter.Flush(
                 triggerMerge: false,
                 applyAllDeletes: false
            );
        }

        public Task AddManyAsync(IEnumerable<PersonProfile> persons)
        {
            AddMany(persons);

            return Task.CompletedTask;
        }

        public void Update(PersonProfile person)
        {
            PersonWriter.UpdateDocument(new Term("id", person.Id.ToString()), person.ToDocument());

            PersonWriter.Flush(
                triggerMerge: false,
                applyAllDeletes: true
            );
        }

        public Task UpdateAsync(PersonProfile person)
        {
            Update(person);

            return Task.CompletedTask;
        }

        public void DeleteOne(string personId)
        {
            PersonWriter.DeleteDocuments(new Term("id", personId));

            PersonWriter.Flush(
                triggerMerge: false,
                applyAllDeletes: true
            );
        }

        public Task DeleteOneAsync(string personId)
        {
            DeleteOne(personId);

            return Task.CompletedTask;
        }

        public void DeleteAll()
        {
            PersonWriter.DeleteAll();

            PersonWriter.Flush(
                triggerMerge: false,
                applyAllDeletes: true
            );
        }

        public Task DeleteAllAsync()
        {
            DeleteAll();

            return Task.CompletedTask;
        }

        public IEnumerable<SearchResultData> Search(string queryString,
            int maxResultsCount = 20)
        {
            var personReader = PersonWriter.GetReader(applyAllDeletes: true);
            var indexSearcher = new IndexSearcher(personReader);

            var hits = new List<ScoreDoc>();

            hits.AddRange(SearchField(
                searcher: in indexSearcher,
                field: "name",
                query: queryString,
                maxResultsCount: maxResultsCount
            ));

            return hits.Select(hit =>
            {
                var document = indexSearcher.Doc(hit.Doc);
                return new SearchResultData
                {
                    Id = document.Get("id"),
                    Title = document.Get("name"),
                    ImageUrl = document.Get("profilePictureUrl"),
                    ShortDescription = document.Get("shortDescription"),
                };
            });
        }

        public Task<IEnumerable<SearchResultData>> SearchAsync(string queryString,
            int maxResultsCount = 20)
        {
            return Task.FromResult(Search(queryString));
        }

        private IEnumerable<ScoreDoc> SearchField(in IndexSearcher searcher, string field,
            string query, int maxResultsCount)
        {
            return new List<ScoreDoc>(searcher.Search(
               query: (new QueryParser(MatchVersion, field, Analyzer)).Parse(query),
               n: maxResultsCount
            ).ScoreDocs.OrderBy(d => d.Score));
        }
    }
}
