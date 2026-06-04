# 🎯 РЕКОМЕНДАЦИИ ДЛЯ ИСПОЛЬЗОВАНИЯ

## Перед первым запуском

### 1. Убедитесь, что установлено:
```
✅ .NET 8.0 Runtime (https://dotnet.microsoft.com/download)
✅ MySQL/MariaDB (https://www.mysql.com/downloads/)
✅ Visual Studio Community 2026 (опционально)
```

### 2. Подготовьте базу данных:

**Вариант 1: Через phpMyAdmin**
```sql
-- Создайте БД
CREATE DATABASE corestorecrm;

-- Импортируйте дамп из файла "corestorecrm (6).txt"
```

**Вариант 2: Через командную строку**
```bash
mysql -u root -p < "path/to/corestorecrm (6).txt"
```

### 3. Проверьте строку подключения:

Откройте `CoreStoreCRM/DataAccess/DatabaseHelper.cs`:

```csharp
// Убедитесь, что параметры соответствуют вашим:
private static readonly string ConnectionString = 
	"Server=localhost;Database=corestorecrm;uid=root;pwd=;";
```

Параметры:
- `Server` - адрес MySQL (обычно localhost)
- `Database` - имя БД (corestorecrm)
- `uid` - имя пользователя (root)
- `pwd` - пароль (пусто если нет)

---

## Первый запуск

### Способ 1: PowerShell (Рекомендуется на Windows)
```powershell
cd E:\CoreStoreCRM\
.\run.ps1
```

### Способ 2: Командная строка
```cmd
cd E:\CoreStoreCRM\
dotnet run
```

### Способ 3: Visual Studio
1. Откройте проект в Visual Studio
2. Нажмите F5 (Debug) или Ctrl+F5 (Release)

### Способ 4: Bash (Linux/WSL)
```bash
cd /mnt/e/CoreStoreCRM/
./run.sh
```

---

## Вход в систему

**Окно входа заполняется автоматически:**
- Email: `ivan@mail.com`
- Пароль: `password`

Просто нажмите кнопку "Вход" ➜

---

## Возможные проблемы и решения

### ❌ Ошибка: "Не удается найти файл конфигурации"
**Решение:**
```bash
dotnet restore
dotnet build
```

### ❌ Ошибка: "Не удалось подключиться к БД"
**Проверьте:**
1. MySQL запущен? `mysql -u root -e "SELECT 1;"`
2. Правильная ли строка подключения?
3. Существует ли база данных? `mysql -u root -e "SHOW DATABASES;"`

### ❌ Ошибка: "Неправильный email или пароль"
**Проверьте:**
1. Дамп БД импортирован? `mysql corestorecrm -u root -e "SELECT * FROM user;"`
2. Учетные данные: ivan@mail.com / password
3. Хеши в БД начинаются с `$2a$`?

### ❌ Приложение зависает при запуске
**Решение:**
1. Проверьте скорость подключения
2. Убедитесь, что MySQL полностью загружен
3. Посмотрите логи MySQL

### ❌ Ошибка: "System.IO.FileNotFoundException"
**Решение:**
```bash
dotnet clean
dotnet restore
dotnet build --configuration Release
```

---

## Работа с приложением

### Клиент (ivan@mail.com):

1. **Главное меню:**
   - Обращения - просмотр и создание
   - Профиль - редактирование данных
   - Заказы - просмотр заказов
   - Выход - выход из системы

2. **Создание обращения:**
   - Нажмите "Обращения"
   - Нажмите "Создать"
   - Выберите тип (Вопрос/Проблема/Поддержка)
   - Введите описание
   - Нажмите "Создать"

3. **Отправка сообщения:**
   - Выберите обращение из списка
   - Нажмите "Просмотреть"
   - Введите сообщение
   - Нажмите "Отправить"

### Менеджер (manager@mail.com):

1. **Управление обращениями:**
   - Видит все обращения
   - Может отвечать на сообщения
   - Может закрывать обращения

2. **Ответ на обращение:**
   - Откройте обращение
   - Введите ответ в текстовое поле
   - Нажмите "Отправить"

3. **Закрытие обращения:**
   - Выберите обращение
   - Нажмите "Закрыть"
   - Подтвердите действие

### Администратор (admin@mail.com):

1. **Все функции менеджера +**
2. **Дополнительно:**
   - Кнопка "Администрация" видна
   - Вкладка "Отчеты" - закрытые обращения
   - Вкладка "Пользователи" - список пользователей

---

## Рекомендации по безопасности

