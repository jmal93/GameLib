import { AuthGuard } from "@/components/auth_guard";

export default function Library() {
  return (
    <AuthGuard>
      <div>
        <h1 className="text-center text-4xl">Library</h1>
      </div>
    </AuthGuard>
  );
}
