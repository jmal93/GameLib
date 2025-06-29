"use client";

import { submitLogin, submitSignup } from "@/services/api";
import { useRouter } from "next/navigation";
import { FormEvent } from "react";

export default function SignUp() {
  const route = useRouter();

  async function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const formData = new FormData(event.currentTarget);
    const username = formData.get("userName");
    const email = formData.get("email");
    const password = formData.get("password");
    const body = JSON.stringify({ userName: username, email, password });

    console.log(body);

    const response = await submitSignup(body);

    if (response.status == 200) {
      route.push("/login");
    }
  }

  return (
    <div className="text-center">
      <h1 className="text-4xl py-2">Sign Up</h1>
      <form onSubmit={handleSubmit}>
        <div className="grid gap-2 justify-center">
          <input
            name="userName"
            placeholder="Username"
            required
            className="border"
          />
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
          Sign Up
        </button>
      </form>
    </div>
  );
}
