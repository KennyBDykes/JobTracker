using System.ComponentModel.DataAnnotations;

public class User
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }  // "Admin", "Applicant"

    public ICollection<Application> Applications { get; set; }
}