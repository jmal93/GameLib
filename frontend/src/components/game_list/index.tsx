import { Game } from "@/models/Game";

interface GameListProps {
  games: Game[];
}

export const GameList = ({ games }: GameListProps) => {
  if (games.length == 0) {
    return <p>Lista vazia</p>;
  }

  return (
    <div className="py-8 container mx-auto px-4">
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        {games.map((game) => (
          <div key={game.id} className="border rounded shadow-sm p-3">
            <h2 className="text-2xl font-bold mb-2">{game.name}</h2>
            <p>Developer: {game.developer}</p>
            <p>
              Release date: {new Date(game.releaseDate).toLocaleDateString()}
            </p>
            <p>Genres: {game.genres.join(", ")}</p>
            <p>
              Price:{" "}
              {game.price?.toLocaleString("en-US", {
                style: "currency",
                currency: "USD",
              })}
            </p>
          </div>
        ))}
      </div>
    </div>
  );
};
