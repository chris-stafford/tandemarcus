FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-focal AS build
WORKDIR /src
COPY ["src/API.Arcus.Webservice/API.Arcus.Webservice.csproj", "API.Arcus.Webservice/"]
RUN dotnet restore "API.Arcus.Webservice/API.Arcus.Webservice.csproj" -s "https://api.nuget.org/v3/index.json"
COPY src/. .
WORKDIR "/src/API.Arcus.Webservice"
RUN dotnet build "API.Arcus.Webservice.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "API.Arcus.Webservice.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Arcus.Webservice.dll"]