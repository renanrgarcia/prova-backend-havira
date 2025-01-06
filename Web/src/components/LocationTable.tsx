import React from "react";

interface TableProps {
    locations: any[];
    handleEdit: (location: any) => void;
    handleDelete: (id: string) => void;
}

const LocationTable: React.FC<TableProps> = ({ locations, handleEdit, handleDelete }) => {
    return (
        <table>
        <thead>
            <tr>
            <th>Name</th>
            <th>Category</th>
            <th>Coordinates</th>
            <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            {locations.map((loc) => (
            <tr key={loc.id}>
                <td>{loc.nome}</td>
                <td>{loc.categoria}</td>
                <td>{loc.coordenadas}</td>
                <td>
                <button onClick={() => handleEdit(loc)}>Edit</button>
                <button onClick={() => handleDelete(loc.id)}>Delete</button>
                </td>
            </tr>
            ))}
        </tbody>
        </table>
    );
};

export default LocationTable;