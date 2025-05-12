ARG SDK_VARIANT=8.0.408-noble-amd64
ARG RUNTIME_VARIANT=8.0.15-noble-amd64

FROM mcr.microsoft.com/dotnet/sdk:${SDK_VARIANT} AS build
WORKDIR /app
COPY . .
RUN dotnet build TestProject

FROM mcr.microsoft.com/dotnet/runtime:${RUNTIME_VARIANT}
WORKDIR /app
COPY --from=build /app/TestProject/bin/Debug/net8.0 .
CMD ["dotnet", "TestProject.dll"]
