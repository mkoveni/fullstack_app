using System;
using System.Threading.Tasks;
using Core.Contracts.Repositories;
using Core.Contracts.UseCases;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Core.UseCases
{
    public class GetRandomJoke : IGetRandomJoke
    {
        IChuckRepository _chuckRepository;

        private ILogger _logger;
        public GetRandomJoke(IChuckRepository chuckRepository, ILogger<GetRandomJoke> logger)
        {
            _chuckRepository = chuckRepository;
        }
        public async Task<ChuckNorrisJoke> Handle(string category)
        {
            ChuckNorrisJoke joke = null;

            try
            {
                joke = await _chuckRepository.GetRandomJokeFromCategory(category);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }

            return joke;

        }
    }
}