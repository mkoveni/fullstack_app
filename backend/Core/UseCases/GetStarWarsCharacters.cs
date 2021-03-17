using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Contracts.Repositories;
using Core.Contracts.UseCases;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Core.UseCases
{
    public class GetStarWarsCharacters : IGetStarWarsCharacters
    {
        ISwapiRepository _swapiRepository;
        private ILogger _logger;
        public GetStarWarsCharacters(ISwapiRepository swapiRepository, ILogger<GetStarWarsCharacters> logger)
        {
            _swapiRepository = swapiRepository;
            _logger = logger;
        }
        public async Task<List<StarWarCharacter>> Handle()
        {
            List<StarWarCharacter> characters = new List<StarWarCharacter>();

            try
            {
                characters = await _swapiRepository.GetPeople();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }

            return characters;
        }
    }
}