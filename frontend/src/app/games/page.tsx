"use client";

import { GameList } from "@/components/game_list";
import { GameService } from "@/services/api";
import { useEffect, useState } from "react";

export default function Games() {
  const [games, setGames] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(false);

  useEffect(() => {
    GameService.getAllGames()
      .then((data) => {
        setGames(data);
        setLoading(false);
      })
      .catch((error) => {
        console.error(error);
        setError(true);
        setLoading(false);
      });
  }, []);

  if (error) {
    return (
      <h2 className="text-center py-4 text-3xl">Error in fetching games</h2>
    );
  }

  if (loading) {
    return <h2 className="text-center py-4 text-3xl">Loading...</h2>;
  }

  if (games.length === 0) {
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
