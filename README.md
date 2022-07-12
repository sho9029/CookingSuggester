# CookingSuggester

## 事前準備
・[Heroku CLIのインストール](https://devcenter.heroku.com/ja/articles/heroku-cli)

・[Docker Desktopのインストール](https://www.docker.com/get-started/)

・以下のコマンドを順に実行
``` Powershell
heroku login
heroku container:login
```

・herokuで新しいappを作成

・作成したappでadd-onsにHeroku Postgresを追加

・`Server/appsettings.json`に追加したデータベースの接続文字列を記述
``` json
{
  "ConnectionStrings": {
    "db": "Server={Host};Port={Port};Database={Database};User Id={User};Password={Password};Pooling=true;SearchPath=public"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## デプロイ
・以下のコマンドをソリューションフォルダで順に実行
``` Powershell
heroku container:push web -a {ProjectId}
heroku container:release web -a {ProjectId}
```

## 注意点
・以下のようなエラーが発生した場合、`heroku container:login`を実行
``` Powershell
unauthorized: authentication required
 !    Error: docker push exited with Error: 1
```
