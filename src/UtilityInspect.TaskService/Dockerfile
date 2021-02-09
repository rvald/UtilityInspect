# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
EXPOSE 80

# copy csproj and restore as distinct layers
COPY UtilityInspect.TaskService/*.csproj UtilityInspect.TaskService/
RUN dotnet restore UtilityInspect.TaskService/UtilityInspect.TaskService.csproj

# copy and publish app and libraries
COPY . .
WORKDIR /src/UtilityInspect.TaskService
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "UtilityInspect.TaskService.dll"]