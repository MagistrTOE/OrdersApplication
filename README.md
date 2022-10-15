 Описание 
 --------
- *Web приложение для создания и отображения заказов*
- *Backend написан на .NET Core 6 Web API*
- *Frontend написан на React + TypeScript с применением CSS стилей*
- *БД: PostgreSQL*

Конфигурация
------------
- *Подключение к БД:*
  ```yaml
  "ConnectionStrings": {
    "MyOrdersContext": "User ID=postgres;Password=password;Host=mydatabase;Port=5432;Database=MyOrdersDb;"
  }
  ```
Запуск проекта:
---------------
1. Склонировать с репозитория **OrdersApplication** все файлы 
2. Скачать и запустить **Docker**
3. Находясь в папке с файлом **docker-compose**, скачать образы и поднять контейнеры командой в терминале:
  ```docker-compose up```
4. Находясь в папке **MyOrders/MyOrders.Infrantructure** через терминал применить миграции командой:
  ```dotnet ef database update```
5. Находясь в папке **myorders.react-typescript**, установить все необходимые зависимости командой в терминале:
  ```npm install```
6. Запустить React приложение командой:
  ```npm run start``` 
