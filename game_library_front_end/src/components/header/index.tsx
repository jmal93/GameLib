import Link from "next/link";

export function Header() {
    return (
        <header className="px-2 py-3 bg-black text-white">
            <div className="flex justify-between items-center">
                <nav>
                    <div className="text-3xl">
                        <Link href={"/"}>
                            GameLib
                        </Link>
                    </div>
                </nav>

                <nav>
                    <ul className="flex gap-4">
                        <li>
                            <Link href={"/library"}>Biblioteca</Link>
                        </li>
                        <li>
                            <Link href={"/profile"}>Perfil</Link>
                        </li>
                    </ul>
                </nav>
            </div>
        </header>
    )
}