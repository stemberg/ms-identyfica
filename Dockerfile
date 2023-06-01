FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore

RUN dotnet build --configuration Release --output /app/build

RUN dotnet publish --configuration Release --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IDentyfica.dll"]
