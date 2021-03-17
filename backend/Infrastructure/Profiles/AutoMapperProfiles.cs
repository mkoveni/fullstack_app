using AutoMapper;
using Core.Entities;
using Infrastructure.Models;

namespace Infrastructure.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ChuckJoke, ChuckNorrisJoke>();
            CreateMap<SwapiCharacter, StarWarCharacter>();
        }
    }
}