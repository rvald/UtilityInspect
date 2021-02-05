# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
EXPOSE 80

# copy csproj and restore as distinct layers
COPY UtilityInspect.EmployeeService/*.csproj UtilityInspect.EmployeeService/
RUN dotnet restore UtilityInspect.EmployeeService/UtilityInspect.EmployeeService.csproj

# copy and publish app and libraries
COPY . .
WORKDIR /src/UtilityInspect.EmployeeService
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "UtilityInspect.EmployeeService.dll"]