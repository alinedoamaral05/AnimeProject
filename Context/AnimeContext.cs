using AnimeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeProject.Context
{
    public class AnimeContext: DbContext
    {   
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Character> Characters { get; set; }

        public AnimeContext(DbContextOptions<AnimeContext> options): base(options) { }
    }
}
