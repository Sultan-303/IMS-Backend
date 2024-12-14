FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY ["IMS.sln", "./"]

# Copy all project files
COPY ["IMS.API/IMS.API.csproj", "IMS.API/"]
COPY ["IMS.BLL/IMS.BLL.csproj", "IMS.BLL/"]
COPY ["IMS.Common/IMS.Common.csproj", "IMS.Common/"]
COPY ["IMS.DAL/IMS.DAL.csproj", "IMS.DAL/"]
COPY ["IMS.Interfaces/IMS.Interfaces.csproj", "IMS.Interfaces/"]

# Restore dependencies
RUN dotnet restore

# Copy the rest of the code
COPY . .

# Build the API project
WORKDIR "/src/IMS.API"
RUN dotnet build "IMS.API.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "IMS.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMS.API.dll"]