#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Api.GCP.SQL/Api.GCP.SQL.csproj", "Api.GCP.SQL/"]
RUN dotnet restore "Api.GCP.SQL/Api.GCP.SQL.csproj"
COPY . .
WORKDIR "/src/Api.GCP.SQL"
RUN dotnet build "Api.GCP.SQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.GCP.SQL.csproj" -c Release -o /app/publish --self-contained --runtime linux-x64

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.GCP.SQL.dll"]