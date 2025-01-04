# Prova Prática: Criação de API .NET (C#) com PostGIS, Docker e GeoJSON

## Visão Geral

Este projeto visa implementar uma API RESTful em .NET (C#) que realiza operações de CRUD em um banco de dados PostgreSQL com extensão PostGIS. A API é construída utilizando o framework ASP.NET Core e o ORM Entity Framework Core. A API é disponibilizada em um container Docker e utiliza o formato GeoJSON para representar os dados geoespaciais.

## Implementação

### 1. Criação dos Projetos da API

- Crie uma nova solução no Visual Studio ou usando o CLI do .NET (`dotnet new sln -n Havira.Api.Congresso`).
- Adicione os projetos com as seguintes estruturas:
  - **Havira.API**: Projeto de API ASP.NET Core (`dotnet new webapi -n Havira.API`).
  - **Havira.Application**: Projeto de Class Library (`dotnet new classlib -n Havira.Application`).
  - **Havira.Business**: Projeto de Class Library (`dotnet new classlib -n Havira.Business`).
  - **Havira.Data**: Projeto de Class Library (`dotnet new classlib -n Havira.Data`).
  - **Havira.Infra.Ioc**: Projeto de Class Library (`dotnet new classlib -n Havira.Infra.Ioc`).
- Adicione os projetos na solução (Ex: `dotnet sln add App.API/App.API.csproj`)

### 2. Configuração do Projeto Havira.API

- Adicione as referências necessárias nos projetos:
  - `Havira.API` deve referenciar `Havira.Application`.
  - `Havira.Application` deve referenciar `Havira.Business` e `Havira.Data`.
  - `Havira.Data` deve referenciar `Havira.Business`.
  - `Havira.Infra.Ioc` deve referenciar `Havira.Application`, `Havira.Business` e `Havira.Data`.
    - Ex: `dotnet add Havira.API/Havira.API.csproj reference Havira.Application/Havira.Application.csproj`.
