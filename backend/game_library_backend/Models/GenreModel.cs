namespace game_library_backend.Models;

public class GenreModel
{
    public int Id { get; set; }
    required public string Name { get; set; }
    public ICollection<GameGenreModel>? GameGenres { get; set; }
}
