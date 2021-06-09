#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["AFORO255.AZURE.Security/AFORO255.AZURE.Security.csproj", "AFORO255.AZURE.Security/"]
RUN dotnet restore "AFORO255.AZURE.Security/AFORO255.AZURE.Security.csproj"
COPY . .
WORKDIR "/src/AFORO255.AZURE.Security"
RUN dotnet build "AFORO255.AZURE.Security.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AFORO255.AZURE.Security.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AFORO255.AZURE.Security.dll"]