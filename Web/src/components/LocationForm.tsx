import React from "react";

interface FormType {
    id: string;
    nome: string;
    categoria: string;
    coordenadas: string;
}

interface FormProps {
    form: FormType;
    setForm: React.Dispatch<React.SetStateAction<FormType>>;
    isEditing: boolean;
    categories: string[];
    handleSubmit: (e: React.FormEvent) => void;
}

const LocationForm: React.FC<FormProps> = ({ form, setForm, isEditing, categories, handleSubmit }) => {
    return (
        <form onSubmit={handleSubmit}>
        <input
            type="text"
            placeholder="Name"
            value={form.nome}
            onChange={(e) => setForm({ ...form, nome: e.target.value })}
            required
        />
        <select
            value={form.categoria}
            onChange={(e) => setForm({ ...form, categoria: e.target.value })}
            required
        >
            <option value="" disabled>
            Select Category
            </option>
            {categories.map((cat) => (
            <option key={cat} value={cat}>
                {cat}
            </option>
            ))}
        </select>
        <input
            type="text"
            placeholder="Coordinates (e.g., POINT(-46.6333 -23.5504))"
            value={form.coordenadas}
            onChange={(e) => setForm({ ...form, coordenadas: e.target.value })}
            required
        />
        <button type="submit">{isEditing ? "Update" : "Add"} Location</button>
        </form>
    );
};

export default LocationForm;