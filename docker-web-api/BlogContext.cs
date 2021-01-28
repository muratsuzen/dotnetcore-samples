
using Microsoft.EntityFrameworkCore;
public class BlogContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=myBlog;User Id=sa;Password=r00t.R00T;");
        
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Post> Posts{get;set;}
}