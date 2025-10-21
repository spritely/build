FROM mcr.microsoft.com/dotnet/sdk:8.0.415-noble-amd64 AS build
WORKDIR /app
COPY . .
RUN dotnet build TestProject

FROM mcr.microsoft.com/dotnet/runtime:8.0.21-noble-amd64
WORKDIR /app
COPY --from=build /app/TestProject/bin/Debug/net8.0 .
CMD ["dotnet", "TestProject.dll"]
