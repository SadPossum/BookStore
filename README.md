# BookStore

This documentation provides an overview of the project structure, technologies used, installation steps, and descriptions of the API endpoints.

## Table of Contents

- ['API Endpoints'](#api-endpoints)
- ['Installation'](#installation)
- ['Project Structure'](#project-structure)
- ['Technologies Used'](#technologies-used)

## API Endpoints

The BookStore API provides the following endpoints for interacting with the system:

### Books Endpoints

#### Get Books

- **URL**: `'/api/books'`
- **Method**: `'GET'`
- **Description**: Retrieves a list of books based on optional search criteria such as title and release date.
- **Request Parameters**:
- `'TitleSearch'` (optional): A string representing the title of the book to search for.
- `'ReleaseDateSearch'` (optional): A DateTime representing the release date of the book to search for.
- **Response**:
- HTTP Status: `'200 OK'`
- Body: A `'ListResponse<BookDto>'` object containing the retrieved books.

#### Get Book by ID

- **URL**: `'/api/books/{id}'`
- **Method**: `'GET'`
- **Description**: Retrieves a specific book by its ID.
- **URL Parameters**:
- `'id'`: An integer representing the unique identifier of the book to retrieve.
- **Response**:
- HTTP Status: `'200 OK'`
- Body: A `'BookDto'` object representing the retrieved book.
- **Error Response**:
- HTTP Status: `'404 Not Found'`
- Body: A JSON object containing an error message if the book with the specified ID is not found.

### Orders Endpoints

#### Create Order

- **URL**: `'/api/orders'`
- **Method**: `'POST'`
- **Description**: Creates a new order based on the provided order details.
- **Request Body**:
- A JSON object containing the necessary information to create an order, following the `'CreateOrderCommand'` model.
- **Response**:
- HTTP Status: `'200 OK'`
- Body: An empty response indicating a successful order creation.

#### Get Orders

- **URL**: `'/api/orders'`
- **Method**: `'GET'`
- **Description**: Retrieves a list of orders based on optional search criteria such as order number and order date.
- **Request Parameters**:
- `'OrderNumberSearch'` (optional): A string representing the order number to search for.
- `'OrderDateSearch'` (optional): A DateTime representing the order date to search for.
- **Response**:
- HTTP Status: `'200 OK'`
- Body: A `'ListResponse<OrderDto>'` object containing the retrieved orders.

## Installation

To install the application, follow these steps:

1. **Clone the repository**:
```sh
git clone https://github.com/SadPossum/BookStore.git
```
2. **Navigate to the project directory**:
```sh
cd BookStore
```
3. **Update the connection string in the appsettings.json file**:
```JSON
"ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
```
4. **Run the following command to apply database migrations**:
```sh
dotnet ef database update
```
5. **Run the application using the following command**:
```sh
dotnet run
```
The application should now be running on http://localhost:5000.

## Project Structure

The BookStore project follows a Domain-Driven Design (DDD) architecture and is organized into several projects representing different layers of the application. Here is an overview of the project structure:

1. **BookStore.Api**: This project contains the ASP.NET Web API and related configurations and middleware.
   - `'Abstractions'`: Contains interfaces and abstractions used within the API.
   - `'Configurations'`: Holds dependency injection configurations.
   - `'Endpoints'`: Contains API endpoints.
   - `'Extensions'`: Extensions for modularizing the API.
   - `'Middleware'`: Global exception handling middleware.
   - `'Models'`: Contains request and response models used in API endpoints.
   - `'Properties'`: Project-specific settings and launch configurations.

2. **BookStore.Application**: This project represents the application layer and contains the use cases (commands and queries) for the domain.
   - `'Orders'`: Contains use cases.
   - `'Books'`: Contains use cases.

3. **BookStore.Domain**: This project represents the domain layer and contains domain entities and interfaces.
   - `'Books'`: Contains the Book entity and related services.
   - `'Entities'`: Contains db entities.
   - `'Orders'`: Contains the Order entity and related services.

4. **BookStore.Infrastructure**: This project represents the infrastructure layer and contains infrastructure-related code.
   - Contains infrastructure-specific implementations and configurations.

5. **BookStore.Persistence**: This project handles data persistence using a database.
   - `'Configurations'`: Contains entity configurations for the database context.
   - `'Migrations'`: Contains EF Core database migrations.
   - `'Repositories'`: Contains data repositories.

## Technologies Used

The BookStore ASP.NET Web API project utilizes the following technologies:

- `'ASP.NET Web API'`
- `'DDD (Domain-Driven Design)'`
- `'MediatR'`
- `'CQRS (Command Query Responsibility Segregation)'`
- `'Serilog'`
- `'Entity Framework Core'`
