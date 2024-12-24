#!/bin/bash
dotnet tool install --global dotnet-ef
export PATH="$PATH:/root/.dotnet/tools"
dotnet ef database update
dotnet IMS.API.dll#!/bin/bash
sleep 30
dotnet tool install --global dotnet-ef
export PATH="$PATH:/root/.dotnet/tools"
dotnet ef database update --project IMS.DAL --startup-project IMS.API
dotnet IMS.API.dll
