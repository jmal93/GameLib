"use client";

import { getAuthToken } from "@/services/auth";
import { useRouter } from "next/navigation";
import { useEffect } from "react";

export function AuthGuard({ children }: { children: React.ReactNode }) {
  const router = useRouter();

  useEffect(() => {
    const token = getAuthToken();
    if (!token) {
      router.push("/login");
    }
  }, []);

  return <>{children}</>;
}
