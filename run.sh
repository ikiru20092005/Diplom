#!/bin/bash
# Скрипт для быстрого запуска CoreStore CRM на Linux/WSL

#!/bin/bash

echo "========================================="
echo "CoreStore CRM - Система управления CRM"
echo "========================================="
echo ""

# Проверка .NET
echo "Проверка установки .NET 8..."
if ! command -v dotnet &> /dev/null; then
	echo "❌ .NET не установлен!"
	echo "Скачайте с https://dotnet.microsoft.com/download"
	exit 1
fi

dotnet --version
echo "✅ .NET установлен"
echo ""

# Проверка MySQL
echo "Проверка подключения к MySQL..."
if mysql -u root -e "SELECT 1 FROM corestorecrm.user LIMIT 1" 2>/dev/null; then
	echo "✅ MySQL доступен"
else
	echo "⚠️  MySQL недоступен"
	echo "Убедитесь, что:"
	echo "  1. MySQL запущен"
	echo "  2. База данных 'corestorecrm' существует"
	echo "  3. Пользователь 'root' имеет доступ"
	echo ""
fi

echo ""
echo "========== ДЕЙСТВИЯ =========="
echo "1. Восстановление пакетов..."
dotnet restore

echo ""
echo "2. Сборка проекта..."
dotnet build -c Release

echo ""
echo "3. Запуск приложения..."
dotnet run -c Release

echo ""
echo "========================================="
echo "Приложение закрыто."
echo "========================================="
