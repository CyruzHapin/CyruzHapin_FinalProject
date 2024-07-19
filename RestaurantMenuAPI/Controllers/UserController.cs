using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace RestaurantMenuAPI.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly Services _services;
        public UserController()
        {
            _services = new Services();
        }

        [HttpGet]

        public IEnumerable<RestaurantMenuAPI.Menu> GetUsers()
        {
            var activeusers = _services.GetMenus();
            List<RestaurantMenuAPI.Menu> menus = new List<Menu>();
             foreach (var item in activeusers)
            {
                menus.Add(new Menu { Description = item.Description, Meal = item.Meal, Price = item.Price, Drinks = item.Drinks});
            }
            return menus;
        }

        [HttpPost]

        public JsonResult AddUser(Menu request)
        {

            var result = _services.CreateUser(request.Description, request.Meal, request.Price, request.Drinks);
            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(Menu request)
        {
            var result = _services.UpdateUser(request.Description, request.Meal, request.Price, request.Drinks);

            return new JsonResult(result);
        }


        [HttpDelete]
        public IActionResult DeleteUser(string Description, string Meal,string Price, string Drinks)
        {
            _services.DeleteUser(Description, Meal, Price, Drinks);
            return Ok(new { Message = "Menu is deleted successfuly" });
        }
    }
}

