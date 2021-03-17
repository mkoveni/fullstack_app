using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Contracts.Repositories;
using Core.Contracts.UseCases;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Core.UseCases
{
    public class SearchJokes : ISearchJokes
    {
        private IChuckRepository _chuckRepository;

        private ILogger _logger;

        public SearchJokes(IChuckRepository chuckRepository, ILogger<SearchJokes> logger)
        {
            _chuckRepository = chuckRepository;
            _logger = logger;
        }
        public async Task<List<ChuckNorrisJoke>> Handle(string query)
        {
            List<ChuckNorrisJoke> jokes = new List<ChuckNorrisJoke>();

            try
            {
                jokes = await _chuckRepository.SearchJokes(query);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }

            return jokes;
        }
    }
}