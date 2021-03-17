using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Contracts.Repositories;
using Core.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class SwapiRepository : ISwapiRepository
    {
        private HttpClient _httpClient;

        private IMapper _mapper;


        public SwapiRepository(HttpClient client, IMapper mapper)
        {
            _httpClient = client;
            _mapper = mapper;
        }

        public async Task<List<StarWarCharacter>> GetPeople()
        {
            SwapiCollectionResponse response = await _httpClient.GetFromJsonAsync<SwapiCollectionResponse>("/api/people/");

            return _mapper.Map<List<SwapiCharacter>, List<StarWarCharacter>>(response.Results);
        }

        public async Task<List<StarWarCharacter>> Search(string query)
        {
            SwapiCollectionResponse response = await _httpClient.GetFromJsonAsync<SwapiCollectionResponse>($"/api/people/?search={query}");

            return _mapper.Map<List<SwapiCharacter>, List<StarWarCharacter>>(response.Results);
        }
    }
}