using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

IConfiguration   configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();


// Créez les options pour le DbContext en configurant SQLite
var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));

// Instanciez le DbContext avec les options et la configuration
using var db = new BloggingContext(optionsBuilder.Options, configuration);


// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");


// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });

try
{
    db.SaveChanges();
}
catch (DbUpdateException ex)
{
    Console.WriteLine($"A database update error occurred: {ex.Message}");
}
// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
//db.Remove(blog);
db.SaveChanges();