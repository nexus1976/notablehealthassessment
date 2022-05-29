FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /src
COPY nh.health.sln ./ 
COPY nh.health.msv/*.csproj ./nh.health.msv/
COPY nh.health.domain/*.csproj ./nh.health.domain/
COPY nh.health.infrastructure.dal.command/*.csproj ./nh.health.infrastructure.dal.command/
COPY nh.health.infrastructure.dal.read/*.csproj ./nh.health.infrastructure.dal.read/
RUN dotnet restore
COPY . .

WORKDIR /src/nh.health.infrastructure.dal.read
RUN dotnet build -c Release -o /app

WORKDIR /src/nh.health.infrastructure.dal.command
RUN dotnet build -c Release -o /app

WORKDIR /src/nh.health.domain
RUN dotnet build -c Release -o /app

WORKDIR /src/nh.health.msv
RUN dotnet build -c Release -o /app

FROM build-env AS publish
RUN dotnet publish "nh.health.msv.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nh.health.msv.dll"]