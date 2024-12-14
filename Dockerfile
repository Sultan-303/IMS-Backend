# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution and project files
COPY ["IMS.sln", "./"]
COPY ["IMS/IMS.csproj", "IMS/"]
COPY ["IMS.API/IMS.API.csproj", "IMS.API/"]
COPY ["IMSTests/IMSTests.csproj", "IMSTests/"]

# Restore dependencies
RUN dotnet restore "IMS.sln"

# Copy the remaining files and build the application
COPY . .
WORKDIR "/src/IMS"
RUN dotnet build "IMS.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "IMS.csproj" -c Release -o /app/publish

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMS.dll"]