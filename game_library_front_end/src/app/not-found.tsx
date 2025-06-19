import Link from "next/link";

export default function NotFound() {
    return (
        <div className="flex flex-col justify-center items-center">
            <h1 className="text-5xl text-center font-bold mt-7">Erro 404</h1>
            <p>Essa página não existe</p>
            <Link href={"/"}>Voltar para home</Link>
        </div>
    )
}