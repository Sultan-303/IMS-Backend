FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["IMS.API/IMS.API.csproj", "IMS.API/"]
COPY ["IMS.BLL/IMS.BLL.csproj", "IMS.BLL/"]
COPY ["IMS.DAL/IMS.DAL.csproj", "IMS.DAL/"]
COPY ["IMS.Common/IMS.Common.csproj", "IMS.Common/"]
COPY ["IMS.Interfaces/IMS.Interfaces.csproj", "IMS.Interfaces/"]
RUN dotnet restore "IMS.API/IMS.API.csproj"
COPY . .
WORKDIR "/src/IMS.API"
RUN dotnet build "IMS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IMS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMS.API.dll"]