#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/Product/GMicroservices.Product.WebApi/GMicroservices.Product.WebApi.csproj", "Presentation/Product/GMicroservices.Product.WebApi/"]
COPY ["Core/Product/GMicroservices.Product.Domain/GMicroservices.Product.Domain.csproj", "Core/Product/GMicroservices.Product.Domain/"]
COPY ["Infrastructure/Product/GMicroservices.Product/GMicroservices.Product.csproj", "Infrastructure/Product/GMicroservices.Product/"]
RUN dotnet restore "Presentation/Product/GMicroservices.Product.WebApi/GMicroservices.Product.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/Product/GMicroservices.Product.WebApi"
RUN dotnet build "GMicroservices.Product.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMicroservices.Product.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMicroservices.Product.WebApi.dll"]