
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSR.DataAccess.Data;
using SSR.DataAccess.Repository.IRepository;
using SSR.Models.Models;
using SSR.Utility;

namespace SouthernSpiceRestaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            List<MenuItems> objMenuList = _unitOfWork.MenuItems.GetAll().ToList(); // or you can write  var objMenuList = _db.Menu.ToList(); both are same.
            return View(objMenuList);
        }

        public IActionResult CreateMenu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu(MenuItems obj) // Send this object to CreateMenu.cshtml and Get back the user input from CreateMenu.cshtml. Now this obj contains the user entered data as an object. 
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name."); //ModelState.AddModelError is used to create custom error messages on user entered data validation. "Name" -> This is the key argument which you can find in CreateMenu.cshtml -> asp-for="Name".
            }

            //if (obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Test is an invalid value."); //"" -> If you don't enter a property key argument, then it does link the error to the Property but still display the error because asp-validation-summary="All" is set to All in CreateMenu.cshtml. If set to "ModelOnly" then this error will not be displayed. Also it can be set to "None". This will not display any error messages on user input validation. These can be useful in Login pages. Try it Out!
            //}

            if (ModelState.IsValid) //Checks if the entered details are valied based on the Annotations that are mentioned in MenuItems.cs and proceeds to execute and save changes to the db or else it does not execute.
            {
                _unitOfWork.MenuItems.Add(obj); // Add/Send the received object/objects to database.
                _unitOfWork.Save(); // Goes to database and creates the menu item.
                TempData["success"] = "Menu created successfully."; //TempData["KeyName"] is used to display a notification to user on successful creation, updation or deletion of menu.
                return RedirectToAction("Index"); //Instead of returning the view, we are redirecting the data to Index view mentioned above.
            }

            return View();
        }

        public IActionResult EditMenu(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // MenuItems? MenuItemsFromDb = _db.Menu.Find(id);
            MenuItems? MenuItemsFromDb1 = _unitOfWork.MenuItems.Get(u => u.Id == id);
            // MenuItems? MenuItemsFromDb2 = _db.Menu.Where(u => u.Id == id).FirstOrDefault();

            if (MenuItemsFromDb1 == null)
            {
                return NotFound();
            }

            return View(MenuItemsFromDb1);
        }


        [HttpPost]
        public IActionResult EditMenu(MenuItems obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.MenuItems.Update(obj); // Add/Send the received object/objects to database.
                _unitOfWork.Save();
                TempData["success"] = "Menu updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult DeleteMenu(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            MenuItems? MenuItemsFromDb1 = _unitOfWork.MenuItems.Get(u => u.Id == id);

            if (MenuItemsFromDb1 == null)
            {
                return NotFound();
            }

            return View(MenuItemsFromDb1);
        }

        [HttpPost, ActionName("DeleteMenu")]
        public IActionResult DeletePOST(int? id)
        {
            MenuItems? obj = _unitOfWork.MenuItems.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.MenuItems.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Menu deleted successfully.";
            return RedirectToAction("Index");
        }

    }
}
