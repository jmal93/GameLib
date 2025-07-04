"use client";

import { submitLogin } from "@/services/api";
import { setAuthToken } from "@/services/auth";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { FormEvent } from "react";

export default function Login() {
  const route = useRouter();

  async function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const formData = new FormData(event.currentTarget);
    const email = formData.get("email");
    const password = formData.get("password");
    const body = JSON.stringify({ email, password });

    const response = await submitLogin(body);

    if (response.status == 200) {
      setAuthToken(response.data["token"]);
      route.push("/games");
    }
  }

  return (
    <div className="text-center">
      <h1 className="text-4xl py-2">Login</h1>
      <form onSubmit={handleSubmit}>
        <div className="grid gap-2 justify-center">
          <input
            type="email"
            name="email"
            placeholder="Email"
            required
            className="border"
          />
          <input
            type="password"
            name="password"
            placeholder="Password"
            required
            className="border"
          />
        </div>
        <div className="py-2">
          <button
            type="submit"
            className="bg-gray-300 hover:bg-gray-500 gap-y-2"
          >
            Login
          </button>
        </div>
      </form>
      <Link href={"/signup"}>Sign up</Link>
    </div>
  );
}
