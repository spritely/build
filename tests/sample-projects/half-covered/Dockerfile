FROM mcr.microsoft.com/dotnet/sdk:10.0.404-noble-amd64@sha256:cd28130a4da76d2dc11c360b6d9f18c673d6fe15252f91c073ba358a1318cfb0 AS build
WORKDIR /app
COPY . .
RUN dotnet build TestProject

FROM mcr.microsoft.com/dotnet/runtime:10.0.15-noble-amd64@sha256:f4ee1b92a00425ca1fabc7fb25c9819a7a5ea0f36342e37e4998b582eb57b8c7
WORKDIR /app
COPY --from=build /app/TestProject/bin/Debug/net10.0 .
CMD ["dotnet", "TestProject.dll"]
