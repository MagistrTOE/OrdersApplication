Project description 
 --------
- *Web application for creating and displaying orders*
- *Backend written in .NET Core 6 Web API*
- *Frontend is written in React + TypeScript using CSS styles*
- *Database: PostgreSQL*

Configuration
------------
- *Database connection:*
  ```yaml
  "ConnectionStrings": {
    "MyOrdersContext": "User ID=postgres;Password=password;Host=mydatabase;Port=5432;Database=MyOrdersDb;"
  }
  ```
  
Launch project:
---------------
1. Clone all files from the **OrdersApplication** repository 
2. Download and run **Docker**
3. Being in the folder with the **docker-compose** file, download the images and raise the containers with the command in the terminal:
  ```docker-compose up```
4. Being in the folder **MyOrders/MyOrders.Infrantructure** through the terminal, apply the migrations with the command:
  ```dotnet ef database update```
5. Being in the **myorders.react-typescript** folder, install all the necessary dependencies with the command in the terminal:
  ```npm install```
6. Run React app with command:
  ```npm run start``` 
  
Project overview:
---------------
<p align="center">
 <img src="https://github.com/MagistrTOE/OrdersApplication/blob/main/Review/Review.gif" text-aligncenter />
</p>
