CREATE EXTENSION IF NOT EXISTS postgis;
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE SCHEMA IF NOT EXISTS dbo;

CREATE TABLE dbo.feature (
    "Id" UUID DEFAULT uuid_generate_v4() PRIMARY KEY, 
    "Name" VARCHAR(255) NOT NULL,
    "Category" INT NOT NULL,
    "Point" GEOMETRY(Point, 4326) NOT NULL,
    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP NULL,
);

CREATE INDEX features_idx ON features USING GIST (Point);

CREATE INDEX features_name_idx ON features (Name);
CREATE INDEX features_category_idx ON features (Category);

INSERT INTO dbo.feature ("Name", "Category", "Point", "CreatedAt", "UpdatedAt")
VALUES
    ('Feature A', 1, ST_MakePoint(120.6333, 45.5504), CURRENT_TIMESTAMP, NULL),
    ('Feature B', 3, ST_MakePoint(-70.6445, 35.5427), CURRENT_TIMESTAMP, NULL),
    ('Feature C', 4, ST_MakePoint(80.6528, -10.5380), CURRENT_TIMESTAMP, NULL),
    ('Feature D', 2, ST_MakePoint(-100.6382, 50.5471), CURRENT_TIMESTAMP, NULL),
    ('Feature E', 5, ST_MakePoint(60.6250, -20.5612), CURRENT_TIMESTAMP, NULL),
    ('Feature F', 2, ST_MakePoint(-130.6401, 25.5553), CURRENT_TIMESTAMP, NULL),
    ('Feature G', 2, ST_MakePoint(90.6318, -30.5498), CURRENT_TIMESTAMP, NULL),
    ('Feature H', 2, ST_MakePoint(-140.6489, 40.5456), CURRENT_TIMESTAMP, NULL),
    ('Feature I', 4, ST_MakePoint(110.6575, -15.5342), CURRENT_TIMESTAMP, NULL),
    ('Feature J', 2, ST_MakePoint(-150.6359, 55.5520), CURRENT_TIMESTAMP, NULL),
    ('Feature K', 1, ST_MakePoint(100.6287, -25.5585), CURRENT_TIMESTAMP, NULL),
    ('Feature L', 3, ST_MakePoint(-160.6472, 60.5409), CURRENT_TIMESTAMP, NULL),
    ('Feature M', 4, ST_MakePoint(70.6551, -35.5363), CURRENT_TIMESTAMP, NULL),
    ('Feature N', 3, ST_MakePoint(-170.6398, 65.5484), CURRENT_TIMESTAMP, NULL),
    ('Feature O', 5, ST_MakePoint(80.6235, -40.5637), CURRENT_TIMESTAMP, NULL),
    ('Feature P', 2, ST_MakePoint(-180.6419, 70.5576), CURRENT_TIMESTAMP, NULL),
    ('Feature Q', 2, ST_MakePoint(90.6301, -45.5513), CURRENT_TIMESTAMP, NULL),
    ('Feature R', 2, ST_MakePoint(-160.6463, 75.5441), CURRENT_TIMESTAMP, NULL),
    ('Feature S', 4, ST_MakePoint(100.6592, -50.5325), CURRENT_TIMESTAMP, NULL),
    ('Feature T', 2, ST_MakePoint(-150.6346, 80.5535), CURRENT_TIMESTAMP, NULL),
    ('Feature U', 1, ST_MakePoint(110.6274, -55.5601), CURRENT_TIMESTAMP, NULL),
    ('Feature V', 3, ST_MakePoint(-140.6458, 85.5418), CURRENT_TIMESTAMP, NULL),
    ('Feature W', 4, ST_MakePoint(120.6539, -60.5371), CURRENT_TIMESTAMP, NULL),
    ('Feature X', 3, ST_MakePoint(-130.6407, 90.5497), CURRENT_TIMESTAMP, NULL),
    ('Feature Y', 5, ST_MakePoint(130.6221, -65.5652), CURRENT_TIMESTAMP, NULL),
    ('Feature Z', 2, ST_MakePoint(-120.6430, 95.5590), CURRENT_TIMESTAMP, NULL),
    ('Feature AA', 2, ST_MakePoint(140.6293, -70.5528), CURRENT_TIMESTAMP, NULL),
    ('Feature BB', 2, ST_MakePoint(-110.6449, 100.5434), CURRENT_TIMESTAMP, NULL),
    ('Feature CC', 4, ST_MakePoint(150.6608, -75.5317), CURRENT_TIMESTAMP, NULL);