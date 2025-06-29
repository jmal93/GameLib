import { AuthGuard } from "@/components/auth_guard";
import MeatballMenu from "@/components/meatball_library_list";
import { GameService } from "@/services/api";

export default async function Library() {
  const library = await GameService.getUserLibrary();

  if (library.length == 0) {
    return <h2 className="text-center py-4 text-3xl">Empty library</h2>;
  }

  return (
    <AuthGuard>
      <div>
        <h1 className="text-center text-4xl py-6">Library</h1>
        <div className="container mx-auto px-30">
          {library.map((game: any) => (
            <div
              key={game.gameId}
              className="border rounded shadow-md p-3 relative"
            >
              <div className="absolute right-3">
                <MeatballMenu gameId={game.gameId}></MeatballMenu>
              </div>
              <h2 className="text-2xl font-bold mb-2">{game.title}</h2>
              <p>Developer: {game.developer}</p>
              <p>Genres: {game.genres.join(", ")}</p>
              <p>Status: {game.status}</p>
              <p>Added date: {new Date(game.addedDate).toUTCString()}</p>
            </div>
          ))}
        </div>
      </div>
    </AuthGuard>
  );
}
