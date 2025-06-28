"use client";

import { setToken, submitLogin } from "@/services/api";
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
      setToken(response.data["token"]);
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
        <button type="submit" className="hover:bg-gray-300 gap-y-2">
          Login
        </button>
      </form>
    </div>
  );
}
