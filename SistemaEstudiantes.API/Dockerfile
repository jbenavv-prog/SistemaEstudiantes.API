#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SistemaEstudiantes.API/SistemaEstudiantes.API.csproj", "SistemaEstudiantes.API/"]
COPY ["SistemaEstudiantes.Application/SistemaEstudiantes.Application.csproj", "SistemaEstudiantes.Application/"]
COPY ["DTOs/DTOs.csproj", "DTOs/"]
COPY ["SistemaEstudiantes.Domain/SistemaEstudiantes.Domain.csproj", "SistemaEstudiantes.Domain/"]
COPY ["SistemaEstudiantes.Infrastructure/SistemaEstudiantes.Infrastructure.csproj", "SistemaEstudiantes.Infrastructure/"]
RUN dotnet restore "./SistemaEstudiantes.API/SistemaEstudiantes.API.csproj"
COPY . .
WORKDIR "/src/SistemaEstudiantes.API"
RUN dotnet build "./SistemaEstudiantes.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SistemaEstudiantes.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaEstudiantes.API.dll"]