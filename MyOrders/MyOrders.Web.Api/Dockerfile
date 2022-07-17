#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyOrders/MyOrders.Web.Api/MyOrders.Web.Api.csproj", "MyOrders/MyOrders.Web.Api/"]
COPY ["MyOrders/MyOrders.Application/MyOrders.Application.csproj", "MyOrders/MyOrders.Application/"]
COPY ["MyOrders/MyOrders.Domain/MyOrders.Domain.csproj", "MyOrders/MyOrders.Domain/"]
COPY ["MyOrders/MyOrders.Infrastructure/MyOrders.Infrastructure.csproj", "MyOrders/MyOrders.Infrastructure/"]
RUN dotnet restore "MyOrders/MyOrders.Web.Api/MyOrders.Web.Api.csproj"
COPY . .
WORKDIR "/src/MyOrders/MyOrders.Web.Api"
RUN dotnet build "MyOrders.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyOrders.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyOrders.Web.Api.dll"]