# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install the latest version of font libraries
RUN apt update &&\
         apt install -y libc6 libicu-dev libfontconfig1

# (Optional step) Install the ttf-mscorefonts-installer package
# to use Microsoft TrueType core fonts in the application
RUN echo "deb http://ftp.debian.org/debian/ bullseye contrib" >> /etc/apt/sources.list
RUN apt update
RUN apt install -y ttf-mscorefonts-installer 

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
WORKDIR /src

# Specify your DevExpress NuGet Feed URL as the package source
RUN dotnet nuget add source https://nuget.devexpress.com/{your-feed-authorization-key}/api
# Copy the project file
COPY ./DocumentConversionWebApi.csproj ./

# Restore as distinct layers
RUN dotnet restore

# Publish a release
RUN dotnet publish "DocumentConversionWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "DocumentConversionWebApi.dll"]
