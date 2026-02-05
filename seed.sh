#!bin/bash

dotnet ef database drop
rm -rf Migrations/
dotnet ef migrations add InitialCreate
dotnet ef database update