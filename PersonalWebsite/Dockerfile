FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PersonalWebsite.csproj", "./"]
RUN dotnet restore "./PersonalWebsite.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet publish "PersonalWebsite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PersonalWebsite.dll"]
