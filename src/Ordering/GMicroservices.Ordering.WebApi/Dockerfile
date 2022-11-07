#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ordering/GMicroservices.Ordering.WebApi/GMicroservices.Ordering.WebApi.csproj", "Ordering/GMicroservices.Ordering.WebApi/"]
COPY ["Core/Ordering/GMicroservices.Ordering.Application/GMicroservices.Ordering.Application.csproj", "Core/Ordering/GMicroservices.Ordering.Application/"]
COPY ["Core/Ordering/GMicroservices.Ordering.Domain/GMicroservices.Ordering.Domain.csproj", "Core/Ordering/GMicroservices.Ordering.Domain/"]
COPY ["Infrastructure/Ordering/GMicroservices.Ordering.DataAccess/GMicroservices.Ordering.csproj", "Infrastructure/Ordering/GMicroservices.Ordering.DataAccess/"]
RUN dotnet restore "Ordering/GMicroservices.Ordering.WebApi/GMicroservices.Ordering.WebApi.csproj"
COPY . .
WORKDIR "/src/Ordering/GMicroservices.Ordering.WebApi"
RUN dotnet build "GMicroservices.Ordering.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMicroservices.Ordering.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMicroservices.Ordering.WebApi.dll"]