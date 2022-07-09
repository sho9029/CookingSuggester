# CookingSuggester

## 事前準備
・[Heroku CLIのインストール](https://devcenter.heroku.com/ja/articles/heroku-cli)

・[Docker Desktopのインストール](https://www.docker.com/get-started/)

・以下のコマンドを順に実行
``` Powershell
heroku login
heroku container:login
```

## デプロイ
・以下のコマンドをソリューションフォルダで順に実行
``` Powershell
heroku container:push web -a {ProjectId}
heroku container:release web -a {ProjectId}
```
