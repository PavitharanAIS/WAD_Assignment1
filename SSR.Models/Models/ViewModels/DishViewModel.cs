using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSR.Models.Models.ViewModels
{
    public class DishViewModel // Creating a ViewModel to pass to the view through the controller. This helps in passing current Model and select columns from other columns as well.
    {
        public Dish Dish { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MenuItemsList { get; set; }
    }
}