### ⚠️ Перед использованием в production:

1. **Смените пароли по умолчанию:**
```sql
UPDATE user SET passwordHash = 'новый_bcrypt_хеш' WHERE email = 'admin@mail.com';
```

2. **Включите SSL для БД:**
```csharp
private static readonly string ConnectionString = 
	"Server=your_server;Database=corestorecrm;uid=user;pwd=pass;SslMode=Required;";
```

3. **Создайте резервные копии:**
```bash
mysqldump -u root corestorecrm > backup.sql
```

4. **Ограничьте доступ к приложению:**
   - Разрешите только авторизованным пользователям
   - Используйте VPN если необходимо
   - Ведите логи доступа

5. **Обновляйте зависимости:**
```bash
dotnet list package --outdated
dotnet package update
```

---

## Оптимизация производительности

### Для быстрого запуска:

1. **Release конфигурация:**
```bash
dotnet run -c Release
```

2. **Создание standalone exe:**
```bash
dotnet publish -c Release -r win-x64 --self-contained
```

3. **Кеширование:**
   - Приложение автоматически кеширует данные сеанса
   - При необходимости нажимайте "Обновить"

---

## Резервное копирование

### Еженедельная архивировка:

```bash
# Скрипт для Windows
date /t > backup_date.txt
mysqldump -u root corestorecrm > backup_%date:~10,4%%date:~4,2%%date:~7,2%.sql
```

```bash
# Скрипт для Linux
mysqldump -u root corestorecrm > backup_$(date +\%Y\%m\%d).sql
```

---

## Обновление приложения

### Для получения обновлений:

1. **Загрузите новую версию**
2. **Сделайте backup базы данных**
3. **Обновите зависимости:**
```bash
dotnet restore
```

4. **Пересоберите приложение:**
```bash
dotnet clean
dotnet build -c Release
```

5. **Запустите и протестируйте**

---

## Контрольный список для администратора

### ☑️ Ежемесячно:
- [ ] Проверить размер базы данных
- [ ] Сделать backup
- [ ] Проверить логи ошибок
- [ ] Обновить список пользователей

### ☑️ Еженедельно:
- [ ] Архивировать данные
- [ ] Проверить производительность
- [ ] Посмотреть статистику обращений

### ☑️ Ежедневно:
- [ ] Проверить новые обращения
- [ ] Ответить на сообщения клиентов
- [ ] Закрыть решенные обращения

---

## Полезные команды

```bash
# Проверка версии .NET
dotnet --version

# Список установленных пакетов
dotnet list package

# Поиск уязвимостей
dotnet list package --vulnerable

# Просмотр процессов
dotnet list package --outdated

# Очистка кэша NuGet
dotnet nuget locals all --clear

# Запуск тестов (если добавите)
dotnet test
```

---

## Документация

**Начинайте с этих файлов в порядке:**

1. 📖 **README.md** - что это такое
2. 🚀 **INSTALL.md** - как установить
3. 👤 **USER_GUIDE.md** - как использовать
4. 🧪 **TESTING.md** - как тестировать
5. 🔧 **FIXES.md** - что было исправлено
6. 📊 **PROJECT_SUMMARY.md** - итоговый отчет
7. ✅ **CHECKLIST.md** - проверочный список

---

## Поддержка

### При возникновении проблем:

1. **Проверьте логи:**
   - Консоль приложения
   - Event Viewer (Windows)
   - MySQL логи

2. **Проверьте файлы:**
   - TESTING.md - "Возможные проблемы"
   - FIXES.md - описание архитектуры

3. **Попробуйте:**
   - Пересборка проекта
   - Перезагрузка MySQL
   - Очистка кэша (dotnet clean)

---

## Полезные ссылки

- 🌐 [.NET Documentation](https://docs.microsoft.com/dotnet/)
- 📚 [MySQL Documentation](https://dev.mysql.com/doc/)
- 🔐 [BCrypt.Net Documentation](https://github.com/BcryptNet/bcrypt.net)
- 💾 [GitHub C# Style Guide](https://google.github.io/styleguide/csharp-style.html)

---

## Заключение

**CoreStore CRM готова к использованию!** 🎉

Следуйте этим рекомендациям и все будет работать гладко.

### Главное помните:
- ✅ Регулярно делайте backup
- ✅ Проверяйте логи
- ✅ Обновляйте зависимости
- ✅ Тестируйте после обновлений

**Удачи в использовании! 🚀**

---

*Дата: 2024 | Версия: 1.1 | Статус: Production Ready*
