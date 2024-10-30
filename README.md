<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/227394207/21.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T848263)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to Dockerize an Office File API Application

This example shows how to create an ASP.NET Core Web API application that uses the [Office File API](https://www.devexpress.com/products/net/office-file-api/) library to convert Excel and Word documents to HTML on the server. The project contains a [Dockerfile](./CS/DocumentConversionWebApi/Dockerfile) that specifies how to build the application in a Docker container.

## Build the Docker Image

Obtain a [DevExpress NuGet Feed URL](https://docs.devexpress.com/GeneralInformation/116042/installation/install-devexpress-controls-using-nuget-packages/obtain-your-nuget-feed-credentials) and add your feed authorization key to the [Dockerfile](./CS/DocumentConversionWebApi/Dockerfile) to specify the package source for the [DevExpress.Document.Processor](https://nuget.devexpress.com/packages/DevExpress.Document.Processor/) NuGet package.

Use the following commands to build and run the docker image:

  ```
  docker build -t documentconversionwebapi .
  docker run -d -p 8080:80 documentconversionwebapi
  ```

Use the [Thunder Client](https://marketplace.visualstudio.com/items?itemName=rangav.vscode-thunder-client) VS Code extension to test the application. See the following help topic for details: [Dockerize an Office File API Application](https://docs.devexpress.com/OfficeFileAPI/401528/dotnet-core-support/dockerize-an-office-file-api-app).

## Files to Look At

* [ConvertFileController.cs](./CS/DocumentConversionWebApi/Controllers/ConvertFileController.cs)

* [Dockerfile](./CS/DocumentConversionWebApi/Dockerfile)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=dockerize-office-file-api-app&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=dockerize-office-file-api-app&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
