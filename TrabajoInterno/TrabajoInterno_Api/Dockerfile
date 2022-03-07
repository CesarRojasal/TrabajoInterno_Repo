#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./TrabajoInterno/TrabajoInterno_Api/TrabajoInterno_Api.csproj", "TrabajoInterno_Api/"]
RUN dotnet restore "TrabajoInterno_Api/TrabajoInterno_Api.csproj"
COPY . .
WORKDIR "/src/TrabajoInterno/TrabajoInterno_Api"
RUN dotnet build "TrabajoInterno_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrabajoInterno_Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrabajoInterno_Api.dll"]
