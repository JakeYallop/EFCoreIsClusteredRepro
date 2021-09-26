// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");




public class Context : DbContext
{
    public DbSet<MyObject> MyObjects { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyObject>().HasKey(x => x.Id).IsClustered();
        base.OnModelCreating(modelBuilder);
    }

}

public class MyObject
{
    public int Id { get; set; }
    public string Property { get; set; } = null!;
}