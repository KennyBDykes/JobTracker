using System.ComponentModel.DataAnnotations;

public class CreateApplicationDto
{
    [Required]
    public string Company { get; set; }
    [Required]
    public string Position { get; set; }
    public string Notes { get; set; }

}