CREATE EXTENSION IF NOT EXISTS postgis;
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE SCHEMA IF NOT EXISTS dbo;

CREATE TABLE dbo.feature (
    "Id" UUID DEFAULT uuid_generate_v4() PRIMARY KEY, 
    "Name" VARCHAR(255) NOT NULL,
    "Category" INT NOT NULL,
    "Geometry" GEOMETRY(Point, 4326) NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP NULL
);

CREATE INDEX features_idx ON dbo.feature USING GIST ("Geometry");

CREATE INDEX features_name_idx ON dbo.feature ("Name");
CREATE INDEX features_category_idx ON dbo.feature ("Category");

INSERT INTO dbo.feature ("Name", "Category", "Geometry", "CreatedAt", "UpdatedAt")
VALUES
    ('Residential Alpha', 1, ST_MakePoint(120.6333, 45.5504), CURRENT_TIMESTAMP, NULL),
    ('Commercial Beta', 2, ST_MakePoint(-70.6445, 35.5427), CURRENT_TIMESTAMP, NULL),
    ('Hospital Gamma', 3, ST_MakePoint(80.6528, -10.5380), CURRENT_TIMESTAMP, NULL),
    ('School Delta', 4, ST_MakePoint(-100.6382, 50.5471), CURRENT_TIMESTAMP, NULL),
    ('Park Epsilon', 5, ST_MakePoint(60.6250, -20.5612), CURRENT_TIMESTAMP, NULL),
    ('Commercial Zeta', 2, ST_MakePoint(-130.6401, 25.5553), CURRENT_TIMESTAMP, NULL),
    ('Hospital Eta', 3, ST_MakePoint(90.6318, -30.5498), CURRENT_TIMESTAMP, NULL),
    ('School Theta', 4, ST_MakePoint(-140.6489, 40.5456), CURRENT_TIMESTAMP, NULL),
    ('Residential Iota', 1, ST_MakePoint(110.6575, -15.5342), CURRENT_TIMESTAMP, NULL),
    ('Commercial Kappa', 2, ST_MakePoint(-150.6359, 55.5520), CURRENT_TIMESTAMP, NULL),
    ('Hospital Lambda', 3, ST_MakePoint(100.6287, -25.5585), CURRENT_TIMESTAMP, NULL),
    ('School Mu', 4, ST_MakePoint(-160.6472, 60.5409), CURRENT_TIMESTAMP, NULL),
    ('Park Nu', 5, ST_MakePoint(70.6551, -35.5363), CURRENT_TIMESTAMP, NULL),
    ('Residential Xi', 1, ST_MakePoint(-170.6398, 65.5484), CURRENT_TIMESTAMP, NULL),
    ('Commercial Omicron', 2, ST_MakePoint(80.6235, -40.5637), CURRENT_TIMESTAMP, NULL),
    ('Hospital Pi', 3, ST_MakePoint(-180.6419, 70.5576), CURRENT_TIMESTAMP, NULL),
    ('School Rho', 4, ST_MakePoint(90.6301, -45.5513), CURRENT_TIMESTAMP, NULL),
    ('Park Sigma', 5, ST_MakePoint(-160.6463, 75.5441), CURRENT_TIMESTAMP, NULL),
    ('Residential Tau', 1, ST_MakePoint(100.6592, -50.5325), CURRENT_TIMESTAMP, NULL),
    ('Commercial Upsilon', 2, ST_MakePoint(-150.6346, 80.5535), CURRENT_TIMESTAMP, NULL),
    ('Hospital Phi', 3, ST_MakePoint(110.6274, -55.5601), CURRENT_TIMESTAMP, NULL),
    ('School Chi', 4, ST_MakePoint(-140.6458, 85.5418), CURRENT_TIMESTAMP, NULL),
    ('Park Psi', 5, ST_MakePoint(120.6539, -60.5371), CURRENT_TIMESTAMP, NULL),
    ('Residential Omega', 1, ST_MakePoint(-130.6407, 90.5497), CURRENT_TIMESTAMP, NULL),
    ('Commercial Alpha2', 2, ST_MakePoint(130.6221, -65.5652), CURRENT_TIMESTAMP, NULL),
    ('Hospital Beta2', 3, ST_MakePoint(-120.6430, 95.5590), CURRENT_TIMESTAMP, NULL),
    ('School Gamma2', 4, ST_MakePoint(140.6293, -70.5528), CURRENT_TIMESTAMP, NULL),
    ('Park Delta2', 5, ST_MakePoint(-110.6449, 100.5434), CURRENT_TIMESTAMP, NULL),
    ('Residential Epsilon2', 1, ST_MakePoint(150.6608, -75.5317), CURRENT_TIMESTAMP, NULL);