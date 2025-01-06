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
  - `Havira.API` deve referenciar `Havira.Application` e `Havira.Infra.Ioc`.
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
- Adicionar o pacote FluentValidation para validação de entidades. Criar as classes de validação para as entidades.
- Criar a interface e implemente as classes de notificação do Sistema ("Event Source").

#### b. **Havira.Data**

- Configurar o DbContext para gerenciar as operações de banco de dados.
  - Adicionar o pacote NuGet `EntityFrameworkCore` como ORM.
  - Adicionar o pacote NuGet `EntityFrameworkCore.PostgreSQL` para trabalhar com o PostgreSQL.
  - Criar a classe `MeuDbContext`: classe principal do EF Core que coordena sua funcionalidade para um modelo de dados.
- Implementar as interfaces de repositório utilizando o Entity Framework.
  - Criar o repositório base `Repository`, implementando `IRepository` (Que contem o contrato das operações de CRUD).
  - Criar repositório para a entidade `Localizacao`. Ele estende `Repository` e implementa a interface para a entidade (`ILocalizacaoRepository`). Neles, as interfaces de repositório fornecem operações específicas para a entidade.

#### c. **Havira.Application**

- Criar serviços que encapsulam a lógica de aplicação. Esses serviços utilizam repositórios da camada `Data` e regras de negócio da camada `Business` para realizar operações.
- Estrutura da camada:
  - `Interfaces`: Define contratos para os serviços que serão implementados na pasta App.
  - `ViewModels`: Representa os modelos de dados que serão expostos para a camada API.
  - `Mapper`: Responsável por mapear as entidades de domínio (Models) para ViewModels e vice-versa.
    - AutoMapper: biblioteca .NET para mapear automaticamente objetos de um tipo para outro. Ex: ViewModels <> Models
  - `App`: Contém a lógica de aplicação, incluindo serviços que orquestram as operações de negócio e interagem com outras camadas.
- Primeiro, definir a Interface para a camada App (`ILocalizacaoApplication`).
  - `IBaseApplication` contém o molde para criação com serviços base. Porém, cada interface contém seus contratos próprios.
- Criar as ViewModels necessárias aos contratos definidos nas Interfaces (`LocalizacaoViewModel`).
- Criar a classe AutoMapper.
  - Instalar o pacote `DependencyInjection` para integrar o AutoMapper com o sistema de injeção de dependência.
  - Implementar os mapeamentos dos modelos de domínio (Models) para ViewModels e vice-versa.
- Criar as classes da camada App com os serviços.
  - Adicionar o pacote FluentValidation (validação de modelos) ao projeto.
  - Criar a classe abstrata `BaseApplication`, as demais classes de `App` devem herdar dela, além de implementar as suas interfaces.
    - Em `BaseApplication` é padronizado o método de validação e processamento de mensagens de erro.
  - Criar as demais classes da camada App com os serviços (`LocalizacaoApplication`).

#### d. **Havira.Infra.Ioc**

- Registrar todos os serviços e repositórios para gerenciar a injeção de dependências no `Program.cs` da API.
- Criar o container de injeção de dependência: `DependencyInjectionConfig.cs`.
- Registrar o container de injeção de dependência em `ApiConfig.cs` -> services.ResolveDependencies(configuration).

#### f. **HubConnect.API**

- A classe `ApiConfig` deve conter a coleção de serviços e de build.
- Criar controladores para expor os serviços da camada de Application como endpoints REST.
  - Criar a classe `MainController` que herda de `ControllerBase`.
  - Criar a classe `LocalizacaoController` que herda de `MainController`.
  - Adicionar os pacotes `Microsoft.AspNetCore.Mvc.Versioning` e `Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer` ao projeto.
  - Adicionar os serviços de versionamento das APIs (AddApiVersioning e AddVersionedApiExplorer) no `ApiConfig.cs`.
  - Insirir a anotação `ApiVersion` e `Route` na classe `LocalizacaoController`.
  - Adicionar o serviço `AddControllers` no `ApiConfig.cs`.
- Adicionar o serviço `AddDbContext` no `ApiConfig.cs`.
- Adicionar o pacote `NetTopologySuite.IO.GeoJSON4STJ` para trabalhar com GeoJSON.
- Para serializar e deserializar GeoJSON e Enums, criar um `JsonConverter` para cada tipo e registrá-los no `ApiConfig.cs`.
- Adicionar os serviços e as configurações de build no `Program.cs`.

### 4. Dockerização da API

- Criar o arquivo `Dockerfile` na raiz do projeto Havira.API para configurar a imagem do Docker.
- Utilizar multi-stage build para otimizar a criação da imagem:
  - **Base Image**: Define a imagem base para a aplicação com ASP.NET Core runtime.
  - **Build Stage**: Compila a aplicação utilizando uma imagem do SDK do .NET.
  - **Publish Stage**: Publica a aplicação em modo Release.
  - **Final Stage**: Cria a imagem final a partir da imagem base e define o ponto de entrada da aplicação. Assim, a imagem final fica menor e mais eficiente.

### 5. Propostas para próximos passos

- **Testes Unitários e de Integração**: Implementar testes automatizados para garantir a qualidade do código.
- **Expansão de Funcionalidades**: Adicionar novas operações e entidades para atender a requisitos futuros.
- **Segurança**: Implementar autenticação e autorização para proteger a API.
- **Paginação e Filtros**: Adicionar suporte a paginação e filtros para facilitar a consulta de dados.

## Implementação do Banco de Dados

### 1. PostgreSQL e PostGIS

- Criar arquivo init.sql para criar o banco de dados e as tabelas, bem como adicionar extensão PostGIS.
- Criar arquivo Dockerfile para configurar a imagem do PostgreSQL com PostGIS.
