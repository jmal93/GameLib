import "./globals.css";
import { Header } from '../components/header'
import { Metadata } from "next"

export const metadata: Metadata = {
  title: 'GameLib',
  description: 'Game collections for gamers'
}

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body
        className={`antialiased`}
      >
        <Header></Header>
        {children}
      </body>
    </html>
  );
}
