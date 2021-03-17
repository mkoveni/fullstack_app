using System.Collections.Generic;
using Core.Entities;

namespace Api.Resource
{
    public class SearchResponseModel
    {
        public List<ChuckNorrisJoke> Chuck { get; set; }
        public List<StarWarCharacter> Swapi { get; set; }
    }
}