using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Contracts.UseCases;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("chuck")]
    public class ChuckController : ControllerBase
    {

        private IGetCategories _getCategories;
        private IGetRandomJoke _getRandomJoke;

        public ChuckController(IGetRandomJoke getRandomJoke, IGetCategories getCategories)
        {
            _getRandomJoke = getRandomJoke;
            _getCategories = getCategories;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _getCategories.Handle());
        }

        [HttpGet("random/{category}")]
        public async Task<ChuckNorrisJoke> GetRandomJoke(string category)
        {
            return await _getRandomJoke.Handle(category);
        }
    }
}