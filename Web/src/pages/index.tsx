// pages/locations/index.tsx
import { useState, useEffect } from "react";
import axios from "axios";
import LocationForm from "@/components/LocationForm";
import LocationTable from "@/components/LocationTable";

const API_BASE_URL = "http://localhost:5094/api/v1/Localizacao";

const LocationsPage = () => {
  const [locations, setLocations] = useState([]);
  const [categories, setCategories] = useState<string[]>([]);
  const [form, setForm] = useState({ id: "", nome: "", categoria: "", coordenadas: "" });
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    fetchLocations();
    fetchCategories();
  }, []);

  const fetchLocations = async () => {
    const { data } = await axios.get(`${API_BASE_URL}/obterTodos`);
    setLocations(data || []);
  };

  const fetchCategories = async () => {
    const { data } = await axios.get(`${API_BASE_URL}/obterCategorias`);
    setCategories(data || []);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      if (isEditing) {
        await axios.put(`${API_BASE_URL}/atualizar`, form);
      } else {
        await axios.post(`${API_BASE_URL}/adicionar`, form);
      }
      setForm({ id: "", nome: "", categoria: "", coordenadas: "" });
      setIsEditing(false);
      fetchLocations();
    } catch (error) {
      console.error("Error submitting form:", error);
    }
  };

  const handleDelete = async (id: string) => {
    if (confirm("Are you sure you want to delete this location?")) {
      await axios.delete(`${API_BASE_URL}/remover/${id}`);
      fetchLocations();
    }
  };

  const handleEdit = (location: any) => {
    setForm(location);
    setIsEditing(true);
  };

  return (
    <div className="dark-mode">
      <div className="container">
        <h1>Manage Locations</h1>
        <LocationForm
          form={form}
          setForm={setForm}
          isEditing={isEditing}
          categories={categories}
          handleSubmit={handleSubmit}
        />
        <LocationTable locations={locations} handleEdit={handleEdit} handleDelete={handleDelete} />
      </div>
    </div>
  );
};

export default LocationsPage;