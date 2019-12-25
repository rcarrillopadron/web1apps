#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Web1Apps.Api/Web1Apps.Api.csproj", "Web1Apps.Api/"]
RUN dotnet restore "Web1Apps.Api/Web1Apps.Api.csproj"
COPY . .
WORKDIR "/src/Web1Apps.Api"
RUN dotnet build "Web1Apps.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web1Apps.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web1Apps.Api.dll"]