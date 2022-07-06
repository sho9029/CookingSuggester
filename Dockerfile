#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

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
ENTRYPOINT ["dotnet", "CookingSuggester.Server.dll"]
CMD ASPNETCORE_URLS=https://*:$PORT dotnet CookingSuggester.Server.dll