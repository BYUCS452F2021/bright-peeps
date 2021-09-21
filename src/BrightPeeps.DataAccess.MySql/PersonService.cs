using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;

namespace BrightPeeps.DataAccess.MySql
{
    public sealed class PersonService : IDaoService<Person>
    {
        private ISqlDataAccessService DataAccessService;
        private PersonSearchService SearchService;

        public async Task Configure(ISqlDataAccessService dataAccessService, string searchDirectory)
        {
            DataAccessService = dataAccessService;
            SearchService = new PersonSearchService(
                personSearchDirectory: searchDirectory
            );

            await SearchService.Initialize(await GetAllPersonsAsSummaries());
        }

        public Task<IEnumerable<Person>> All()
        {
            // TODO: Execute a query to retrieve all persons from the database.
            throw new NotImplementedException();
        }

        public Task Delete(string personId)
        {
            // TODO: Execute a command to delete the person with the given id from the database.
            throw new NotImplementedException();
        }

        public Task<Person> GetOne(string personId)
        {
            // TODO: Execute a query to retrieve the person with the given id from the database.
            throw new NotImplementedException();
        }

        public Task<Person> Insert(Person person)
        {
            // TODO: Execute a command to insert the person object into the database.
            throw new NotImplementedException();
        }

        public Task<Person> Search(string query)
        {
            // TODO: Use the search service to perform a search with the given query.
            throw new NotImplementedException();
        }

        public Task<Person> Update(Person person)
        {
            // TODO: Execute a command to update the person object with the given id in the database.
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<Person>> GetAllPersonsAsSummaries()
        {
            // TODO: Execute a query to get all Persons once schema is set.
            // return await DataAccessService.ExecuteQuery<Person, dynamic>(
            //     query: "SELECT p.id, p.firstName, p.middleName, p.lastName, p.shortDescription, i.url FROM Person AS p JOIN ImageData AS i ON (p.id = i.userId);",
            //     parameters: new { }
            // );
            await Task.Delay(10);

            return new List<Person>();
        }
    }
}
