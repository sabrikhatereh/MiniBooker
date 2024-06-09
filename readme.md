
# MiniBooker API Console Application

This .NET Console Application allows you to search for flights and hotels using the Sabre Dev API. Please follow the instructions below to set up and run the application on your system.

## Prerequisites

- .NET SDK (compatible with your project's .NET version, e.g., .NET 5.0 or later)
- An IDE (like Visual Studio) or a text editor (like Visual Studio Code)
- An active account with Sabre Dev Studio with access to API services

## Configuration

Before running the application, you need to configure your API access token:

1. Navigate to the `appsettings.json` file in your project's root directory.
2. Replace the `Your_Api_Token_Here` placeholder with your actual Sabre API token.

   ```json
   {
     "Sabre": {
       "ApiKey": "Your_Api_Token_Here"
     }
   }
   ```

## Building the Application

Open your command line interface (CLI), navigate to the project directory, and run the following command to build the application:

```bash
dotnet build
```

This command compiles the application and checks for errors, ensuring that the build is ready to be executed.

## Running the Application

After building the application, you can run it by executing:

```bash
dotnet run
```

This command will start the application, and you will be able to interact with it via the console to search for flights and hotels.

## Usage

After starting the application, follow the on-screen instructions to enter search parameters for flights and hotels. The application will communicate with the Sabre API to fetch and display the results.
