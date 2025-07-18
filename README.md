
# BoltTracker 

BoltTracker is a simple, user-friendly To-Do List web application built with ASP.NET Core and Tailwind CSS. It helps users manage their daily tasks with features like task creation, editing, deleting, prioritizing, and labeling.

## Features

* Add, edit, and delete tasks
* Set task priority (High, Medium, Low)
* Assign labels/categories to tasks
* Mark tasks as done or procrastinated
* Due dates with validation preventing past dates
* Responsive and modern UI with Tailwind CSS
* Modal dialogs for task editing and creation
* AJAX calls for smooth UI experience without page reloads

## Technologies Used

* ASP.NET Core MVC
* Entity Framework Core (Code First)
* Tailwind CSS for styling
* JavaScript (Fetch API) for async operations
* Razor Pages for UI templating

## Getting Started

### Prerequisites

* .NET 9 SDK or later
* SQL Server (Express or Developer edition recommended)
* Node.js and npm (optional, for Tailwind CSS build)
* Entity Framework Core CLI tools
* SQL Server Management Studio (SSMS) (optional, for database design and management)


### Setup

1. Clone the repository

   ```bash
  https://github.com/lovatahiana/BoldTracker.git
   ```

2. Navigate into the project folder

   ```bash
   cd bolttracker
   ```

3. Configure your database connection string in `appsettings.json`

4. Apply migrations and update the database

   ```bash
   dotnet ef database update
   ```

5. Run the project

   ```bash
   dotnet run
   ```

6. Open a browser and go to `https://localhost:7022` (or the port shown in console)

## Usage

* Click **Add a task** to create a new task (due date defaults to today, cannot select past dates)
* Use the dropdown on each task card to edit or delete a task
* Task statuses and priorities are visually indicated by colors and labels

## Contributing

Contributions are welcome! Feel free to submit issues or pull requests.

## License

MIT License © Lova Tahiana RAKOTOVAHINY
