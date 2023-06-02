@echo off

:: Define a variável de ambiente
set ASPNETCORE_ENVIRONMENT=Production

:: Restaura as dependências
dotnet restore

:: Compila o projeto
dotnet build

:: Publica a aplicação
dotnet publish --configuration Release --output .\publish

:: Executa a aplicação publicada
dotnet .\publish\IDentyfica.dll
