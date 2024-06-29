using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSR.Models.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        [ForeignKey("DishId")]
        [ValidateNever]
        public Dish Dish { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped] //using NotMapped will not create a column in the Db. This makes each shopping cart total Price to be available temporarily and locally.
        public double Price { get; set; }
    }
}
