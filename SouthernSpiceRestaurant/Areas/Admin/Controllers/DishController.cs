
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSR.DataAccess.Data;
using SSR.DataAccess.Repository.IRepository;
using SSR.Models.Models;
using SSR.Models.Models.ViewModels;
using SSR.Utility;

namespace SouthernSpiceRestaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class DishController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DishController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Dish> objDishList = _unitOfWork.Dish.GetAll(includeDishes: "MenuItems").ToList(); // or you can write  var objMenuList = _db.Menu.ToList(); both are same.

            return View(objDishList);
        }

        public IActionResult CreateOrEditDish(int? id)
        {
            DishViewModel dishViewModel = new()
            {
                MenuItemsList = _unitOfWork.MenuItems
                .GetAll().Select(u => new SelectListItem //Selecting only 2 columns i.e. Name and Id from MenuItemsList from DishViewModel.
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Dish = new Dish()
            };
            if (id == null || id == 0)
            {
                return View(dishViewModel);
            }
            else
            {
                //Get the dish that the user wants to edit.
                dishViewModel.Dish = _unitOfWork.Dish.Get(u => u.Id == id);
                return View(dishViewModel);
            }
        }

        [HttpPost]
        public IActionResult CreateOrEditDish(DishViewModel dishViewModel, IFormFile? file) // Send this object to CreateMenu.cshtml and Get back the user input from CreateMenu.cshtml. Now this obj contains the user entered data as an object. 
        {
            if (dishViewModel.Dish.Name == dishViewModel.Dish.Price.ToString())
            {
                ModelState.AddModelError("Name", "The Price cannot exactly match the Name."); //ModelState.AddModelError is used to create custom error messages on user entered data validation. "Name" -> This is the key argument which you can find in CreateMenu.cshtml -> asp-for="Name".
            }

            //if (obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Test is an invalid value."); //"" -> If you don't enter a property key argument, then it does link the error to the Property but still display the error because asp-validation-summary="All" is set to All in CreateMenu.cshtml. If set to "ModelOnly" then this error will not be displayed. Also it can be set to "None". This will not display any error messages on user input validation. These can be useful in Login pages. Try it Out!
            //}

            if (ModelState.IsValid) //Checks if the entered details are valied based on the Annotations that are mentioned in MenuItems.cs and proceeds to execute and save changes to the db or else it does not execute.
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string dishPath = Path.Combine(wwwRootPath, @"images\dish");

                    if (!string.IsNullOrEmpty(dishViewModel.Dish.ImageUrl))
                    {
                        //Delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, dishViewModel.Dish.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(dishPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    dishViewModel.Dish.ImageUrl = @"\images\dish\" + fileName;
                }

                string tempData;
                if (dishViewModel.Dish.Id == 0)
                {
                    _unitOfWork.Dish.Add(dishViewModel.Dish);
                    tempData = "Dish created successfully.";
                }
                else
                {
                    _unitOfWork.Dish.Update(dishViewModel.Dish);
                    tempData = "Dish updated successfully.";

                }

                _unitOfWork.Save(); // Goes to database and creates the dish item. 
                TempData["success"] = tempData; //TempData["KeyName"] is used to display a notification to user on successful creation, updation or deletion of menu.
                return RedirectToAction("Index"); //Instead of returning the view, we are redirecting the data to Index view mentioned above.
            }
            else //Making sure to return the populated MenuItemsList Columns incase of the above IsValid returns false or null reference error.
            {
                dishViewModel.MenuItemsList = _unitOfWork.MenuItems
                 .GetAll().Select(u => new SelectListItem //Selecting only 2 columns i.e. Name and Id from MenuItemsList from DishViewModel.
                 {
                     Text = u.Name,
                     Value = u.Id.ToString()
                 });
                return View(dishViewModel); 
            }
        } 

        
        #region API CALLS

        // Getting our database as a json object i.e. creating an API.
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Dish> objDishList = _unitOfWork.Dish.GetAll(includeDishes: "MenuItems").ToList(); // or you can write  var objMenuList = _db.Menu.ToList(); both are same.
            return Json(new { data = objDishList }); 
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var dishToBeDeleted = _unitOfWork.Dish.Get(u =>u.Id == id);
            if (dishToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });  
            }

            //Delete the old image
            var oldImagePath = 
                        Path.Combine(_webHostEnvironment.WebRootPath,
                        dishToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Dish.Remove(dishToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion

    }
}
