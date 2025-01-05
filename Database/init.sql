CREATE EXTENSION IF NOT EXISTS postgis;

CREATE SCHEMA IF NOT EXISTS havira;

CREATE TABLE havira.locations (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    categoria VARCHAR(255) NOT NULL,
    coordenadas GEOMETRY(Point, 4326) NOT NULL
);

CREATE INDEX idx_locations_coordenadas ON havira.locations USING GIST (coordenadas);

INSERT INTO havira.locations (nome, categoria, coordenadas)
VALUES
    ('Casa A', 1, ST_GeomFromText('POINT(-46.6333 -23.5504)', 4326)), 
    ('Hospital B', 3, ST_GeomFromText('POINT(-46.6445 -23.5427)', 4326)),
    ('Escola C', 4, ST_GeomFromText('POINT(-46.6528 -23.5380)', 4326)),
    ('Loja D', 2, ST_GeomFromText('POINT(-46.6382 -23.5471)', 4326)),
    ('Parque E', 5, ST_GeomFromText('POINT(-46.6250 -23.5612)', 4326)),
    ('Banco F', 2, ST_GeomFromText('POINT(-46.6401 -23.5553)', 4326)),
    ('Supermercado G', 2, ST_GeomFromText('POINT(-46.6318 -23.5498)', 4326)),
    ('Academia H', 2, ST_GeomFromText('POINT(-46.6489 -23.5456)', 4326)),
    ('Biblioteca I', 4, ST_GeomFromText('POINT(-46.6575 -23.5342)', 4326)),
    ('Posto de Gasolina J', 2, ST_GeomFromText('POINT(-46.6359 -23.5520)', 4326)),
    ('Casa K', 1, ST_GeomFromText('POINT(-46.6287 -23.5585)', 4326)),
    ('Hospital L', 3, ST_GeomFromText('POINT(-46.6472 -23.5409)', 4326)),
    ('Escola M', 4, ST_GeomFromText('POINT(-46.6551 -23.5363)', 4326)),
    ('Clinica N', 3, ST_GeomFromText('POINT(-46.6398 -23.5484)', 4326)),
    ('Parque O', 5, ST_GeomFromText('POINT(-46.6235 -23.5637)', 4326)),
    ('Banco P', 2, ST_GeomFromText('POINT(-46.6419 -23.5576)', 4326)),
    ('Supermercado Q', 2, ST_GeomFromText('POINT(-46.6301 -23.5513)', 4326)),
    ('Academia R', 2, ST_GeomFromText('POINT(-46.6463 -23.5441)', 4326)),
    ('Biblioteca S', 4, ST_GeomFromText('POINT(-46.6592 -23.5325)', 4326)),
    ('Posto de Gasolina T', 2, ST_GeomFromText('POINT(-46.6346 -23.5535)', 4326)),
    ('Casa U', 1, ST_GeomFromText('POINT(-46.6274 -23.5601)', 4326)),
    ('Hospital V', 3, ST_GeomFromText('POINT(-46.6458 -23.5418)', 4326)),
    ('Escola W', 4, ST_GeomFromText('POINT(-46.6539 -23.5371)', 4326)),
    ('Clinica X', 3, ST_GeomFromText('POINT(-46.6407 -23.5497)', 4326)),
    ('Parque Y', 5, ST_GeomFromText('POINT(-46.6221 -23.5652)', 4326)),
    ('Banco Z', 2, ST_GeomFromText('POINT(-46.6430 -23.5590)', 4326)),
    ('Supermercado AA', 2, ST_GeomFromText('POINT(-46.6293 -23.5528)', 4326)),
    ('Academia BB', 2, ST_GeomFromText('POINT(-46.6449 -23.5434)', 4326)),
    ('Biblioteca CC', 4, ST_GeomFromText('POINT(-46.6608 -23.5317)', 4326));
