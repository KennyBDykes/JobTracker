using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

   public DbSet<Application> Applications{ get; set; } 
   public DbSet<User> Users{ get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Application>(entity =>
    {
         entity.HasKey(a => a.Id);   
         entity.HasOne(a => a.User) 
              .WithMany()     
              .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade); 
        
    });

     modelBuilder.Entity<User>(entity =>
    {
        entity.HasKey(a => a.Id); 
        entity.Property(a => a.Id)
              .HasDefaultValueSql("NEWID()");
    });
      modelBuilder.Entity<User>().HasData(new User
        {
            Id =  new Guid("a1111111-1111-1111-1111-111111111111"),
            Username = "admin",
            PasswordHash = "admin123", 
            Role = "Admin"
        },
        new User
        {
            Id =new Guid("b1111111-1111-1111-1111-111111111111"),
            Username = "applicant",
            PasswordHash = "applicant123", 
            Role = "Applicant"
        });
    }
    
}