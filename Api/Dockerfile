# 使用官方 .NET 9 SDK 來 build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# 複製 csproj 並還原套件
COPY *.csproj ./
RUN dotnet restore

# 複製整個專案並 build
COPY . ./
RUN dotnet publish -c Release -o out

# 最終執行映像
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Api.dll"]
