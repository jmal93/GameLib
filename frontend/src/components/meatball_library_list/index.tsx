"use client";

import { GameService } from "@/services/api";
import { useRouter } from "next/navigation";
import { useState } from "react";

interface MeatballMenuProps {
  gameId: number;
}

export const MeatballMenu = ({ gameId }: MeatballMenuProps) => {
  const route = useRouter();
  const [isOpen, setIsOpen] = useState(false);

  function removeGameFromLibrary() {
    GameService.removeGameFromLibrary(gameId);
    route.refresh();
  }

  return (
    <div className="relative">
      <button
        onClick={() => setIsOpen(!isOpen)}
        className="p-1 rounded-full hover:bg-gray-200 focus:outline-none"
      >
        <div>
          {[...Array(3)].map((_, i) => (
            <div
              key={i}
              className="w-1 h-1 rounded-full bg-gray-600 my-0.5"
            ></div>
          ))}
        </div>
      </button>

      {isOpen && (
        <div className="absolute right-0 py-1 w-40 bg-white rounded-md z-10 border border-gray-300">
          <button
            onClick={removeGameFromLibrary}
            className="block w-full text-center hover:bg-gray-100 px-2 py-2 text-sm"
          >
            Remove from library
          </button>
        </div>
      )}
    </div>
  );
};

export default MeatballMenu;
