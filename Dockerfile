FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["SkillServices.Api/SkillServices.Api.csproj", "SkillServices.Api/"]
RUN dotnet restore "SkillServices.Api/SkillServices.Api.csproj"
COPY . .
WORKDIR "/src/SkillServices.Api"
RUN dotnet build "SkillServices.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "SkillServices.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkillServices.Api.dll"]
