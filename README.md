# Service Discovery with Eureka and Ocelot Gateway (.NET 8)

## Overview
This is a .NET 8 service discovery sample project demonstrating how to register microservices using Spring Eureka and access them via Ocelot API Gateway.

The API Gateway routes requests to the Product Microservice using the service name registered in the Eureka Server, showcasing dynamic service discovery and centralized routing.

1. Eureka Server for service registration and discovery

2. Ocelot Gateway that uses Eureka as a service provider

3. Product Microservice exposed through the API Gateway

## Features
**Dynamic Service Discovery via Eureka**

**API Gateway Routing with Ocelot**

**Centralized Routing Logic**

**Swagger Integration for Gateway and Microservices**

**Microservice registered with Steeltoe Discovery Client**

## Tech Stack
**.NET 8**

**Ocelot API Gateway**

**Steeltoe Discovery Client**

**Ocelot.Provider.Eureka**

**Entity Framework Core**

**MSSQL Server**

**Swagger UI**

## Eureka Server Instance View
![My Screenshot](Publisher/Screenshot/Kafka_Topic.jpg)

## Swagger - BFF.Web Gateway Calling Product Microservice API
![My Screenshot](Publisher/Screenshot/Message_Sender.jpg)

## How It Works
1. Product.API registers itself with the Eureka Server using Steeltoe Discovery Client.

2. BFF.Web uses Ocelot.Provider.Eureka to dynamically fetch service info from Eureka and route requests to Product.API.

3. Consumers call the gateway endpoint, which resolves and forwards the request to the actual service.
