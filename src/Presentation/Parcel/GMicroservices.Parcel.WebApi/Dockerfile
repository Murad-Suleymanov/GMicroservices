#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/Parcel/GMicroservices.Parcel.WebApi/GMicroservices.Parcel.WebApi.csproj", "Presentation/Parcel/GMicroservices.Parcel.WebApi/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
COPY ["Core/Parcel/GMicroservices.Parcel.Domain/GMicroservices.Parcel.Domain.csproj", "Core/Parcel/GMicroservices.Parcel.Domain/"]
COPY ["Infrastructure/Parcel/GMicroservices.Parcel/GMicroservices.Parcel.csproj", "Infrastructure/Parcel/GMicroservices.Parcel/"]
RUN dotnet restore "Presentation/Parcel/GMicroservices.Parcel.WebApi/GMicroservices.Parcel.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/Parcel/GMicroservices.Parcel.WebApi"
RUN dotnet build "GMicroservices.Parcel.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMicroservices.Parcel.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMicroservices.Parcel.WebApi.dll"]