using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Contracts.Repositories;
using Core.Contracts.UseCases;
using Microsoft.Extensions.Logging;

namespace Core.UseCases
{
    public class GetCategories : IGetCategories
    {
        private IChuckRepository _chuckRepository;

        private ILogger _logger;
        public GetCategories(IChuckRepository chuckRepository, ILogger<GetCategories> logger)
        {
            _chuckRepository = chuckRepository;
            _logger = logger;
        }

        public async Task<List<string>> Handle()
        {
            List<string> categories = new List<string>();

            try
            {
                categories = await _chuckRepository.GetCategories();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }

            return categories;
        }
    }
}