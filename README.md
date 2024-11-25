# CVGenerator

## Description

This is a simple CV generator that takes input from the user and generates a downloadable PDF file.

## Installation

1. Clone the repository

    ```bash
    https://github.com/jetsup/DotnetCVGenerator.git
    ```

2. Install the dependencies

    ```bash
    dotnet restore
    ```

3. Edit the [appsettings.json](CVGenerator/appsettings.json) file to configure the database connection string.

    ```json
    {
        "ConnectionStrings": {
            "Default": "Data Source=localhost;Initial Catalog=cv_generator;User ID=your_db_username;Password=your_db_password;Integrated Security=False;TrustServerCertificate=True;"
        }
    }
    ```

    For Windows users, you can use Windows Authentication by setting `Integrated Security=True` and removing the `User ID` and `Password` fields. For Linux users, you can use `User ID` and `Password` fields to connect to the database but the `Integrated Security` field should be explicitly set to `False` to avoid using kerberos authentication.

4. Apply the migrations

    ```bash
    dotnet ef database update
    ```

5. Run the application

    ```bash
    dotnet run
    ```

## Usage

READ THE INSTRUCTIONS PROVIDED IN THE README SECTION OF THE WEB APPLICATION.
