"use server";
import { cookies } from "next/headers";

export const setAuthToken = async (token: string) => {
  const cookieStore = await cookies();
  cookieStore.set("authToken", token);
};

export const getAuthToken = async () => {
  const cookieStore = await cookies();
  return cookieStore.get("authToken");
};

export const removeAuthToken = async () => {
  (await cookies()).delete("authToken");
};
