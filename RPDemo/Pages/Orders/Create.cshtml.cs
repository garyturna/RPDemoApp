using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RPDemo.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;
        public List<SelectListItem> FoodItems { get; set; }

        [BindProperty]
        public OrderModel Order { get; set; }

        public CreateModel(IFoodData FoodData, IOrderData OrderData)
        {
            _foodData = FoodData;
            _orderData = OrderData;
        }
        public async Task OnGetAsync()
        {
            var food = await _foodData.GetFood();

            FoodItems = food.Select((FoodModel x) => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            }).ToList();

            FoodItems.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "Select a food item"
            }); 
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }

            var food = await _foodData.GetFood();
            Order.Total = Order.Quantity * food.Where(x => x.Id == Order.FoodId).First().Price;
            Order.OrderDate = DateTime.UtcNow;
            int id = await _orderData.CreateOrder(Order);
            return RedirectToPage("./Display", new { Id = id});
        }
    }
}
