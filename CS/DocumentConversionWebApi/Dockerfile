FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy the .csproj file and restore the project's dependencies
COPY *.csproj ./
# Specify your DevExpress NuGet feed URL to install the DevExpress.Document.Processor package
RUN dotnet add package DevExpress.Document.Processor -s https://nuget.devexpress.com/{your-feed-authorization-key}/api
RUN dotnet restore

# Copy project files and build the application
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

# Install the latest version of the libgdiplus library to use the System.Drawing functionality in the application
RUN apt update
RUN apt install -y libgdiplus libc6 libc6-dev
RUN apt install -y fontconfig libharfbuzz0b libfreetype6

# (Optional step) Install the ttf-mscorefonts-installer package to use Microsoft TrueType core fonts in the application
RUN echo "deb http://deb.debian.org/debian stretch contrib" >> /etc/apt/sources.list
RUN apt-get update
RUN apt-get install -y ttf-mscorefonts-installer  

COPY --from=build-env /app/publish .
# Define the entry point for the application
ENTRYPOINT ["dotnet", "DocumentConversionWebApi.dll"]