'use client';

import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import * as z from 'zod';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select';
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from '@/components/ui/form';
import { toast } from 'sonner';
import type { Location } from '@/lib/types';

const formSchema = z.object({
  nome: z.string().min(2, 'Nome deve ter pelo menos 2 caracteres'),
  categoria: z.string().min(1, 'Categoria é obrigatória'),
  latitude: z.number().min(-90).max(90),
  longitude: z.number().min(-180).max(180),
});

interface LocationFormProps {
  categories: string[];
  initialData?: Location;
  onSubmit: (data: z.infer<typeof formSchema>) => Promise<void>;
}

export function LocationForm({ categories, initialData, onSubmit }: LocationFormProps) {
  const [isLoading, setIsLoading] = useState(false);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: initialData ? {
      nome: initialData.nome,
      categoria: initialData.categoria,
      latitude: initialData.coordenadas.coordinates[1],
      longitude: initialData.coordenadas.coordinates[0],
    } : {
      nome: '',
      categoria: '',
      latitude: 0,
      longitude: 0,
    },
  });

  async function handleSubmit(data: z.infer<typeof formSchema>) {
    try {
      setIsLoading(true);
      await onSubmit(data);
      form.reset();
      toast.success('Localização salva com sucesso!');
    } catch (error) {
      toast.error('Erro ao salvar localização');
    } finally {
      setIsLoading(false);
    }
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(handleSubmit)} className="space-y-4">
        <FormField
          control={form.control}
          name="nome"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Nome</FormLabel>
              <FormControl>
                <Input {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="categoria"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Categoria</FormLabel>
              <Select onValueChange={field.onChange} defaultValue={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Selecione uma categoria" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {categories.map((category) => (
                    <SelectItem key={category} value={category}>
                      {category}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />

        <div className="grid grid-cols-2 gap-4">
          <FormField
            control={form.control}
            name="latitude"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Latitude</FormLabel>
                <FormControl>
                  <Input type="number" step="any" {...field} onChange={e => field.onChange(parseFloat(e.target.value))} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="longitude"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Longitude</FormLabel>
                <FormControl>
                  <Input type="number" step="any" {...field} onChange={e => field.onChange(parseFloat(e.target.value))} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        </div>

        <Button type="submit" disabled={isLoading}>
          {isLoading ? 'Salvando...' : 'Salvar'}
        </Button>
      </form>
    </Form>
  );
}