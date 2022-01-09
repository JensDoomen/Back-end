# FROM ubuntu

# MAINTAINER jensdoomen pal <457543@student.fontys.nl>

# RUN apt-get update

# CMD ["echo", "Hello World...! from my first docker image!"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 44344
EXPOSE 44334
EXPOSE 5000
ENV ASPNETCORE_URLS http://*:44344

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Authentication/Authentication.csproj", "Authentication/"]
RUN dotnet restore "Authentication/Authentication.csproj"
COPY . .
WORKDIR "/src/Authentication"
RUN dotnet build "Authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.dll"]
© 2022 GitHub, Inc.
Terms
Privacy
Security
