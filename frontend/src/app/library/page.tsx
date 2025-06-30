"use client";

import { AuthGuard } from "@/components/auth_guard";
import MeatballMenu from "@/components/meatball_library_list";
import { GameService } from "@/services/api";
import { useEffect, useState } from "react";

export default function Library() {
  const [library, setLibrary] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(false);

  useEffect(() => {
    GameService.getUserLibrary()
      .then((data) => {
        setLibrary(data);
        setLoading(false);
      })
      .catch((error) => {
        console.error(error);
        setError(true);
        setLoading(false);
      });
  });

  if (error) {
    return (
      <h2 className="text-center py-4 text-3xl">Error in fetching library</h2>
    );
  }

  if (loading) {
    return <h2 className="text-center py-4 text-3xl">Loading...</h2>;
  }

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
              <p>Added date: {new Date(game.addedDate).toUTCString()}</p>
            </div>
          ))}
        </div>
      </div>
    </AuthGuard>
  );
}

export const dynamic = "force-dynamic";
