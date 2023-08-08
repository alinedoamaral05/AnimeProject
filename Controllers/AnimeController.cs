using AnimeProject.Context;
using AnimeProject.Data.Request;
using AnimeProject.Data.Response;
using AnimeProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeProject.Controllers;

[ApiController]
[Route("animes")]
public class AnimeController : ControllerBase
{
    private readonly AnimeContext _context;
    private IMapper _mapper;
    public AnimeController(AnimeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAnimes()
    {
        var animes = _mapper.Map<List<ReadAnimeDto>>(_context.Animes.ToList());
        return Ok(animes);
    }
    [HttpGet("{animeId}")]
    public IActionResult GetAnimeById(int animeId)
    {
        var anime = _context.Animes
            .FirstOrDefault(anime => anime.Id == animeId);
        if (anime == null) return NotFound();

        var readAnime = _mapper.Map<ReadAnimeDto>(anime);
        return Ok(readAnime);
    }
    [HttpPost]
    public IActionResult PostAnime([FromBody] CreateAnimeDto dto)
    {
        Anime anime = _mapper.Map<Anime>(dto);
        _context.Animes.Add(anime);
        _context.SaveChanges();
        return Ok(anime);
    }
    [HttpPut("{animeId}")]
    public IActionResult UpdateAnime(int animeId, [FromBody] UpdateAnimeDto dto)
    {
        var anime = _context.Animes
            .FirstOrDefault(anime => anime.Id == animeId);
        if (anime == null) return NotFound();

        _mapper.Map(anime, dto);

        _context.Animes.Update(anime);
        _context.SaveChanges();

        return Ok(anime);
    }
    [HttpDelete("{animeId}")]
    public IActionResult DeleteAnime(int animeId)
    {
        var anime = _context.Animes
            .FirstOrDefault(anime => anime.Id == animeId);
        if (anime == null) return NotFound();

        _context.Animes.Remove(anime);

        return Ok();
    }

    [HttpGet("{animeId}/characters")]
    public IActionResult GetAnimeCharacters(int animeId)
    {
        var anime = _context.Animes
            .Include(anime => anime.Characters)
            .FirstOrDefault(anime => anime.Id == animeId);
        if (anime == null) return NotFound();

        var charList = anime.Characters.ToList();
        var animeCharactersList = _mapper.Map<List<ReadCharacterDto>>(charList);

        return Ok(animeCharactersList);
    }
    [HttpGet("{animeId}/characters/{charId}")]
    public IActionResult GetAnimesCharacter(int animeId, int charId)
    {
        var anime = _context.Animes
            .Include(anime => anime.Characters)
            .FirstOrDefault(anime => anime.Id == animeId);
        if (anime == null) return NotFound();

        var character = anime.Characters
            .FirstOrDefault(character => character.Id == charId);
        if (character == null) return NotFound();

        var animeCharacter = _mapper.Map<ReadCharacterDto>(character);

        return Ok(animeCharacter);
    }

    [HttpPost("{animeId}/characters")]
    public IActionResult PostCharacterToAnime(int animeId, [FromBody] CreateCharacterDto dto)
    {
        try
        {
            var anime = _context.Animes
                .Include(anime => anime.Characters)
                .FirstOrDefault(anime => anime.Id == animeId);
            if (anime == null) return NotFound();

            Character character = _mapper.Map<Character>(dto);

            anime.Characters.Add(character);
            _context.SaveChanges();

            return Ok(character);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{animeId}/personagens/{charId}")]
    public IActionResult UpdateCharacterFromAnime(int animeId, int charId, [FromBody] UpdateCharacterDto dto)
    {
        try
        {
            var anime = _context.Animes
                .Include(anime => anime.Characters)
                .FirstOrDefault(anime => anime.Id == animeId);
            if (anime == null) return NotFound();

            var character = anime.Characters
                .FirstOrDefault(character => character.Id == charId);
            if (character == null) return NotFound();

            _mapper.Map(dto, character);

            _context.Characters.Update(character);
            _context.SaveChanges();

            return Ok(character);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{animeId}/personagens/{charId}")]
    public IActionResult DeleteCharacterFromAnime(int animeId, int charId)
    {
        var anime = _context.Animes
                .Include(anime => anime.Characters)
                .FirstOrDefault(anime => anime.Id == animeId);
        if (anime == null) return NotFound();

        var character = anime.Characters
            .FirstOrDefault(character => character.Id == charId);
        if (character == null) return NotFound();

        _context.Characters.Remove(character);
        _context.SaveChanges();

        return Ok();
    }
}