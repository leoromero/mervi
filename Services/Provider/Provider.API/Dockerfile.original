FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 54472
EXPOSE 44333

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Services/Provider/Provider.API/Provider.API.csproj Services/Provider/Provider.API/
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
