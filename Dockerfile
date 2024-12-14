FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IMS.API/IMS.API.csproj", "IMS.API/"]
COPY ["IMS.BLL/IMS.BLL.csproj", "IMS.BLL/"]
COPY ["IMS.Common/IMS.Common.csproj", "IMS.Common/"]
COPY ["IMS.DAL/IMS.DAL.csproj", "IMS.DAL/"]
COPY ["IMS.Interfaces/IMS.Interfaces.csproj", "IMS.Interfaces/"]
RUN dotnet restore "IMS.API/IMS.API.csproj"
COPY . .
WORKDIR "/src/IMS.API"
RUN dotnet build "IMS.API.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish 
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "IMS.API.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "IMS.API.dll"]