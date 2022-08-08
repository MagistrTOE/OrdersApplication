- *Web приложение для создания и отображения заказов*
- *Backend написан на .NET Core 6 Web API*
- *Frontend написан на React + TypeScript с применением CSS стилей*
- *БД: PostgreSQL, подключение к БД: User ID=postgres;Password=password;Host=localhost;Port=5432*

Запуск проекта:
1. Склонировать с репозитория "OrdersApplication" все файлы 
2. Скачать и запустить Docker
3. Находясь в папке с файлом docker-compose, поднять контейнеры командой в терминале **docker-compose up** 
4. Через терминал применить миграции командой **dotnet ef database update**
5. Находясь в папке myorders.react-typescript, запустить React приложение командой в терминале **npm run start** 
