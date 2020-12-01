#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS build
WORKDIR /dotnetapp
COPY ./bin/Docker ./
ENV ASPNETCORE=http://*:5000
ENV ASPNETCORE_ENVIROMENT=docker
ENTRYPOINT ["dotnet", "NetCoreMicro.API.dll"]