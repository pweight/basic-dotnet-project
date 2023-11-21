using System.ComponentModel.DataAnnotations;

namespace Rentler.Interview.Api
{
  public class Food
  {
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Brand { get; set; } //(max length 100 alphanumeric)

    [Required, MaxLength(250)]
    public string Description { get; set; } //(max length 250 alphanumeric)

    [Required]
    public int ServingSize { get; set; }
    [Required]
    public int Calories { get; set; }
    [Required]
    public int Fat { get; set; }
    [Required]
    public int Carbohydrates { get; set; }
    [Required]
    public int Protein { get; set; }
    [Required]
    public int Sodium { get; set; }
    [Required]
    public int Potassium { get; set; }
    [Required]
    public int Cholesterol { get; set; }
  }
}