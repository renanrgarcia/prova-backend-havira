FROM postgis/postgis

RUN apt-get update && apt-get install -y postgis postgresql-postgis && rm -rf /var/lib/apt/lists/*

COPY init.sql /docker-entrypoint-initdb.d/

EXPOSE 5432