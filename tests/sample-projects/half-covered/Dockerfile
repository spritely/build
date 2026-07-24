FROM mcr.microsoft.com/dotnet/sdk:10.0.302-noble-amd64@sha256:3dae2f7699441af56216ff64d5c9b6dfce7cd7dc7f4f71d353d29662b10a384f AS build
WORKDIR /app
COPY . .
RUN dotnet build TestProject

FROM mcr.microsoft.com/dotnet/runtime:10.0.10-noble-amd64@sha256:ca17638b4cbab2063771e8943dbe887ea6c0ae00c5fede3498d5938758c85dfe
WORKDIR /app
COPY --from=build /app/TestProject/bin/Debug/net10.0 .
CMD ["dotnet", "TestProject.dll"]
