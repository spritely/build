FROM mcr.microsoft.com/dotnet/sdk:10.0.102-noble-amd64@sha256:6a135580d677983f9bf4094fe1918a64e80536b9544e6c68160f6a515a5312f0 AS build
WORKDIR /app
COPY . .
RUN dotnet build TestProject

FROM mcr.microsoft.com/dotnet/runtime:10.0.2-noble-amd64@sha256:7686158c2690de09ce15040250018b2f5c6a5952fed668a2e274f1d4b3203e1a
WORKDIR /app
COPY --from=build /app/TestProject/bin/Debug/net10.0 .
CMD ["dotnet", "TestProject.dll"]
