const API_BASE_URL = process.env.NEXT_PUBLIC_API_URL || 'http://localhost:5000/api/v1';

export async function fetchLocations() {
  const response = await fetch(`${API_BASE_URL}/Localizacao/obterTodos`);
  const data = await response.json();
  return data;
}

export async function fetchCategories() {
  const response = await fetch(`${API_BASE_URL}/Localizacao/obterCategorias`);
  const data = await response.json();
  return data;
}

export async function createLocation(location: LocationFormData) {
  const response = await fetch(`${API_BASE_URL}/Localizacao/adicionar`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(location),
  });
  return response.json();
}

export async function updateLocation(location: Location) {
  const response = await fetch(`${API_BASE_URL}/Localizacao/atualizar`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(location),
  });
  return response.json();
}

export async function deleteLocation(id: string) {
  const response = await fetch(`${API_BASE_URL}/Localizacao/remover/${id}`, {
    method: 'DELETE',
  });
  return response.json();
}