# PowerShell скрипт для запуска CoreStore CRM
# Использование: .\run.ps1

Write-Host "=========================================" -ForegroundColor Cyan
Write-Host "CoreStore CRM - Система управления CRM" -ForegroundColor Cyan
Write-Host "=========================================" -ForegroundColor Cyan
Write-Host ""

# Проверка .NET
Write-Host "Проверка установки .NET 8..." -ForegroundColor Yellow
$dotnet = Get-Command dotnet -ErrorAction SilentlyContinue
if ($null -eq $dotnet) {
	Write-Host "❌ .NET не установлен!" -ForegroundColor Red
	Write-Host "Скачайте с https://dotnet.microsoft.com/download" -ForegroundColor Red
	Exit 1
}

$version = dotnet --version
Write-Host "✅ .NET версия: $version" -ForegroundColor Green
Write-Host ""

# Проверка путей
Write-Host "Текущая папка: $(Get-Location)" -ForegroundColor Gray
Write-Host ""

# Восстановление пакетов
Write-Host "1️⃣  Восстановление NuGet пакетов..." -ForegroundColor Yellow
Write-Host "================================================" -ForegroundColor Gray
dotnet restore
if ($LASTEXITCODE -ne 0) {
	Write-Host "❌ Ошибка при восстановлении пакетов!" -ForegroundColor Red
	Exit 1
}
Write-Host ""

# Сборка проекта
Write-Host "2️⃣  Сборка проекта..." -ForegroundColor Yellow
Write-Host "================================================" -ForegroundColor Gray
dotnet build -c Release
if ($LASTEXITCODE -ne 0) {
	Write-Host "❌ Ошибка при сборке!" -ForegroundColor Red
	Exit 1
}
Write-Host ""

# Запуск приложения
Write-Host "3️⃣  Запуск приложения..." -ForegroundColor Yellow
Write-Host "================================================" -ForegroundColor Gray
Write-Host "Точка входа: CoreStoreCRM.Forms.LoginForm" -ForegroundColor Gray
Write-Host ""

dotnet run -c Release

Write-Host ""
Write-Host "=========================================" -ForegroundColor Cyan
Write-Host "Приложение закрыто." -ForegroundColor Gray
Write-Host "=========================================" -ForegroundColor Cyan
