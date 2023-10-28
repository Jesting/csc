using Microsoft.EntityFrameworkCore;

//"Host=localhost;Username=postgres;Password=example;Database=LibraryCB"
public partial class AppDbContext:DbContext
{
    public DbSet<ClientBook> ClientBooks { get; set; }
    private string _connectionString;

    public AppDbContext() { }

    public AppDbContext(string connectionString) => _connectionString = connectionString;
	

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    => optionsBuilder.UseNpgsql(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientBook>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("book_pkey");
            entity.ToTable("clientbooks");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.BookId).HasColumnName("bookId");
                
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}





   
