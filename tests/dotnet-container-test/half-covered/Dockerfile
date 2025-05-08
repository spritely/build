ARG SDK_VARIANT=8.0.408-noble-amd64
ARG RUNTIME_VARIANT=8.0.15-noble-amd64

FROM mcr.microsoft.com/dotnet/sdk:${SDK_VARIANT} AS build
WORKDIR /TestProject
COPY . .
RUN dotnet build

FROM mcr.microsoft.com/dotnet/runtime:${RUNTIME_VARIANT}
WORKDIR /TestProject
COPY --from=build /TestProject/bin/Debug/net8.0 .
CMD ["dotnet", "run"]