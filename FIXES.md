# ИСПРАВЛЕНИЕ: АВТОРИЗАЦИЯ

## Проблема
Авторизация не работала, даже при вводе правильного логина и пароля из таблицы `user`.

## Причина
**Пароли в БД хешированы с использованием BCrypt**, но код приложения использовал SHA256 для хеширования. Это привело к несовпадению хешей при проверке пароля.

Хешированный пароль в БД: `$2a$11$k8BXUWXswlmd9r2TInKkaOvLi0iFtU92s.0sgAx3F6/lH95OPxaYq` (формат BCrypt)

## Решение
Были внесены следующие изменения:

### 1. Добавлен пакет BCrypt.Net-Next
**Файл:** `CoreStoreCRM.csproj`
```xml
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
```

### 2. Обновлен класс PasswordHelper
**Файл:** `Utilities/PasswordHelper.cs`

**Было:**
```csharp
using System.Security.Cryptography;
public class PasswordHelper
{
	public static string HashPassword(string password)
	{
		using (var sha256 = SHA256.Create())
		{
			var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
			return Convert.ToBase64String(hashedBytes);
		}
	}
}
```

**Стало:**
```csharp
using BCrypt.Net;
public class PasswordHelper
{
	public static string HashPassword(string password)
	{
		return BCrypt.Net.BCrypt.HashPassword(password);
	}

	public static bool VerifyPassword(string password, string hash)
	{
		try
		{
			return BCrypt.Net.BCrypt.Verify(password, hash);
		}
		catch
		{
			return false;
		}
	}
}
```

### 3. Переработана авторизация в UserRepository
**Файл:** `DataAccess/UserRepository.cs`

**Было:**
- Передавали уже хешированный пароль в хранимую процедуру
- Процедура сравнивала хеши (но они не совпадали)

**Стало:**
- Получаем пользователя по email напрямую через SQL запрос
- Извлекаем хеш пароля из БД
- Используем BCrypt.Verify() для проверки

```csharp
public User GetUserByCredentials(string email, string password)
{
	// Получаем пользователя по email
	var command = new MySqlCommand(
		"SELECT userId, email, name, phone, roleId, passwordHash FROM `user` WHERE email = @email",
		connection);

	// Читаем данные
	if (reader.Read())
	{
		var passwordHash = reader["passwordHash"].ToString();

		// Проверяем пароль используя BCrypt
		if (Utilities.PasswordHelper.VerifyPassword(password, passwordHash))
		{
			// Возвращаем пользователя
		}
	}
}
```

### 4. Обновлен LoginForm
**Файл:** `Forms/LoginForm.cs`

**Было:**
```csharp
var user = userRepo.GetUserByCredentials(
	textBoxEmail.Text, 
	PasswordHelper.HashPassword(textBoxPassword.Text)  // ХЕШ
);
```

**Стало:**
```csharp
var user = userRepo.GetUserByCredentials(
	textBoxEmail.Text, 
	textBoxPassword.Text  // ОТКРЫТЫЙ ПАРОЛЬ
);
```

### 5. Обновлена строка подключения
**Файл:** `DataAccess/DatabaseHelper.cs`

Добавлена ваша строка подключения:
```csharp
private static readonly string ConnectionString = "Server=localhost;Database=corestorecrm;uid=root;pwd=;";
```

## Тестирование

Теперь авторизация работает с тестовыми учетными данными:

| Роль | Email | Пароль |
|------|-------|--------|
| Клиент | ivan@mail.com | password |
| Менеджер | manager@mail.com | password |
| Администратор | admin@mail.com | password |

## Дополнительные улучшения безопасности

Если вы захотите добавить нового пользователя в БД, используйте BCrypt:

```sql
INSERT INTO user (email, passwordHash, name, phone, roleId) 
VALUES ('user@example.com', '$2a$11$YOUR_BCRYPT_HASH_HERE', 'Имя', '+7999000000', 1);
```

Для генерации BCrypt хеша в C#:
```csharp
string password = "myPassword123";
string hash = BCrypt.Net.BCrypt.HashPassword(password);
```

## Проверка подключения

При запуске приложение автоматически проверяет подключение к БД. Если вы видите ошибку:
- Убедитесь, что MySQL запущен
- Проверьте параметры в DatabaseHelper.cs
- Убедитесь, что база данных `corestorecrm` существует

---

**Дата исправления:** 2024
**Версия:** 1.1
