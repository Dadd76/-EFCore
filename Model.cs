using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get;  set;}
    private readonly IConfiguration _configuration;

     public BloggingContext() { }

   public BloggingContext(DbContextOptions<BloggingContext> options, IConfiguration configuration)
        : base(options)
    {
        // var folder = Environment.SpecialFolder.LocalApplicationData;
        // var path = Environment.GetFolderPath(folder);
        // DbPath = System.IO.Path.Join(path, "blogging.db");

       // var currentDirectory = AppContext.BaseDirectory.;
               _configuration = configuration;
        }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
       //  DbPath = _configuration.GetConnectionString("DefaultConnection");
        //options.UseSqlite($"Data Source={DbPath}").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        //Console.WriteLine(AppContext.BaseDirectory);
                var folder = Environment.SpecialFolder.LocalApplicationData;
        DbPath = "/workspaces/EFCore/blogging.db";
       // DbPath = System.IO.Path.Join(path, "blogging.db");
        Console.WriteLine(DbPath);
         options.UseSqlite($"Data Source={DbPath}").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}