namespace game_library_backend.DTOs;

public class GameDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public decimal? Price { get; set; }
    public required string Developer { get; set; }
    public string? Image { get; set; }
    public required List<string> Genres { get; set; }
}
