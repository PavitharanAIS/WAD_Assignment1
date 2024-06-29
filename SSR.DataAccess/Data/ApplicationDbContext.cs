using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSR.Models.Models;

namespace SSR.DataAccess.Data
{


    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<MenuItems> Menu { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //If using IdentityDbContext from .Net Entity Framework, this code is required.

            modelBuilder.Entity<MenuItems>().HasData(
                new MenuItems { Id = 1, Name = "Breakfast", DisplayOrder = 1 },
                new MenuItems { Id = 2, Name = "Lunch", DisplayOrder = 2 },
                new MenuItems { Id = 3, Name = "Dinner", DisplayOrder = 3 },
                new MenuItems { Id = 4, Name = "Beverages", DisplayOrder = 4 }
                );

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Idli",
                    Description = "Idli which is a soft, pillowy steamed savory cake made from fermented rice and lentil batter, served with spicy tomato chutney.",
                    Price = 4.99,
                    MenuId = 1,
                    ImageUrl = ""
                },
                new Dish
                {
                    Id = 2,
                    Name = "Masala Dosa",
                    Description = "The classic Masala dosa recipe makes perfectly light, soft and crispy crepes stuffed with a savory, wonderfully spiced potato and onion filling.",
                    Price = 5.49,
                    MenuId = 1,
                    ImageUrl = ""
                },
                new Dish
                {
                    Id = 3,
                    Name = "Appam",
                    Description = "Appam (also known as “palappam”) are tasty, lacy and fluffy pancakes or hoppers from the Kerala cuisine that are made from ground, fermented rice and coconut batter, served with coconut milk veg stew.",
                    Price = 3.99,
                    MenuId = 1,
                    ImageUrl = ""
                },
                new Dish
                {
                    Id = 4,
                    Name = "Chapati Roll",
                    Description = "Delicious wraps or rolls stuffed with a spiced mix chicken stuffing. These kathi rolls make for a good brunch, lunch or tiffin box snack or a portable meal on the go!",
                    Price = 5.99,
                    MenuId = 1,
                    ImageUrl = ""
                },
                new Dish
                {
                    Id = 5,
                    Name = "Samosa",
                    Description = "They feature a pastry-like crust but are filled with savory and spiced potato and green peas for a hearty, delicious breakfast.",
                    Price = 5.49,
                    MenuId = 1,
                    ImageUrl = ""
                },
                new Dish
                {
                    Id = 6,
                    Name = "Bread Omelette",
                    Description = "Combining the goodness of the omelette and the versatility of the  bread, this dish can be considered a complete meal by itself.",
                    Price = 3.99,
                    MenuId = 1,
                    ImageUrl = ""
                }
                );
        }
    }
    
}
