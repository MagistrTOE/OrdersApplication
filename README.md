- *Приложение написано на .NET Core 6 Web API
- *БД: PostgreSQL, подключение к БД: User ID=postgres;Password=password;Host=localhost;Port=5432
- *Метод GET на получение всех заказов в базе
- *Метод POST на создание нового заказа, возвращается ID созданного заказа

Запуск проекта:
1. Скачать и запустить Docker
2. Поднять контейнеры командой в терминале **docker-compose up**
3. Через терминал применить миграции командой **dotnet ef database update**
4. В браузере перейти [http://localhost:5500/swagger/]
