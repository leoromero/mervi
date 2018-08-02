FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58508
EXPOSE 44326

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ../Basket.API/Basket.API.csproj ../Basket.API/
COPY Basket.Infrastructure/Basket.Infrastructure.csproj Basket.Infrastructure/
COPY Basket.Domain/Basket.Domain.csproj Basket.Domain/
COPY Common/EventBus/RabbitMQ/EventBusRabbitMQ.csproj Common/EventBus/RabbitMQ/
COPY Common/EventBus/EventBus/EventBus.csproj Common/EventBus/EventBus/
RUN dotnet restore ../Basket.API/Basket.API.csproj
COPY . .
WORKDIR /src/../Basket.API
RUN dotnet build Basket.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Basket.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Basket.API.dll"]
