FROM mcr.microsoft.com/dotnet/sdk:10.0.404-noble-amd64@sha256:a82c44c2efe00953d66a37e90d307c4cfbd1e974b16e3b2a2fc665331946c9af AS build
WORKDIR /app
COPY . .
RUN dotnet build TestProject

FROM mcr.microsoft.com/dotnet/runtime:10.0.15-noble-amd64@sha256:785257773ab481e31d7f42401b03917433978ef53724a1162e3c60616b8b7de8
WORKDIR /app
COPY --from=build /app/TestProject/bin/Debug/net10.0 .
CMD ["dotnet", "TestProject.dll"]
