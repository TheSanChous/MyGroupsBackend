#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyGroups.WebApi/MyGroups.WebApi.csproj", "MyGroups.WebApi/"]
COPY ["MyGroups.Persistence/MyGroups.Persistence.csproj", "MyGroups.Persistence/"]
COPY ["MyGroups.Application/MyGroups.Application.csproj", "MyGroups.Application/"]
COPY ["MyGroups.Domain/MyGroups.Domain.csproj", "MyGroups.Domain/"]
COPY ["MyGroups.Storage/MyGroups.Storage.csproj", "MyGroups.Storage/"]
RUN dotnet restore "MyGroups.WebApi/MyGroups.WebApi.csproj"
COPY . .
WORKDIR "/src/MyGroups.WebApi"
RUN dotnet build "MyGroups.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyGroups.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyGroups.WebApi.dll"]