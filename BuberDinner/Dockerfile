#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BuberDinner/BuberDinner.csproj", "BuberDinner/"]
COPY ["Buber.Application/Buber.Application.csproj", "Buber.Application/"]
COPY ["Buber.Contracts/Buber.Contracts.csproj", "Buber.Contracts/"]
COPY ["Buber.Domain/Buber.Domain.csproj", "Buber.Domain/"]
COPY ["Buber.Infrastructure/Buber.Infrastructure.csproj", "Buber.Infrastructure/"]
RUN dotnet restore "BuberDinner/BuberDinner.csproj"
COPY . .
WORKDIR "/src/BuberDinner"
RUN dotnet build "BuberDinner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BuberDinner.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BuberDinner.dll"]