# ReminderApp

A .NET 8 Web API for scheduling, viewing, and automatically delivering reminders. The API allows users to create reminders with a message, scheduled time, and optional email address. Reminders are automatically processed and marked as “Sent” when their scheduled time is reached.

## Features

-	**Create Reminders**: Schedule reminders with a message, send time, and optional email address
-	**List Reminders**: View all reminders (both scheduled and sent)
-	**Automatic Delivery**: Background service automatically processes reminders at their scheduled time
-	**Persistence**: SQLite database stores all reminders for persistence across application restarts


## Technology Stack
-	**.NET 8**
-	**Entity Framework Core 8**: ORM for database access
-	**SQLite**: Lightweight database
-	**Background Services**: Automated reminder processing
-	**ASP.NET Core Web API**: RESTful API framework
## Getting Started
### Prerequisites
-	.NET 8 SDK installed on your machine
-	(Optional) A code editor such as Visual Studio, Vs Code, or JetBrains Rider
### Installation
1.	Clone or navigate to the project directory
```bash
git clone <repository-url>
cd ReminderApp
```
2.	Restore dependencies
```bash
dotnet restore
```
3.	Build the project:
```bash
dotnet build
```
 ### Running the app
 Run the application using:
 ```bash
 dotnet run
 ```
 The API will be available at:
-	HTTP: http://localhost:5016
-	HTTPS: https://localhost:7004

Swagger UI:
-	http://localhost:5016/swagger

The SQLite database file (`reminders.db`) will be created automatically in the project directory on first run.
## API Endpoints
### POST /reminders
Creates a new reminder.
**Request Body:**
```json
{
 “message”: “Check API gateway logs”,
 “sendAt”: “2026-02-02T14:30:00Z”,
 “email”: “test@example.com”
}
```
**Response:**
```json
{
 “id”: “guid”,
 “status”: “Scheduled”,
 “sendAt”: “2026-02-02T14:30:00Z”
}
```
**Validation:**
- `message` is required
- `sendAt` must be in the future
- `email` is optional but must be a valid email format if provided
### GET /reminders
Retrieves all reminders (both scheduled and sent).
**Response:**
```json
[
 {
  “id”: “guid",
  “message”: “Check logs”,
  “sendAt”: “2026-02-02T14:30:00Z”,
  “status”: “Scheduled”,
  “email”: “user@example.com”
 }
]
```
## Design Decisions
### Database Choice: SQLite
I chose SQLite for several reasons:
- **Simplicity**: No external db server required – perfect for a small service
- **Portability**: Database file can be easily backed up or moved
- **Lightweight**: Minimal resource footprint
- **Persistence**: Data survives app restarts, unlike in-memory storage
### Architecture Pattern
The app follows a clean architecture approach:
- **Controllers**: Handle HTTP requests/responses
- **Services**: Contain business logic
- **Data Layer**: EF Core DbContext for data access
- **DTOs**: Separate models for API contracts
### Background Service for Delivery
A `BackgroundService` (`ReminderDeliveryService`) runs continuously and:
- Checks for pending reminders every five seconds
- Processes reminders whose `SendAt` time has passed
- Logs the delivery
- Marks reminders as “Sent” in the database

### Using Swagger UI
Navigate to `http://localhost:5016/swagger` in your browser to use the interactive API documentation.
## Future Enhancements
While not required for this assignment, potential improvements could include:
- Brevo integration or another email service for actual email delivery
- Email notifications when reminders are sent
- REST endpoint to get a specific reminder by ID
- REST endpoint to update or delete reminders
- Pagination for the GET /reminders endpoint
- User authentication and authorization
- Recurring reminders
- Multiple notification channels (SMS, push notifications)
## License
This project is created as a demonstration project.



 
