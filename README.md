# Order Management API

## Overview

This solution contains two services: OrderCount.Service and WebApi.Service. WebApi.Service is RESTfull API which is used to manipulate customers and orders data, OrderCount.Service is a background service that counts orders.

## Getting Started

After clone the repository, you can follow the next steps:

1. If you don't have [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) - install it
2. To start services you have to either run it from your IDE or navigate to `WebApi.Service/src/WebUI/` and execute `dotnet run` in powershell and do the same in `OrderCount.Service/src/OrderCount.Service/`

NOTE: if my azure service bus isn't active you can create your own and substitute ConnectionString, TopicName and SubscriptionName

## Architecture

For this project I used Clean Architecture and Mediator/CQRS, even though it is too complicated for a project of this size but in the future it will be easier to extend functionality and add new services.