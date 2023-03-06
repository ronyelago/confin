# Specify the base image and tag for .NET 6.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory inside the container
WORKDIR /app

# Copy csproj files 
COPY *.csproj ./

# Restore NuGet packages
RUN dotnet restore

# Copy the entire project 
COPY . ./

# Publish the project as Release build
RUN dotnet publish -c Release -o out

# Switch to a smaller runtime-only image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory
WORKDIR /app

# Copy the published output from previous step into this image
COPY --from=build-env /app/out .

# Entrypoint command
ENTRYPOINT ["dotnet", "confin.api.dll"]
