# build

Repository for holding common GitHub actions workflows.

## Upgrades

For the list of available build agents on GitHub see: https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners/about-github-hosted-runners

## GitHub Usage

This build is designed to support 4 main scenarios:

- [Semantic Versioning Build](#semantic-versioning-build)
- [Build and Publish Container](#build-and-publish-container)
- [Build and Publish .NET Container](#build-and-publish-net-container)
- [Build and Publish .NET Package](#build-and-publish-net-package)

### Semantic Versioning Build

To setup a semantic versioning build, add a file called ./.github/workflows/build.yml with content similar to the following:

```yaml
name: Build

on: [push, workflow_dispatch]

env:
  BUILD_VERSION_TAG: v0.14.0

# Permissions required to apply semantic version tags to the repository
permissions:
  contents: write

jobs:
  build:
    name: Build
    runs-on: ubuntu-24.04

    steps:
      - id: version
        name: Get semantic version
        uses: spritely/actions.semantic-version/get@v0.2.2

      - name: Apply semantic version
        if: ${{ steps.version.outputs.branchName == github.event.repository.default_branch }}
        uses: spritely/actions.semantic-version/apply@v0.2.2
        with:
          version: ${{ steps.version.outputs.version }}
```

### Build and Publish Container

To setup a container build, add a file called ./.github/workflows/build.yml with content similar to the following:

```yaml
name: Build and Publish Container

on: [push, workflow_dispatch]

env:
  BUILD_VERSION_TAG: v0.14.0

# Permissions required for container to be able to publish container images and
# to do automatic semantic version tagging
permissions:
    actions: read
    checks: write
    contents: write
    packages: write

jobs:
  build:
    name: Build
    runs-on: ubuntu-24.04

    steps:
      - name: Build and publish container
        uses: spritely/build/container@v0.14
        with:
          registryUsername: ${{ github.actor }}
          registryPassword: ${{ github.token }}
          # Always prefix all names with the registry host name (an optional parameter that defaults to ghcr.io)
          # Otherwise, the build will attempt to publish to those registries, but will not have signed into them
          imageNames: ghcr.io/my-organization/repository-name
          # Optional - defaults are as follows:
          #context: ./
          #dockerfile: ./Dockerfile
```

### Build and Publish .NET Container

To setup a container build, add a file called ./.github/workflows/build.yml with content similar to the following:

```yaml
name: Build and Publish .NET Container

on: [push, workflow_dispatch]

env:
  BUILD_VERSION_TAG: v0.14.0

# Permissions required for dotnet-test-cover to report test results,
# for dotnet-container to be able to publish container images and
# to do automatic semantic version tagging
permissions:
    actions: read
    checks: write
    contents: write
    packages: write

jobs:
  build:
    name: Build
    runs-on: ubuntu-24.04

    steps:
      - name: Build and publish .NET container
        uses: spritely/build/dotnet-container@v0.14
        with:
          registryUsername: ${{ github.actor }}
          registryPassword: ${{ github.token }}
          # Always prefix all names with the registry host name (an optional parameter that defaults to ghcr.io)
          # Otherwise, the build will attempt to publish to those registries, but will not have signed into them
          imageNames: ghcr.io/my-organization/repository-name
          nugetAuthToken: ${{ github.token }}
          unitTestProjects: "**/*.Tests.csproj" # defaults to "**/*.UnitTests.csproj"
```

### Build and Publish .NET Package

To setup a NuGet package build, add a file called ./.github/workflows/build.yml with content similar to the following:

```yaml
name: Build and Publish .NET Package

on: [push, workflow_dispatch]

env:
  BUILD_VERSION_TAG: v0.14.0

# Permissions required for dotnet-test-cover to report test results,
# for dotnet-package to be able to publish NuGet packages and
# to do automatic semantic version tagging
# Note that respositories may also need to edit their package
# publishing permissions settings.
permissions:
    actions: read
    checks: write
    contents: write
    packages: write

jobs:
  build:
    name: Build
    runs-on: ubuntu-24.04

    steps:
      - name: Build and publish dotnet package
        uses: spritely/build/dotnet-package@v0.14
        with:
          registryUsername: ${{ github.actor }}
          registryPassword: ${{ github.token }}
          projectFile: MyProject.csproj
          projectDirectory: MyProject
          nugetAuthToken: ${{ github.token }}
          unitTestProjects: "**/*.Tests.csproj" # defaults to "**/*.UnitTests.csproj"
```
