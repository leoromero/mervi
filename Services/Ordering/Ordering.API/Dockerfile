FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52430
EXPOSE 44320

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Services/Ordering/Ordering.API/Ordering.API.csproj Services/Ordering/Ordering.API/
RUN dotnet restore Services/Ordering/Ordering.API/Ordering.API.csproj
COPY . .
WORKDIR /src/Services/Ordering/Ordering.API
RUN dotnet build Ordering.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Ordering.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]
