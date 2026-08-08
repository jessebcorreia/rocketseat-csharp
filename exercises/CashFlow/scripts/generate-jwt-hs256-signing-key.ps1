param (
    [string]$OutputPath = $PSScriptRoot
)

$bytes = [byte[]]::new(32)

try {
    $random = [System.Security.Cryptography.RandomNumberGenerator]::Create()
    $random.GetBytes($bytes)

    $keyBase64 = [Convert]::ToBase64String($bytes)

    $keyPath = Join-Path $OutputPath "signing-key.txt"

    [IO.File]::WriteAllText($keyPath, $keyBase64)

    Write-Host "Chave gerada com sucesso" -ForegroundColor Green
    Write-Host $keyPath -ForegroundColor DarkGray
    Write-Host ""
}
catch {
    Write-Host "Erro ao gerar a chave" -ForegroundColor Red
    Write-Host $_.Exception.Message
}
finally {
    if ($random) {
        $random.Dispose()
    }
}
