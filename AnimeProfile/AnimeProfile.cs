using AnimeProject.Data.Request;
using AnimeProject.Data.Response;
using AnimeProject.Models;
using AutoMapper;

namespace AnimeProject.AnimeProfile
{
    public class AnimeProfile: Profile
    {
        public AnimeProfile()
        {
            CreateMap<CreateAnimeDto, Anime>();
            CreateMap<Anime, ReadAnimeDto>();
            CreateMap<UpdateAnimeDto, Anime>();
            CreateMap<CreateCharacterDto, Character>();
            CreateMap<Character, ReadCharacterDto>();
            CreateMap<UpdateCharacterDto, Character>();
        }
    }
}
