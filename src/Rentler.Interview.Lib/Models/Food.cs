
using System.Collections.Generic;

public class Food
{
  public int Id { get; set; }
  public string Brand { get; set; }
  public string Description { get; set; }
  public int ServingSize { get; set; }
  public int Calories { get; set; }
  public int Fat { get; set; }  
  public int Carbohydrates { get; set; }  
  public int Protein { get; set; }  
  public int Sodium { get; set; }  
  public int Potassium { get; set; }  
  public int Cholesterol { get; set; }
}

public class PaginatedFoodData
{
  public int TotalResults { get; set; }
  public int PageNumber { get; set; }
  public List<FoodPreview> Foods { get; set; } = new List<FoodPreview>();
}

public class SearchFoodData
{
  public int TotalResults { get; set; }
  public int PageNunmber { get; set; }
  public List<Food> Foods { get; set; } = new List<Food>();
}

public class FoodPreview
{
  public int Id { get; set; }
  public string Brand { get; set; }
  public string Description { get; set; }
}