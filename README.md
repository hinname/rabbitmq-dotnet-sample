## Dotnet WebAPI using RabbitMQ
This is a basic Web API using .NET and RabbitMQ. My main focus is to understand the basics of AMQP and RabbitMQ.

The API use NuGet package **MassTransit**. A messaging framework that works with a lot of messaging services such as RabbitMQ and Azure Service Bus.

## Getting Started
To run this project locally, follow these steps.

### Requirements
- Docker ([Click here to install](https://www.docker.com/))

### Installation
1. Clone this repository:
    ```sh
    git clone https://github.com/hinname/rabbitmq-dotnet-sample.git
    ```
2. Run the following command in your terminal inside the project folder:
   ```sh
   docker compose up -d
   ```
3. Enjoy the API on localhost:8080
