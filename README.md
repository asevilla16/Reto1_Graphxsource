# Reto1 GraphxSource - API Setup Guide

## Prerequisites

- .NET 6.0 or higher
- SQL Server or SQL Server Express
- Visual Studio 2022 or Visual Studio Code
- Entity Framework Core CLI tools

## Database Setup

### 1. Install Entity Framework CLI Tools (if not already installed)

```bash
dotnet tool install --global dotnet-ef
```

### 2. Configure Connection String

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Reto1GraphxDB;Trusted_Connection=true;MultipleActiveResultSets=true;"
  }
}
```

Or for SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Reto1GraphxDB;Integrated Security=true;TrustServerCertificate=true;"
  }
}
```

### 3. Create Database Migration

Open terminal in the project root directory and run:

```bash
dotnet ef migrations add InitialCreate
```

### 4. Update Database

Apply the migration to create the database:

```bash
dotnet ef database update
```

## Project Setup

### 1. Clone/Download the Project

```bash
git clone <repository-url>
cd Reto1_GraphxSource
```

### 2. Restore NuGet Packages

```bash
dotnet restore
```

### 3. Register Services in Program.cs

Ensure the following services are registered in `Program.cs`:

```csharp
// Add Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Add services
builder.Services.AddScoped<IMugsService, MugsService>();
builder.Services.AddScoped<IPostersService, PostersService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
```

### 4. Build the Project

```bash
dotnet build
```

## Running the Project

### 1. Run from Command Line

```bash
dotnet run
```

### 2. Run from Visual Studio

- Open the solution in Visual Studio
- Set the API project as startup project
- Press F5 or click "Start Debugging"

### 3. Run from Visual Studio Code

- Open the project folder in VS Code
- Press F5 or use the terminal:

```bash
dotnet run --project Reto1_GraphxSource
```

## API Endpoints

The API will be available at:

- HTTP: `https://localhost:7XXX` (port may vary)
- Swagger UI: `https://localhost:7XXX/swagger`

### Available Endpoints:

#### Mugs

- `GET /api/mugs` - Get all mugs
- `GET /api/mugs/{id}` - Get mug by ID
- `POST /api/mugs` - Create new mug
- `PUT /api/mugs/{id}` - Update mug
- `DELETE /api/mugs/{id}` - Delete mug

#### Posters

- `GET /api/posters` - Get all posters
- `GET /api/posters/{id}` - Get poster by ID
- `POST /api/posters` - Create new poster
- `PUT /api/posters/{id}` - Update poster
- `DELETE /api/posters/{id}` - Delete poster

#### Orders

- `GET /api/orders` - Get all orders
- `GET /api/orders/{id}` - Get order by ID (includes related products and attachments)
- `POST /api/orders` - Create new order
- `PUT /api/orders/{id}` - Update order
- `DELETE /api/orders/{id}` - Delete order

## Database Schema

The database includes the following main entities:

- **Products** (Base class)

  - **Mugs**: CapacityInMl, Color
  - **Posters**: HeightCm, WidthCm, PaperType
  - **TShirts**: Size, Color

- **Orders**: Client, Description, Status, Foreign keys to products
- **Attachments**: Related to orders

## Troubleshooting

### Common Issues:

1. **Database Connection Error**

   - Verify SQL Server is running
   - Check connection string in `appsettings.json`
   - Ensure database exists (run `dotnet ef database update`)

2. **Migration Issues**

   - Delete `Migrations` folder and recreate: `dotnet ef migrations add InitialCreate`
   - Drop database and recreate: `dotnet ef database drop` then `dotnet ef database update`

3. **Service Registration Error**

   - Ensure all services are registered in `Program.cs`
   - Check that interfaces and implementations match

4. **Port Already in Use**
   - Change ports in `launchSettings.json`
   - Or kill the process using the port

### Useful Commands:

```bash
# Check EF CLI version
dotnet ef --version

# List migrations
dotnet ef migrations list

# Remove last migration
dotnet ef migrations remove

# Drop database
dotnet ef database drop

# Generate SQL script
dotnet ef migrations script
```

## Development Notes

- The project uses Entity Framework Core with Code First approach
- Repository pattern is implemented with generic repository
- Services layer handles business logic
- DTOs are used for API responses
- Request models are used for API inputs
