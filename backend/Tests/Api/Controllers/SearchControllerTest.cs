using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Api.Controllers;
using Api.Resource;
using Core.Contracts.UseCases;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests.Api.Controllers
{
    public class SearchControllerTest
    {

        [Fact]
        public async Task ShouldReturnWithGroupedResults()
        {
            var searchJokesMock = new Mock<ISearchJokes>();
            var searchCharsMock = new Mock<ISearchCharacters>();
            var query = "simon";

            searchCharsMock.Setup(usecase => usecase.Handle(query)).ReturnsAsync(
                new List<StarWarCharacter>{
                    new StarWarCharacter{
                        BirthYear = "Yeah",
                        Name= "RivZar",
                        EyeColor = "Blue"
                    }
                }
            );

            searchJokesMock.Setup(usecase => usecase.Handle(query)).ReturnsAsync(
                new List<ChuckNorrisJoke>{
                    new ChuckNorrisJoke{
                        Value="I am Chuck Norris"
                    }
                }
            );

            var searchController = new SearchController(searchJokesMock.Object, searchCharsMock.Object);

            var results = await searchController.Search(query);

            Assert.IsType<SearchResponseModel>(results);

            Assert.Equal(1, results.Swapi.Count(item => item.Name.ToLower() == "rivzar"));
            Assert.Equal(1, results.Chuck.Count(item => item.Value == "I am Chuck Norris"));
        }
    }
}