FROM postgres:latest

RUN psql -c "CREATE EXTENSION postgis;"

COPY init.sql /docker-entrypoint-initdb.d/

EXPOSE 5432