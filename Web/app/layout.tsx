import './globals.css';
import type { Metadata } from 'next';
import { Space_Grotesk } from 'next/font/google';
import { Providers } from './providers';
import { Header } from '@/components/layout/header';
import { Toaster } from '@/components/ui/sonner';

const spaceGrotesk = Space_Grotesk({ subsets: ['latin'] });

export const metadata: Metadata = {
  title: 'Sistema de Localizações',
  description: 'Gerenciamento de localizações',
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="pt-BR" suppressHydrationWarning>
      <body className={spaceGrotesk.className}>
        <Providers>
          <div className="min-h-screen bg-background bg-[linear-gradient(to_bottom,rgba(165,243,252,0.2),rgba(165,243,252,0)_50%)]">
            <Header />
            <main>{children}</main>
          </div>
          <Toaster />
        </Providers>
      </body>
    </html>
  );
}