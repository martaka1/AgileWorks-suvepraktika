# Customer Service Portal

## Overview
The Customer Service Portal is a web application designed to manage customer service tickets. Users can create new tickets, view active tickets, mark tickets as done, and manage ticket details.

## Features
- Landing page with options to create a new ticket or view existing tickets
- Form for creating a new ticket with optional name, mandatory description, and mandatory completion date
- Tickets sorted by descending completion date in the tickets list
- Options to edit, view details, delete, and mark tickets as done
- Active tickets displayed in red if completion time is less than an hour away

## Installation
1. Install .NET SDK and IDE (JetBrains Rider or Visual Studio Code recommended)
2. Clone the repository
3. Navigate to the project directory

## Running the Application
### Using JetBrains Rider
1. Open the project in JetBrains Rider
2. Run the application using the integrated play button or execute the following command in the terminal:
```bash
dotnet run --project WebApp```
3. Apply migrations if required

### Using Visual Studio Code
1. Open the terminal in Visual Studio Code
2. Run the application using the following command:
```bash
dotnet run --project WebApp```
3. Apply migrations if required
