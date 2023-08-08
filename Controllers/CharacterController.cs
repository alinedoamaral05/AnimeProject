using AnimeProject.Context;
using AnimeProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimeProject.Controllers
{
    [ApiController]
    [Route("personagens")]
    public class CharacterController : ControllerBase
    {
        private readonly AnimeContext _context;
        private IMapper _mapper;
        public CharacterController(AnimeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
/*
GET / animes /{ animeId}/ personagens: Retorna todos os personagens de um anime específico
GET /animes/{animeId}/ personagens /{ id}: Retorna um personagem específico de um anime
POST /animes/{animeId}/ personagens: Adiciona um novo personagem a um anime específico
PUT /animes/{animeId}/ personagens /{ id}: Atualiza um personagem de um anime específico
DELETE /animes/{animeId}/ personagens /{ id}: Exclui um personagem de um anime específico
*/