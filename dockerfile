# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY ../ ./
# copy csproj and restore as distinct layers
COPY *.sln ./
RUN dotnet restore

# copy everything else and build app
RUN dotnet publish -c release -o out --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

# CMD ASPNETCORE_URLS="http://*:$PORT" dotnet StoreroomAPI.dll
CMD dotnet StoreroomAPI.dll
# CMD dotnet StoreroomAPI.dll --environment="Development"
# ENTRYPOINT ["dotnet", "StoreroomAPI.dll", "--environment=Development"]