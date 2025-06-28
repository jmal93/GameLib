"use client";

import { removeAuthToken } from "@/services/auth";
import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";

export function Header() {
  const router = useRouter();
  const pathName = usePathname();
  const isAuthPage = ["/login", "/signup"].includes(pathName);

  function handleLogout() {
    removeAuthToken();
    router.push("/login");
  }

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
              <li>
                <button onClick={handleLogout}>Logout</button>
              </li>
            </ul>
          </nav>
        )}
      </div>
    </header>
  );
}
