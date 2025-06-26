# Build aþamasý
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Proje dosyalarýný kopyala ve publish et
COPY . ./
RUN dotnet publish -c Release -o out

# Çalýþtýrma aþamasý
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Uygulamayý baþlat
ENTRYPOINT ["dotnet", "GeminiApiChatBot.dll"]
