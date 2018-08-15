FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 54472
EXPOSE 44333

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Services/Provider/Provider.API/Provider.API.csproj Services/Provider/Provider.API/
COPY Common/EventBus/EventBus/EventBus.csproj Common/EventBus/EventBus/
COPY Services/Provider/Provider.Domain/Provider.Domain/Provider.Domain.csproj Services/Provider/Provider.Domain/Provider.Domain/
COPY Common/DDD/Domain/Mervi.SeedWork/Mervi.SeedWork.csproj Common/DDD/Domain/Mervi.SeedWork/
COPY Services/Provider/Provider.Infrastructure/Provider.Infrastructure.csproj Services/Provider/Provider.Infrastructure/
COPY Common/DDD/Infrastructure/Mervi.Infrastructure/Mervi.Infrastructure.csproj Common/DDD/Infrastructure/Mervi.Infrastructure/
RUN dotnet restore Services/Provider/Provider.API/Provider.API.csproj
COPY . .
WORKDIR /src/Services/Provider/Provider.API
RUN dotnet build Provider.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Provider.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Provider.API.dll"]
