@echo off
dotnet build src/Skybrud.Social.Google.YouTube --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget