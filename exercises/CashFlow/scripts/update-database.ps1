$root = Split-Path $PSScriptRoot -Parent

dotnet ef database update `
    --project "$root/src/CashFlow.Infrastructure" `
    --startup-project "$root/src/CashFlow.Api"
