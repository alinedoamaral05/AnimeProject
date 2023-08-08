using AnimeProject.Models;
using System.ComponentModel.DataAnnotations;

namespace AnimeProject.Data.Response
{
    public class ReadAnimeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
