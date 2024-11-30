FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["IMS.sln", "./"]
COPY ["IMS/IMS.csproj", "IMS/"]
COPY ["IMS.API/IMS.API.csproj", "IMS.API/"]
COPY ["IMSTests/IMSTests.csproj", "IMSTests/"]
RUN dotnet restore "IMS.sln"

COPY . .
WORKDIR "/src/IMS"
RUN dotnet build "IMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMS.dll"]
