using Microsoft.AspNetCore.Mvc;
using SSR.DataAccess.Repository;
using SSR.DataAccess.Repository.IRepository;
using SSR.Models.Models;
using System.Diagnostics;

namespace SouthernSpiceRestaurant.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Dish> dishList = _unitOfWork.Dish.GetAll(includeDishes: "MenuItems");
            return View(dishList);
        }

        public IActionResult DishDetails(int dishId)
        {
            Dish dish = _unitOfWork.Dish.Get(u => u.Id == dishId, includeDishes: "MenuItems");
            return View(dish);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
