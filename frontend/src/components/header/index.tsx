"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";

export function Header() {
  const pathName = usePathname();
  const isAuthPage = ["/login", "/signup"].includes(pathName);

  return (
    <header className="px-2 py-3 bg-black text-white">
      <div className="flex justify-between items-center">
        <nav>
          <div className="text-3xl">GameLib</div>
        </nav>

        {!isAuthPage && (
          <nav>
            <ul className="flex gap-4">
              <li>
                <Link href={"/library"}>Library</Link>
              </li>
              <li>
                <Link href={"/games"}>Games</Link>
              </li>
            </ul>
          </nav>
        )}
      </div>
    </header>
  );
}
