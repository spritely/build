FROM mcr.microsoft.com/dotnet/sdk:10.0.404-noble-amd64@sha256:ddbaedfc8b774389d91a511af08b77296f2c7a8d15d86f6214d2a87166933625 AS build
WORKDIR /app
COPY . .
RUN dotnet build TestProject

FROM mcr.microsoft.com/dotnet/runtime:10.0.15-noble-amd64@sha256:342e2476e856efde687241821612b1d6792a76192ca71a28e31147314821dbb0
WORKDIR /app
COPY --from=build /app/TestProject/bin/Debug/net10.0 .
CMD ["dotnet", "TestProject.dll"]
