using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rentler.Interview.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodController : ControllerBase
{   
    public FoodContext _foodContext;
    private readonly ILogger<FoodController> _logger;

    public FoodController(ILogger<FoodController> logger, FoodContext foodContext)
    {
        _logger = logger;
        _foodContext = foodContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> Get()
    {
        var allFoods = await _foodContext.Foods.ToListAsync();
        return Ok(allFoods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Food>> GetById(int id)
    {
        var food = await _foodContext.Foods.FirstOrDefaultAsync(f => f.Id == id);
        if (food == null)
        {
            return NotFound();
        }

        return Ok(food);
    }

    [HttpPost(Name = "CreateFood")]
    public async Task<ActionResult<Food>> Create(Food foodRequest)
    {
        await _foodContext.Foods.AddAsync(foodRequest);
        var response = await _foodContext.SaveChangesAsync();
        return Ok(response);
    }

    [HttpPut(Name = "UpdateFood")]
    public async Task<ActionResult<Food>> EditFood(Food updateFoodRequest)
    {
        var food = _foodContext.ChangeTracker.Entries<Food>().FirstOrDefault(f => f.Entity.Id == updateFoodRequest.Id);

        if (food != null)
        {
            _foodContext.Entry(food.Entity).CurrentValues.SetValues(updateFoodRequest);
        }
        else
        {
            _foodContext.Foods.Update(updateFoodRequest);
        }

        //var updatedFood = _foodContext.Foods.Update(updateFoodRequest);
        await _foodContext.SaveChangesAsync();

        return Ok(updateFoodRequest);
    }

    [HttpDelete(Name = "DeleteFood")]
    public async Task<ActionResult<int>> DeleteFood(int id)
    {
        var food = await _foodContext.Foods.FirstOrDefaultAsync(f => f.Id == id);

        if (food == null)
        {
            return NotFound();
        }

        _foodContext.Foods.Remove(food);
        _foodContext.SaveChanges();

        return Ok(id);
    }
}
