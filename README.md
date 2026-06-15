# Music Works API

ASP.NET Core REST API for musical works, using Entity Framework Core and SQLite.

## Description

Music Works API is a REST API for storing and managing a database of musical works. 
Each work includes details such as title, category, instrumentation, price, and publication year.
The 4 categories are "solo", "chamber", "orchestral", and "choral".

## Features

- View all musical works
- View details for a single work
- Add a new work
- Update an existing work
- Delete a work
- View work categories
- Database seeded with starter music works
- SQLite database with Entity Framework Core migrations

## Tech Stack

- C#
- ASP.NET Core
- Entity Framework Core
- SQLite

## API Endpoints

### Works

| Method | Endpoint | Description |
|---|---|---|
| GET | `/works` | Get all works |
| GET | `/works/{id}` | Get a single work by ID |
| POST | `/works` | Create a new work |
| PUT | `/works/{id}` | Update an existing work |
| DELETE | `/works/{id}` | Delete a work |

### Categories

| Method | Endpoint | Description |
|---|---|---|
| GET | `/categories` | Get all categories |
