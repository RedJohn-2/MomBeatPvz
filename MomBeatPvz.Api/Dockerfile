# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MomBeatPvz.Api/MomBeatPvz.Api.csproj", "MomBeatPvz.Api/"]
COPY ["MomBeatPvz.Application/MomBeatPvz.Application.csproj", "MomBeatPvz.Application/"]
COPY ["MomBeatPvz.Core/MomBeatPvz.Core.csproj", "MomBeatPvz.Core/"]
COPY ["MomBeatPvz.Infrastructure/MomBeatPvz.Infrastructure.csproj", "MomBeatPvz.Infrastructure/"]
COPY ["MomBeatPvz.Persistence/MomBeatPvz.Persistence.csproj", "MomBeatPvz.Persistence/"]
RUN dotnet restore "./MomBeatPvz.Api/MomBeatPvz.Api.csproj"
COPY . .
WORKDIR "/src/MomBeatPvz.Api"
RUN dotnet build "./MomBeatPvz.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MomBeatPvz.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MomBeatPvz.Api.dll"]