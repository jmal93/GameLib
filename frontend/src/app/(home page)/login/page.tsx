import { FormEvent } from "react";

export default async function Login() {
  async function handleSubmit(event: FormEvent<HTMLFormElement>) {
    const formData = new FormData(event.currentTarget);
    const email = formData.get("email");
    const password = formData.get("password");
  }

  return (
    <div className="text-center">
      <h1 className="text-4xl">Login</h1>
      <form action="">
        <p>
          <input type="email" name="email" placeholder="Email" required />
        </p>
        <p>
          <input
            type="password"
            name="password"
            placeholder="Password"
            required
          />
        </p>
        <p>
          <button type="submit">Login</button>
        </p>
      </form>
    </div>
  );
}
