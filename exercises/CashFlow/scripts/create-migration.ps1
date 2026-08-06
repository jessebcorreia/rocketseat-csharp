$name = Read-Host "Enter the migration name"

if ([string]::IsNullOrWhiteSpace($name)) {
    Write-Error "Migration name is required."
    exit 1
}

$root = Split-Path $PSScriptRoot -Parent

Write-Host "Creating migration: $name"

dotnet ef migrations add $name `
    --project "$root/src/CashFlow.Infrastructure" `
    --startup-project "$root/src/CashFlow.Api"
