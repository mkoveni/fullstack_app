using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Contracts.Repositories;
using Core.Contracts.UseCases;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Core.UseCases
{
    public class SearchCharacters : ISearchCharacters
    {
        ISwapiRepository _swapiRepository;

        private ILogger _logger;
        public SearchCharacters(ISwapiRepository swapiRepository, ILogger<SearchCharacters> logger)
        {
            _swapiRepository = swapiRepository;
            _logger = logger;
        }
        public async Task<List<StarWarCharacter>> Handle(string query)
        {
            List<StarWarCharacter> characters = new List<StarWarCharacter>();

            try
            {
                characters = await _swapiRepository.Search(query);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }

            return characters;

        }
    }
}