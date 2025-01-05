'use client';

import { useEffect, useState } from 'react';
import { Button } from '@/components/ui/button';
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from '@/components/ui/dialog';
import { LocationForm } from '@/components/locations/location-form';
import { LocationTable } from '@/components/locations/location-table';
import { fetchLocations, fetchCategories, createLocation, updateLocation, deleteLocation } from '@/lib/api';
import type { Location } from '@/lib/types';
import { Plus } from 'lucide-react';
import { toast } from 'sonner';

export default function Home() {
  const [locations, setLocations] = useState<Location[]>([]);
  const [categories, setCategories] = useState<string[]>([]);
  const [isAddDialogOpen, setIsAddDialogOpen] = useState(false);

  useEffect(() => {
    loadData();
  }, []);

  async function loadData() {
    try {
      const [locationsData, categoriesData] = await Promise.all([
        fetchLocations(),
        fetchCategories(),
      ]);
      setLocations(locationsData.data || []);
      setCategories(categoriesData.data || []);
    } catch (error) {
      toast.error('Erro ao carregar dados');
    }
  }

  async function handleCreate(data: any) {
    try {
      await createLocation({
        nome: data.nome,
        categoria: data.categoria,
        latitude: data.latitude,
        longitude: data.longitude,
      });
      await loadData();
      setIsAddDialogOpen(false);
      toast.success('Localização criada com sucesso!');
    } catch (error) {
      toast.error('Erro ao criar localização');
    }
  }

  async function handleUpdate(location: Location) {
    try {
      await updateLocation(location);
      await loadData();
      toast.success('Localização atualizada com sucesso!');
    } catch (error) {
      toast.error('Erro ao atualizar localização');
    }
  }

  async function handleDelete(id: string) {
    try {
      await deleteLocation(id);
      await loadData();
      toast.success('Localização removida com sucesso!');
    } catch (error) {
      toast.error('Erro ao excluir localização');
    }
  }

  return (
    <div className="container mx-auto py-10 px-4">
      <div className="flex justify-between items-center mb-8">
        <h1 className="text-3xl font-bold text-foreground">Gerenciamento de Localizações</h1>
        <Dialog open={isAddDialogOpen} onOpenChange={setIsAddDialogOpen}>
          <DialogTrigger asChild>
            <Button className="bg-primary hover:bg-primary/90">
              <Plus className="mr-2 h-4 w-4" />
              Adicionar Localização
            </Button>
          </DialogTrigger>
          <DialogContent>
            <DialogHeader>
              <DialogTitle>Nova Localização</DialogTitle>
            </DialogHeader>
            <LocationForm
              categories={categories}
              onSubmit={handleCreate}
            />
          </DialogContent>
        </Dialog>
      </div>

      <LocationTable
        locations={locations}
        categories={categories}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </div>
  );
}