<!-- default file list -->
*Files to look at*:

* [ConvertFileController.cs](./CS/DocumentConversionWebApi/Controllers/ConvertFileController.cs)

* [Dockerfile](./CS/DocumentConversionWebApi/Dockerfile)
<!-- default file list end -->

# How to Dockerize an Office File API .NET Core Application

This example shows how to create an ASP.NET Core Web API application that uses [Office File API](http://docs.devexpress.com/OfficeFileAPI/14911/office-file-api?p=netstandard) to convert a document into HTML on a server. The project contains a [Dockerfile](./CS/DocumentConversionWebApi/Dockerfile) that specifies how to build the application in a Docker container.

## Build the Docker Image

1. Obtain your [DevExpress NuGet feed URL](http://docs.devexpress.com/GeneralInformation/116042/installation/install-devexpress-controls-using-nuget-packages/obtain-your-nuget-feed-url).
2. Add your NuGet feed URL to the [Dockerfile](./CS/DocumentConversionWebApi/Dockerfile) to install the [DevExpress.Document.Processor](https://nuget.devexpress.com/packages/DevExpress.Document.Processor/) NuGet package.
3. Use the following commands to build and run the docker image:

  ```
  docker build -t documentconversionwebapi .
  docker run -d -p 8080:80 documentconversionwebapi
  ```

Use [Postman](https://www.getpostman.com/downloads/) to test the application.
