using System.ComponentModel.DataAnnotations;

namespace AnimeProject.Data.Response
{
    public class ReadCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AnimeId { get; set; }
    }
}
