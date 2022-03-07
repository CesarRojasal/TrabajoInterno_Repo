#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TrabajoInterno/TrabajoInterno_Api_Persona/TrabajoInterno_Api_Persona.csproj", "TrabajoInterno_Api_Persona/"]
RUN dotnet restore "TrabajoInterno/TrabajoInterno_Api_Persona/TrabajoInterno_Api_Persona.csproj"
COPY . .
WORKDIR "/src/TrabajoInterno_Api_Persona"
RUN dotnet build "TrabajoInterno_Api_Persona.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrabajoInterno_Api_Persona.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrabajoInterno_Api_Persona.dll"]
