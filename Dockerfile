FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

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
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet build "IMS.API.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish 
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "IMS.API.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /root/.dotnet/tools /root/.dotnet/tools
ENV PATH="${PATH}:/root/.dotnet/tools"
ENTRYPOINT ["./entrypoint.sh"]