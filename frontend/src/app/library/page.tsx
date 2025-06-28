import { AuthGuard } from "@/components/auth_guard";
import { GameList } from "@/components/game_list";
import { GameService } from "@/services/api";

export default async function Library() {
  const library = await GameService.getUserLibrary();
  console.log(library);
  return (
    <AuthGuard>
      <div>
        <h1 className="text-center text-4xl">Library</h1>
        <GameList games={library}></GameList>
      </div>
    </AuthGuard>
  );
}
