#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChallengeN5Now/ChallengeN5Now.API.csproj", "ChallengeN5Now/"]
COPY ["ChallengeN5Now.Business/ChallengeN5Now.Business.csproj", "ChallengeN5Now.Business/"]
COPY ["ChallengeN5Now.Data/ChallengeN5Now.Data.csproj", "ChallengeN5Now.Data/"]
COPY ["ChallengeN5Now.Domain/ChallengeN5Now.Domain.csproj", "ChallengeN5Now.Domain/"]
COPY ["ChallengeN5Now.Services/ChallengeN5Now.Services.csproj", "ChallengeN5Now.Services/"]
RUN dotnet restore "./ChallengeN5Now/ChallengeN5Now.API.csproj"
ENV ASPNETCORE_URLS="http://+:80;"
COPY . .
WORKDIR "/src/ChallengeN5Now"
RUN dotnet build "./ChallengeN5Now.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ChallengeN5Now.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChallengeN5Now.API.dll"]