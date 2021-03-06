# Управление сотрудниками

## Требования

- .NET SDK 5.0
- MS SQL Server 2017+

## Порядок запуска

1. Скачать репозиторий
2. Отредактировать конфигурационный файл
3. Выполнить `dotnet run --project EmployeeManager`
4. Перейти по адресу `http://localhost:5000`

Приложение было протестировано с MS SQL Server 2017 в docker контейнере, комманда для запуска контейнера со стандартным файолом конфигурации приложения

```sh
docker run --name EmployeeManager -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=dF76h1hu)" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

## Поля конфигурационного файла

Для вступления в силу необходимо перезапустить приложение

`EmployeeManagerDb` - строка подключения к базе данных, примеры строки подключения содержится в конфигурационных файлах в репозитории. Возможные строки подключения можно найти на [сайте](https://www.connectionstrings.com/sql-server/).

`Validation` - значение `true` включает проверку приходящих значений, значение `false` выключает проверки.

`Seed` - значение `true` включает автоматическое заполнение базы данных должностями, значение `false` выключает заполнение.
