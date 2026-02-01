$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent $PSScriptRoot
$outputDir = Join-Path $repoRoot 'audits'

New-Item -ItemType Directory -Force -Path $outputDir | Out-Null

dotnet --info | Out-File (Join-Path $outputDir 'dotnet-info.txt') -Encoding utf8
dotnet list package --include-transitive | Out-File (Join-Path $outputDir 'nuget-packages.txt') -Encoding utf8
dotnet list package --vulnerable --include-transitive | Out-File (Join-Path $outputDir 'dotnet-vulnerable.txt') -Encoding utf8
