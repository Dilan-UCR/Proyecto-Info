# Imagen base para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Imagen para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PDF_Server.csproj", "./"]
RUN dotnet restore "./PDF_Server.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "./PDF_Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Imagen para publicar
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PDF_Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final (la que se ejecuta)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDF_Server.dll"]
