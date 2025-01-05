FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Havira.API.csproj", "Havira.API/"]
RUN dotnet restore "Havira.API/Havira.API.csproj"
COPY . .
WORKDIR "/src/Havira.API"
RUN dotnet build "Havira.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Havira.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./Configuration /app/Configuration
ENTRYPOINT ["dotnet", "Havira.API.dll"]