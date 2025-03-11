# EventHub

EventHub is a modern event management platform that allows users to discover, RSVP, and engage with events seamlessly. 
It will be used to expose events, giving organizers the chance to manage RSVPs, and propose services, while users can explore events by category and connect with service providers at events for reservations and for advertisment opportunities and also to propose services to spice up events.

## Features

- **Event Discovery:** Browse events by category, keyword, or location.
- **User Engagement:** RSVP for events, like events, and see friends attending.
- **Event Management:** Organizers can create, edit, and manage events.
- **Service Proposal:** Users can propose services for events based on category relevance.
- **Role-Based Access:** Organizers and admins have specialized functionalities.
- **Automatic Migrations:** The database updates automatically when the app runs.

## Getting Started

### Prerequisites

Ensure you have the following installed:

- **.NET SDK 7.0+**
- **SQL Server** (or use SQLite for development)
- **Docker** (for containerized deployment)

### Setup & Run

#### 1. Clone the Repository

```sh
git clone https://github.com/yourusername/EventHub.git
cd EventHub
```

#### 2. Configure Environment Variables

Create a `.env` file or update `appsettings.json` with your database connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your-server;Database=EventHubDB;User Id=your-user;Password=your-password;"
}
```

#### 3. Run the Application

The app **automatically applies migrations** on startup. Simply run:

```sh
dotnet run
```

This ensures the database schema is updated without manual intervention.

## Running with Docker

To run the app in a container with automatic database migrations:

```sh
docker-compose up --build
```

This will spin up the app and database, applying migrations automatically.

## Contributing

We welcome contributions! To get started:

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -m "Added new feature"`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a Pull Request.



### Need Help?

If you encounter issues, feel free to open an issue or reach out in discussions!

