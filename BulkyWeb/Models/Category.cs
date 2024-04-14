using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Category Name")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Value must be between 1 and 100")]
    public int DisplayOrder { get; set; }
}