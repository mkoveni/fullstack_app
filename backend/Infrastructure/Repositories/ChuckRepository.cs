using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Core.Contracts.Repositories;
using Core.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{

    public class ChuckRepository : IChuckRepository
    {
        private HttpClient _httpClient;

        private IMapper _mapper;

        public ChuckRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<string>> GetCategories()
        {
            List<string> categories = await _httpClient.GetFromJsonAsync<List<string>>("/jokes/categories");

            return categories;
        }

        public async Task<List<ChuckNorrisJoke>> SearchJokes(string query)
        {
            ChuckSearchResponse response = await _httpClient.GetFromJsonAsync<ChuckSearchResponse>($"/jokes/search?query={query}");

            return _mapper.Map<List<ChuckJoke>, List<ChuckNorrisJoke>>(response.Results);
        }

        public async Task<ChuckNorrisJoke> GetRandomJokeFromCategory(string category)
        {
            ChuckJoke joke = await _httpClient.GetFromJsonAsync<ChuckJoke>($"/jokes/random?category={category}");

            return _mapper.Map<ChuckJoke, ChuckNorrisJoke>(joke);

        }
    }
}