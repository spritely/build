FROM mcr.microsoft.com/dotnet/sdk:10.0.101-noble-amd64 AS build
WORKDIR /app
COPY . .
RUN dotnet build TestProject

FROM mcr.microsoft.com/dotnet/runtime:10.0.1-noble-amd64
WORKDIR /app
COPY --from=build /app/TestProject/bin/Debug/net10.0 .
CMD ["dotnet", "TestProject.dll"]
