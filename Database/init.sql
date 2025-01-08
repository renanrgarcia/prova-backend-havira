CREATE EXTENSION IF NOT EXISTS postgis;
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE SCHEMA IF NOT EXISTS dbo;

CREATE TABLE dbo.feature (
    "Id" UUID DEFAULT uuid_generate_v4() PRIMARY KEY, 
    "Type" VARCHAR(255) NOT NULL,
    "Geometry" GEOMETRY(Point, 4326) NOT NULL,
    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP NULL,
    "Status" BOOLEAN NOT NULL
);

CREATE TABLE dbo.properties (
    "Id" UUID DEFAULT uuid_generate_v4() PRIMARY KEY,
    "FeatureId" UUID NOT NULL,
    "Nome" VARCHAR(255) NOT NULL,
    "Categoria" VARCHAR(255) NOT NULL,
    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP NULL,
    CONSTRAINT fk_feature
        FOREIGN KEY("FeatureId") 
        REFERENCES dbo.feature("Id")
);

WITH inserted_features AS (
    INSERT INTO dbo.feature ("Type", "Geometry", "Status", "CreatedAt", "UpdatedAt")
    VALUES
        ('Feature', ST_MakePoint(120.6333, 45.5504), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP), 
        ('Feature', ST_MakePoint(-70.6445, 35.5427), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(80.6528, -10.5380), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-100.6382, 50.5471), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(60.6250, -20.5612), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-130.6401, 25.5553), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(90.6318, -30.5498), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-140.6489, 40.5456), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(110.6575, -15.5342), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-150.6359, 55.5520), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(100.6287, -25.5585), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-160.6472, 60.5409), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(70.6551, -35.5363), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-170.6398, 65.5484), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(80.6235, -40.5637), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-180.6419, 70.5576), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(90.6301, -45.5513), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-160.6463, 75.5441), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(100.6592, -50.5325), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-150.6346, 80.5535), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(110.6274, -55.5601), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-140.6458, 85.5418), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(120.6539, -60.5371), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-130.6407, 90.5497), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(130.6221, -65.5652), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-120.6430, 95.5590), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(140.6293, -70.5528), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(-110.6449, 100.5434), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('Feature', ST_MakePoint(150.6608, -75.5317), TRUE, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
    RETURNING "Id", "Geometry"
)
INSERT INTO dbo.properties ("FeatureId", "Nome", "Categoria", "CreatedAt", "UpdatedAt")
SELECT "Id", 'Casa A', '1', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(120.6333, 45.5504)
UNION ALL
SELECT "Id", 'Hospital B', '3', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-70.6445, 35.5427)
UNION ALL
SELECT "Id", 'Escola C', '4', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(80.6528, -10.5380)
UNION ALL
SELECT "Id", 'Loja D', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-100.6382, 50.5471)
UNION ALL
SELECT "Id", 'Parque E', '5', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(60.6250, -20.5612)
UNION ALL
SELECT "Id", 'Banco F', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-130.6401, 25.5553)
UNION ALL
SELECT "Id", 'Supermercado G', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(90.6318, -30.5498)
UNION ALL
SELECT "Id", 'Academia H', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-140.6489, 40.5456)
UNION ALL
SELECT "Id", 'Biblioteca I', '4', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(110.6575, -15.5342)
UNION ALL
SELECT "Id", 'Posto de Gasolina J', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-150.6359, 55.5520)
UNION ALL
SELECT "Id", 'Casa K', '1', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(100.6287, -25.5585)
UNION ALL
SELECT "Id", 'Hospital L', '3', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-160.6472, 60.5409)
UNION ALL
SELECT "Id", 'Escola M', '4', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(70.6551, -35.5363)
UNION ALL
SELECT "Id", 'Clinica N', '3', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-170.6398, 65.5484)
UNION ALL
SELECT "Id", 'Parque O', '5', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(80.6235, -40.5637)
UNION ALL
SELECT "Id", 'Banco P', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-180.6419, 70.5576)
UNION ALL
SELECT "Id", 'Supermercado Q', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(90.6301, -45.5513)
UNION ALL
SELECT "Id", 'Academia R', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-160.6463, 75.5441)
UNION ALL
SELECT "Id", 'Biblioteca S', '4', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(100.6592, -50.5325)
UNION ALL
SELECT "Id", 'Posto de Gasolina T', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-150.6346, 80.5535)
UNION ALL
SELECT "Id", 'Casa U', '1', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(110.6274, -55.5601)
UNION ALL
SELECT "Id", 'Hospital V', '3', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-140.6458, 85.5418)
UNION ALL
SELECT "Id", 'Escola W', '4', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(120.6539, -60.5371)
UNION ALL
SELECT "Id", 'Clinica X', '3', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-130.6407, 90.5497)
UNION ALL
SELECT "Id", 'Parque Y', '5', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(130.6221, -65.5652)
UNION ALL
SELECT "Id", 'Banco Z', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-120.6430, 95.5590)
UNION ALL
SELECT "Id", 'Supermercado AA', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(140.6293, -70.5528)
UNION ALL
SELECT "Id", 'Academia BB', '2', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(-110.6449, 100.5434)
UNION ALL
SELECT "Id", 'Biblioteca CC', '4', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP FROM inserted_features WHERE "Geometry" = ST_MakePoint(150.6608, -75.5317);