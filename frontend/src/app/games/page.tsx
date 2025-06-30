import { GameList } from "@/components/game_list";
import { GameService } from "@/services/api";

export default async function Library() {
  const games = await GameService.getAllGames();

  if (games.length == 0) {
    return <h2 className="text-center py-4 text-3xl">Empty game list</h2>;
  }

  return (
    <div>
      <h1 className="text-center text-4xl">Games</h1>
      <GameList games={games}></GameList>
    </div>
  );
}

export const dynamic = "force-dynamic";
