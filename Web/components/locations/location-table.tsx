'use client';

import { useState } from 'react';
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@/components/ui/table';
import { Button } from '@/components/ui/button';
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from '@/components/ui/dialog';
import { AlertDialog, AlertDialogAction, AlertDialogCancel, AlertDialogContent, AlertDialogDescription, AlertDialogFooter, AlertDialogHeader, AlertDialogTitle, AlertDialogTrigger } from '@/components/ui/alert-dialog';
import { Pencil, Trash2 } from 'lucide-react';
import { LocationForm } from './location-form';
import type { Location } from '@/lib/types';
import { toast } from 'sonner';

interface LocationTableProps {
  locations: Location[];
  categories: string[];
  onUpdate: (location: Location) => Promise<void>;
  onDelete: (id: string) => Promise<void>;
}

export function LocationTable({ locations, categories, onUpdate, onDelete }: LocationTableProps) {
  const [selectedLocation, setSelectedLocation] = useState<Location | null>(null);

  const handleDelete = async (id: string) => {
    try {
      await onDelete(id);
      toast.success('Localização removida com sucesso!');
    } catch (error) {
      toast.error('Erro ao remover localização');
    }
  };

  const handleUpdate = async (data: any) => {
    if (!selectedLocation) return;

    const updatedLocation: Location = {
      ...selectedLocation,
      nome: data.nome,
      categoria: data.categoria,
      coordenadas: {
        type: 'Point',
        coordinates: [data.longitude, data.latitude]
      }
    };

    try {
      await onUpdate(updatedLocation);
      setSelectedLocation(null);
    } catch (error) {
      toast.error('Erro ao atualizar localização');
    }
  };

  return (
    <div className="rounded-xl border bg-card/50 backdrop-blur-sm">
      <Table>
        <TableHeader>
          <TableRow className="hover:bg-transparent">
            <TableHead>Nome</TableHead>
            <TableHead>Categoria</TableHead>
            <TableHead>Latitude</TableHead>
            <TableHead>Longitude</TableHead>
            <TableHead className="text-right">Ações</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {locations.map((location) => (
            <TableRow key={location.id} className="hover:bg-muted/50">
              <TableCell className="font-medium">{location.nome}</TableCell>
              <TableCell>{location.categoria}</TableCell>
              <TableCell>{location.coordenadas.coordinates[1]}</TableCell>
              <TableCell>{location.coordenadas.coordinates[0]}</TableCell>
              <TableCell className="text-right">
                <Dialog open={selectedLocation?.id === location.id} onOpenChange={(open) => !open && setSelectedLocation(null)}>
                  <DialogTrigger asChild>
                    <Button variant="ghost" size="icon" onClick={() => setSelectedLocation(location)}>
                      <Pencil className="h-4 w-4" />
                    </Button>
                  </DialogTrigger>
                  <DialogContent>
                    <DialogHeader>
                      <DialogTitle>Editar Localização</DialogTitle>
                    </DialogHeader>
                    <LocationForm
                      categories={categories}
                      initialData={location}
                      onSubmit={handleUpdate}
                    />
                  </DialogContent>
                </Dialog>

                <AlertDialog>
                  <AlertDialogTrigger asChild>
                    <Button variant="ghost" size="icon">
                      <Trash2 className="h-4 w-4" />
                    </Button>
                  </AlertDialogTrigger>
                  <AlertDialogContent>
                    <AlertDialogHeader>
                      <AlertDialogTitle>Confirmar exclusão</AlertDialogTitle>
                      <AlertDialogDescription>
                        Tem certeza que deseja excluir esta localização? Esta ação não pode ser desfeita.
                      </AlertDialogDescription>
                    </AlertDialogHeader>
                    <AlertDialogFooter>
                      <AlertDialogCancel>Cancelar</AlertDialogCancel>
                      <AlertDialogAction onClick={() => handleDelete(location.id)}>
                        Confirmar
                      </AlertDialogAction>
                    </AlertDialogFooter>
                  </AlertDialogContent>
                </AlertDialog>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
}