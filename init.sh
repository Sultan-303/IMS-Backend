#!/bin/bash
sleep 30  # Wait for SQL Server to be fully ready
dotnet tool install --global dotnet-ef
export PATH="$PATH:/root/.dotnet/tools"
dotnet ef database update --project IMS.DAL --startup-project IMS.API
dotnet IMS.API.dll