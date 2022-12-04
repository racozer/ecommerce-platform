#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Client/Product/Platform.Api.Services.Client.Product/Platform.Api.Services.Client.Product.csproj", "Services/Client/Product/Platform.Api.Services.Client.Product/"]
RUN dotnet restore "Services/Client/Product/Platform.Api.Services.Client.Product/Platform.Api.Services.Client.Product.csproj"
COPY . .
WORKDIR "/src/Services/Client/Product/Platform.Api.Services.Client.Product"
RUN dotnet build "Platform.Api.Services.Client.Product.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Platform.Api.Services.Client.Product.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Platform.Api.Services.Client.Product.dll"]