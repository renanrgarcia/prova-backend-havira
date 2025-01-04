# Prova Prática: Criação de API .NET (C#) com PostGIS, Docker e GeoJSON

## Visão Geral

Este projeto visa implementar uma API RESTful em .NET (C#) que realiza operações de CRUD em um banco de dados PostgreSQL com extensão PostGIS. A API é construída utilizando o framework ASP.NET Core e o ORM Entity Framework Core. A API é disponibilizada em um container Docker e utiliza o formato GeoJSON para representar os dados geoespaciais.

## Estrutura da API

### 1. **Havira.API**

- **Objetivo**: Expor a aplicação como uma API RESTful.
- **Funcionalidades**:
  - Receber requisições HTTP e direcioná-las para a camada `Application`.
  - Retornar respostas aos clientes.
  - Implementar autenticação e autorização.

### 2. **Havira.Application**

- **Objetivo**: Coordenar a lógica de aplicação.
- **Funcionalidades**:
  - Implementar regras de aplicação e fluxos de trabalho.
  - Chamar `Business` para validações e `Data` para persistência.
  - Fornecer serviços para a camada `API`.

### 3. **Havira.Business**

- **Objetivo**: Definir regras de negócio e modelo de domínio.
- **Funcionalidades**:
  - Definir entidades e interfaces de repositórios.
  - Validar regras de negócio.

### 4. **Havira.Data**

- **Objetivo**: Implementar a persistência de dados.
- **Funcionalidades**:
  - Implementar repositórios usando Entity Framework.
  - Gerenciar mapeamento entre entidades e tabelas.

### 5. **Havira.Infra.Ioc**

- **Objetivo**: Configurar injeção de dependências e infraestrutura.
- **Funcionalidades**:
  - Registrar serviços e repositórios.
  - Gerenciar configuração global do sistema.

## Implementação da API

### 1. Criação dos Projetos da API

- Criar uma nova solução no Visual Studio ou usando o CLI do .NET (`dotnet new sln -n Havira.Api.Congresso`).
- Adicionar os projetos com as seguintes estruturas:
  - **Havira.API**: Projeto de API ASP.NET Core (`dotnet new webapi -n Havira.API`).
  - **Havira.Application**, **Havira.Business**, **Havira.Data**, **Havira.Infra.Ioc**: Projetos de Class Library (Ex: `dotnet new classlib -n Havira.Application`).
- Adicionar os projetos na solução (Ex: `dotnet sln add App.API/App.API.csproj`)

### 2. Configuração das referências

- Adicionar as referências necessárias nos projetos:
  - `Havira.API` deve referenciar `Havira.Application`.
  - `Havira.Application` deve referenciar `Havira.Business` e `Havira.Data`.
  - `Havira.Data` deve referenciar `Havira.Business`.
  - `Havira.Infra.Ioc` deve referenciar `Havira.Application`, `Havira.Business` e `Havira.Data`.
    - Ex: `dotnet add Havira.API/Havira.API.csproj reference Havira.Application/Havira.Application.csproj`.

### 3. Passo a passo

#### a. **Havira.Business**

- Criar a entidade base `Entity` e definir as constantes do SchemaDB `SchemaConsts`.
- Definir as entidades principais `Localizacao` e `Categoria`.
- Adicionar o pacote NuGet `NetTopologySuite` para trabalhar com dados geoespaciais (Point (X, Y) { SRID = 4326 }).
- Criar interfaces de repositório para cada entidade `IRepository`, como base, e `ILocalizacao`.
- Implemente a interface IUser para definições de Authentication e Authorization.
