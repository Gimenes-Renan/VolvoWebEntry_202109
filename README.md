# Prerequisites:
- NET 5 Runtime
- NPM
- NodeJS
- SQL Server
- .NET EF (using the command line, type "dotnet tool install --global dotnet-ef")

# How to run the application:

## Setting up the database and running the API (Backend):

Go to the project API base directory (..\VolvoWebEntry\Volvo_API), then:
Open a CLI (command line or Windows Power Shell)
- dotnet build
- dotnet ef database update
- dotnet run

The API should be running at http://localhost:5000


## Setting up the WEB (Frontend):


Go to the project WEB base directory (..\VolvoWebEntry\Volvo_WEB), then:
Open a second CLI (command line or Windows Power Shell)
- npm install
- npm start

The WEB application should be running at http://localhost:3000/

### Now open a web browser, then go to: http://localhost:3000/
