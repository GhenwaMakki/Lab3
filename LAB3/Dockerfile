FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY Lab3/*.csproj ./Lab3/
RUN dotnet restore Lab3/Lab3.csproj

COPY Lab3/. ./Lab3/

RUN dotnet build Lab3/Lab3.csproj -c Release -o /app/build

RUN dotnet publish Lab3/Lab3.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Lab3.dll"]
