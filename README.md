# CookingSuggester

## 事前準備
・Heroku CLIのインストール

・Docker Desktopのインストール

・ソリューションディレクトリに移動

・Dockerfileを作成
``` Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/CookingSuggester.Server.csproj", "Server/"]
COPY ["Shared/CookingSuggester.Shared.csproj", "Shared/"]
COPY ["Client/CookingSuggester.Client.csproj", "Client/"]
RUN dotnet restore "Server/CookingSuggester.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "CookingSuggester.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CookingSuggester.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=https://*:$PORT dotnet CookingSuggester.Server.dll
```

・以下のコマンドを順に実行
``` Powershell
heroku login
heroku container:login
```

## デプロイ
・以下のコマンドを順に実行
``` Powershell
heroku container:push web -a {ProjectId}
heroku container:release web -a {ProjectId}
```
