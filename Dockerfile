FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["DesafioCDB.API/DesafioCDB.API.csproj", "DesafioCDB.API/"]
COPY ["DesafioCDB.Domain/DesafioCDB.Domain.csproj", "DesafioCDB.Domain/"]

RUN dotnet restore "DesafioCDB.API/DesafioCDB.API.csproj"

COPY . .
WORKDIR /src/DesafioCDB.API
RUN dotnet publish "DesafioCDB.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "DesafioCDB.API.dll"]
