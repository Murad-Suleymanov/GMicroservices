#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/Admin/GMicroservices.Admin.WebApi/GMicroservices.Admin.WebApi.csproj", "Presentation/Admin/GMicroservices.Admin.WebApi/"]
RUN dotnet restore "Presentation/Admin/GMicroservices.Admin.WebApi/GMicroservices.Admin.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/Admin/GMicroservices.Admin.WebApi"
RUN dotnet build "GMicroservices.Admin.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMicroservices.Admin.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMicroservices.Admin.WebApi.dll"]