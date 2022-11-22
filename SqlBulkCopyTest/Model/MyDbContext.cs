
using Microsoft.EntityFrameworkCore;
public class MyDbContext : DbContext
{

    public DbSet<TestTableEf> TestTableEfs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=.\sqlexpress;Database=Blogging;uid=sa;pwd=ok");
    }
}

public class TestTableEf
{
    public Guid Id { get; set; }
    public string Field1 { get; set; }
    public string Field2 { get; set; }
    public string Field3 { get; set; }
    public string Field4 { get; set; }
    public string Field5 { get; set; }
    public string Field6 { get; set; }
    public string Field7 { get; set; }
    public string Field8 { get; set; }
    public string Field9 { get; set; }
    public string Field10 { get; set; }

    public DateTime CreateTime { get; set; } = DateTime.Now;
}