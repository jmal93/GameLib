import { GameList } from "@/components/game_list";
import { GameService } from "@/services/api";

export default async function Library() {
  const games = await GameService.getAllGames();
  console.log(games[0].developer);
  return (
    <div>
      <h1 className="text-center text-4xl">Jogos</h1>
      <GameList games={games}></GameList>
    </div>
  );
}
