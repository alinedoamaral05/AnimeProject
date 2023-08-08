using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnimeProject.Models;

public class Character
{
    [Required]
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public int AnimeId { get; set; }
    [JsonIgnore]
    public Anime Anime { get; set; }
}
