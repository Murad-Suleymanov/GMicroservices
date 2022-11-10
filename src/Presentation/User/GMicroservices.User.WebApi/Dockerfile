#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/User/GMicroservices.User.WebApi/GMicroservices.User.WebApi.csproj", "Presentation/User/GMicroservices.User.WebApi/"]
COPY ["Core/User/GMicroservices.User.Application/GMicroservices.User.Application.csproj", "Core/User/GMicroservices.User.Application/"]
COPY ["Infrastructure/User/GMicroservices.User/GMicroservices.User.csproj", "Infrastructure/User/GMicroservices.User/"]
COPY ["Core/User/GMicroservices.User.Domain/GMicroservices.User.Domain.csproj", "Core/User/GMicroservices.User.Domain/"]
RUN dotnet restore "Presentation/User/GMicroservices.User.WebApi/GMicroservices.User.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/User/GMicroservices.User.WebApi"
RUN dotnet build "GMicroservices.User.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMicroservices.User.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMicroservices.User.WebApi.dll"]