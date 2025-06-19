using System.ComponentModel.DataAnnotations;

namespace game_library_backend.Models;

public class GameModel
{
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public required List<string> Genres { get; set; }
    public decimal Price { get; set; }
    public required string Developer { get; set; }
}
