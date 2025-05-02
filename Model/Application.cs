using System.ComponentModel.DataAnnotations;

public class Application
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Company { get; set; }
    public string Position { get; set; }
    public string Status { get; set; }
    public DateTime AppliedDate { get; set;}
    public string Notes { get; set; }

    public Guid UserId{ get; set; } 
    public User User { get; set; }


}