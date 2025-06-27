using Microsoft.Identity.Client;

namespace game_library_backend.DTOs;

public class UserGameLibraryDTO
{
    public int GameId { get; set; }
    public string Title { get; set; }
    public string Developer { get; set; }
    public DateTime AddedDate { get; set; }
    public string Status { get; set; }
    public List<string> Genres { get; set; } = [];
}
