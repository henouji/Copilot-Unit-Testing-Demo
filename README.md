# Copilot Unit Testing Demo

A sample ASP.NET Core Web API solution designed to demonstrate how GitHub Copilot can help generate unit tests for an existing codebase that has none.

## Project Structure

```
TodoApi/
├── Controllers/
│   └── TodoController.cs      # REST API controller with CRUD endpoints
├── Models/
│   ├── TodoItem.cs            # Domain model
│   └── TodoRequests.cs        # Request DTOs
├── Repositories/
│   ├── ITodoRepository.cs     # Repository interface
│   └── TodoRepository.cs      # In-memory repository implementation
├── Services/
│   ├── ITodoService.cs        # Service interface
│   └── TodoService.cs         # Business logic layer
└── Program.cs                 # Application entry point & DI registration
```

## API Endpoints

| Method | Route              | Description              |
|--------|--------------------|--------------------------|
| GET    | /api/todo          | Get all todo items        |
| GET    | /api/todo/{id}     | Get a specific todo item  |
| POST   | /api/todo          | Create a new todo item    |
| PUT    | /api/todo/{id}     | Update a todo item        |
| DELETE | /api/todo/{id}     | Delete a todo item        |

## Running the API

```bash
cd TodoApi
dotnet run
```

## Purpose

This project intentionally ships **without unit tests** so you can use GitHub Copilot to generate them as a hands-on demonstration. The layered architecture (Controller → Service → Repository) makes it an ideal candidate for exploring how Copilot can scaffold test projects, write mocks, and generate meaningful test cases.