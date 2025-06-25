using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace game_library_backend.Models;

public class GameModel
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly ReleaseDate { get; set; }
    [Precision(5, 2)]
    public decimal? Price { get; set; }
    public required string Developer { get; set; }
    public string? Image { get; set; }
    public required ICollection<GameGenreModel> GameGenres { get; set; }
}
