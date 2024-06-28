﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSR.DataAccess.Data;

#nullable disable

namespace SSR.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240621000729_AddMenuItemsAndDishesToTablesAndSeed")]
    partial class AddMenuItemsAndDishesToTablesAndSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SSR.Models.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Idli which is a soft, pillowy steamed savory cake made from fermented rice and lentil batter, served with spicy tomato chutney.",
                            ImageUrl = "",
                            MenuId = 1,
                            Name = "Idli",
                            Price = 4.9900000000000002
                        },
                        new
                        {
                            Id = 2,
                            Description = "The classic Masala dosa recipe makes perfectly light, soft and crispy crepes stuffed with a savory, wonderfully spiced potato and onion filling.",
                            ImageUrl = "",
                            MenuId = 1,
                            Name = "Masala Dosa",
                            Price = 5.4900000000000002
                        },
                        new
                        {
                            Id = 3,
                            Description = "Appam (also known as “palappam”) are tasty, lacy and fluffy pancakes or hoppers from the Kerala cuisine that are made from ground, fermented rice and coconut batter, served with coconut milk veg stew.",
                            ImageUrl = "",
                            MenuId = 1,
                            Name = "Appam",
                            Price = 3.9900000000000002
                        },
                        new
                        {
                            Id = 4,
                            Description = "Delicious wraps or rolls stuffed with a spiced mix chicken stuffing. These kathi rolls make for a good brunch, lunch or tiffin box snack or a portable meal on the go!",
                            ImageUrl = "",
                            MenuId = 1,
                            Name = "Chapati Roll",
                            Price = 5.9900000000000002
                        },
                        new
                        {
                            Id = 5,
                            Description = "They feature a pastry-like crust but are filled with savory and spiced potato and green peas for a hearty, delicious breakfast.",
                            ImageUrl = "",
                            MenuId = 1,
                            Name = "Samosa",
                            Price = 5.4900000000000002
                        },
                        new
                        {
                            Id = 6,
                            Description = "Combining the goodness of the omelette and the versatility of the  bread, this dish can be considered a complete meal by itself.",
                            ImageUrl = "",
                            MenuId = 1,
                            Name = "Bread Omelette",
                            Price = 3.9900000000000002
                        });
                });

            modelBuilder.Entity("SSR.Models.Models.MenuItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Menu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Beverages"
                        });
                });

            modelBuilder.Entity("SSR.Models.Models.Dish", b =>
                {
                    b.HasOne("SSR.Models.Models.MenuItems", "MenuItems")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}
