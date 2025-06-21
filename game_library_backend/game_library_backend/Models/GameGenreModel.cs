namespace game_library_backend.Models;

public class GameGenreModel
{
    public int GameId { get; set; }
    public required GameModel Game { get; set; }
    public int GenreId { get; set; }
    public required GenreModel Genre { get; set; }
}
