using System.ComponentModel.DataAnnotations;

namespace Noted.Models;

public class Note
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Note cannot be empty")]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
