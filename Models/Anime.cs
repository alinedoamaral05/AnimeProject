using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnimeProject.Models;

public class Anime
{
    [Required]
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime ReleaseYear { get; set; }
    [JsonIgnore]
    public ICollection<Character> Characters { get; set; }

    public Anime()
    {
        Characters = new List<Character>();
    }
}
