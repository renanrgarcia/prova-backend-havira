'use client';

import { ThemeToggle } from '@/components/theme/theme-toggle';

export function Header() {
  return (
    <header className="sticky top-0 z-50 border-b bg-background/80 backdrop-blur-sm">
      <div className="container mx-auto flex h-16 items-center justify-between px-4">
        <h2 className="text-2xl font-bold text-primary">Sistema de Localizações</h2>
        <ThemeToggle />
      </div>
    </header>
  );
}