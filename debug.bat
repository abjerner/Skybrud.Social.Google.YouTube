@echo off
dotnet build src/Skybrud.Social.Google.YouTube --configuration Debug /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=c:\nuget