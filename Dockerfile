# Build and test stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files for restore
COPY ERP.sln .
COPY Directory.Build.props .
COPY src/ERP.Domain/ERP.Domain.csproj src/ERP.Domain/
COPY src/ERP.Application/ERP.Application.csproj src/ERP.Application/
COPY src/ERP.Infrastructure/ERP.Infrastructure.csproj src/ERP.Infrastructure/
COPY tests/ERP.Domain.Tests/ERP.Domain.Tests.csproj tests/ERP.Domain.Tests/
COPY tests/ERP.Application.Tests/ERP.Application.Tests.csproj tests/ERP.Application.Tests/

# Restore dependencies
RUN dotnet restore ERP.sln \
    --runtime linux-x64 \
    /p:TargetFrameworks=net8.0

# Copy source code
COPY src/ERP.Domain/ src/ERP.Domain/
COPY src/ERP.Application/ src/ERP.Application/
COPY src/ERP.Infrastructure/ src/ERP.Infrastructure/
COPY tests/ERP.Domain.Tests/ tests/ERP.Domain.Tests/
COPY tests/ERP.Application.Tests/ tests/ERP.Application.Tests/

# Build
RUN dotnet build ERP.sln \
    -c Release \
    --no-restore \
    --framework net8.0

# Test stage
FROM build AS test
RUN dotnet test ERP.sln \
    -c Release \
    --no-build \
    --framework net8.0 \
    --logger "console;verbosity=normal"
