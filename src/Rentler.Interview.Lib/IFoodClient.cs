
// Define your interface methods here
using System.Threading.Tasks;

public interface IFoodClient
{
    Task<PaginatedFoodData> GetPaginatedFoodDataAsync(int pageNumber, int pageSize);
    Task<Food> GetFoodByIdAsync(int id);
    Task<Food> CreateFoodAsync(Food food);
    Task<Food> UpdateFoodAsync(Food food);
    Task<bool> DeleteFoodAsync(int id);
    Task<SearchFoodData> SearchFoodsAsync(string searchTerm, int pageNumber, int pageSize);
}