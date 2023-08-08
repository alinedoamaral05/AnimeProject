using System.ComponentModel.DataAnnotations;

namespace AnimeProject.Data.Request
{
    public class CreateAnimeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
