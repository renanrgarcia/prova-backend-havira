export interface Location {
  id: string;
  nome: string;
  categoria: string;
  coordenadas: {
    type: 'Point';
    coordinates: [number, number];
  };
}

export interface LocationFormData {
  nome: string;
  categoria: string;
  latitude: number;
  longitude: number;
}

export interface ApiResponse<T> {
  success: boolean;
  data?: T;
  errors?: string[];
  message?: string;
}