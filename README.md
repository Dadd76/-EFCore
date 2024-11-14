# -EFCore
 application console .NET Core qui effectue un accès aux données d’une base de données SQLite à l’aide d’Entity Framework Core.


https://learn.microsoft.com/fr-fr/ef/core/


dotnet add package Microsoft.EntityFrameworkCore.SqlServer

***** outils Entity Framework Core - CLI .NET Core : https://learn.microsoft.com/fr-fr/ef/core/cli/dotnet

dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design

executer : dotnet ef

*****  Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Sqlite


dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.Configuration.FileExtensions

***** Création de la base de données à l aide des migrations 

dotnet ef migrations add InitialCreate
dotnet ef database update