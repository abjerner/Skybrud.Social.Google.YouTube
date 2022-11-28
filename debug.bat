@echo off
dotnet build src/Skybrud.Social.Google.YouTube --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:\nuget