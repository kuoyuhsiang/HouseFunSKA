FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HouseFunSKA/HouseFunSKA.csproj", "HouseFunSKA/"]
RUN dotnet restore "HouseFunSKA/HouseFunSKA.csproj"
COPY . .
WORKDIR "/src/HouseFunSKA"
RUN dotnet build "HouseFunSKA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseFunSKA.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HouseFunSKA.dll"]
