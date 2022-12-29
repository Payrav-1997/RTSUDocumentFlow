FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY DocumentFlow/*.csproj ./DocumentFlow/


RUN dotnet restore --disable-parallel

COPY . .

RUN dotnet publish -c Release -o out --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app
COPY --from=build-env /src/out .

ENTRYPOINT ["dotnet", "DocumentFlow.dll"]
