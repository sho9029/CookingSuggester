# CookingSuggester

## 事前準備
・Heroku CLIのインストール

・Docker Desktopのインストール

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
