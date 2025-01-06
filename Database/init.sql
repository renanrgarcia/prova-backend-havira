CREATE EXTENSION IF NOT EXISTS postgis;
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE SCHEMA IF NOT EXISTS dbo;

CREATE TABLE dbo.localizacao (
    Id UUID DEFAULT uuid_generate_v4() PRIMARY KEY, 
    Nome VARCHAR(255) NOT NULL,
    Categoria VARCHAR(255) NOT NULL,
    Coordenadas GEOMETRY(Point, 4326) NOT NULL
);

INSERT INTO dbo.localizacao (Nome, Categoria, Coordenadas)
VALUES
    ('Casa A', 1, ST_MakePoint(-46.6333, -23.5504)), 
    ('Hospital B', 3, ST_MakePoint(-46.6445, -23.5427)),
    ('Escola C', 4, ST_MakePoint(-46.6528, -23.5380)),
    ('Loja D', 2, ST_MakePoint(-46.6382, -23.5471)),
    ('Parque E', 5, ST_MakePoint(-46.6250, -23.5612)),
    ('Banco F', 2, ST_MakePoint(-46.6401, -23.5553)),
    ('Supermercado G', 2, ST_MakePoint(-46.6318, -23.5498)),
    ('Academia H', 2, ST_MakePoint(-46.6489, -23.5456)),
    ('Biblioteca I', 4, ST_MakePoint(-46.6575, -23.5342)),
    ('Posto de Gasolina J', 2, ST_MakePoint(-46.6359, -23.5520)),
    ('Casa K', 1, ST_MakePoint(-46.6287, -23.5585)),
    ('Hospital L', 3, ST_MakePoint(-46.6472, -23.5409)),
    ('Escola M', 4, ST_MakePoint(-46.6551, -23.5363)),
    ('Clinica N', 3, ST_MakePoint(-46.6398, -23.5484)),
    ('Parque O', 5, ST_MakePoint(-46.6235, -23.5637)),
    ('Banco P', 2, ST_MakePoint(-46.6419, -23.5576)),
    ('Supermercado Q', 2, ST_MakePoint(-46.6301, -23.5513)),
    ('Academia R', 2, ST_MakePoint(-46.6463, -23.5441)),
    ('Biblioteca S', 4, ST_MakePoint(-46.6592, -23.5325)),
    ('Posto de Gasolina T', 2, ST_MakePoint(-46.6346, -23.5535)),
    ('Casa U', 1, ST_MakePoint(-46.6274, -23.5601)),
    ('Hospital V', 3, ST_MakePoint(-46.6458, -23.5418)),
    ('Escola W', 4, ST_MakePoint(-46.6539, -23.5371)),
    ('Clinica X', 3, ST_MakePoint(-46.6407, -23.5497)),
    ('Parque Y', 5, ST_MakePoint(-46.6221, -23.5652)),
    ('Banco Z', 2, ST_MakePoint(-46.6430, -23.5590)),
    ('Supermercado AA', 2, ST_MakePoint(-46.6293, -23.5528)),
    ('Academia BB', 2, ST_MakePoint(-46.6449, -23.5434)),
    ('Biblioteca CC', 4, ST_MakePoint(-46.6608, -23.5317));
