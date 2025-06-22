namespace game_library_backend.Models;

public class GenreModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<GameGenreModel> GameGenres { get; set; }
}
