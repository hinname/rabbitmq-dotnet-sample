# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


# Copy solution and restore dependencies
COPY *.sln ./
COPY src/ ./src/
#COPY test/ ./test/
RUN dotnet restore

# Build the application
RUN dotnet build src/RabbitmqDotnetSample.Api/RabbitmqDotnetSample.Api.csproj -c Release -o /app/build

# Publish the application
RUN dotnet publish src/RabbitmqDotnetSample.Api/RabbitmqDotnetSample.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port if needed
EXPOSE 8080

# Set the entry point
ENTRYPOINT ["dotnet", "RabbitmqDotnetSample.Api.dll"]