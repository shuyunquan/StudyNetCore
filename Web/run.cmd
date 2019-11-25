@echo off
echo ASPNETCORE_ENVIRONMENT=Development
dotnet build
start "Web" dotnet watch run
exit