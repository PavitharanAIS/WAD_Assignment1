using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSR.Models.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Item Price")]
        public double Price { get; set; }

        [Display(Name = "Menu")]
        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        [ValidateNever]
        public MenuItems MenuItems {  get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
