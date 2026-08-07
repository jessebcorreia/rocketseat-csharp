param (
    [string]$OutputPath = $PSScriptRoot
)

$rsa = [System.Security.Cryptography.RSA]::Create(2048)

try {
    $privateKeyPath = Join-Path $OutputPath "private-key.pem"
    $publicKeyPath = Join-Path $OutputPath "public-key.pem"
    $privateKeyBase64Path = Join-Path $OutputPath "private-key.txt"
    $publicKeyBase64Path = Join-Path $OutputPath "public-key.txt"

    $privateKeyPem = $rsa.ExportPkcs8PrivateKeyPem()
    $publicKeyPem = $rsa.ExportSubjectPublicKeyInfoPem()

    [IO.File]::WriteAllText($privateKeyPath, $privateKeyPem)
    [IO.File]::WriteAllText($publicKeyPath, $publicKeyPem)

    $privateKeyBase64 = [Convert]::ToBase64String(
        [Text.Encoding]::UTF8.GetBytes($privateKeyPem)
    )

    $publicKeyBase64 = [Convert]::ToBase64String(
        [Text.Encoding]::UTF8.GetBytes($publicKeyPem)
    )

    [IO.File]::WriteAllText($privateKeyBase64Path, $privateKeyBase64)
    [IO.File]::WriteAllText($publicKeyBase64Path, $publicKeyBase64)

    Write-Host "Chaves geradas com sucesso" -ForegroundColor Green
    Write-Host $privateKeyPath -ForegroundColor DarkGray
    Write-Host $publicKeyPath -ForegroundColor DarkGray
    Write-Host $privateKeyBase64Path -ForegroundColor DarkGray
    Write-Host $publicKeyBase64Path -ForegroundColor DarkGray
    Write-Host ""
}
catch {
    Write-Host "Erro ao gerar as chaves no diretório listado abaixo" -ForegroundColor Red
    Write-Host $privateKeyPath -ForegroundColor DarkGray
    Write-Host $publicKeyPath -ForegroundColor DarkGray
    Write-Host ""
    Write-Host $_.Exception.Message
}
finally {
    $rsa.Dispose()
}
