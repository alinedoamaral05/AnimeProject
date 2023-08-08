using AnimeProject.Models;
using System.ComponentModel.DataAnnotations;

namespace AnimeProject.Data.Request
{
    public class CreateCharacterDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
