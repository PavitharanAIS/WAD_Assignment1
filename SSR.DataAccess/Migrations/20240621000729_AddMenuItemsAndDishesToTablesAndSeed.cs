using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SSR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuItemsAndDishesToTablesAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Breakfast" },
                    { 2, 2, "Lunch" },
                    { 3, 3, "Dinner" },
                    { 4, 4, "Beverages" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "ImageUrl", "MenuId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Idli which is a soft, pillowy steamed savory cake made from fermented rice and lentil batter, served with spicy tomato chutney.", "", 1, "Idli", 4.9900000000000002 },
                    { 2, "The classic Masala dosa recipe makes perfectly light, soft and crispy crepes stuffed with a savory, wonderfully spiced potato and onion filling.", "", 1, "Masala Dosa", 5.4900000000000002 },
                    { 3, "Appam (also known as “palappam”) are tasty, lacy and fluffy pancakes or hoppers from the Kerala cuisine that are made from ground, fermented rice and coconut batter, served with coconut milk veg stew.", "", 1, "Appam", 3.9900000000000002 },
                    { 4, "Delicious wraps or rolls stuffed with a spiced mix chicken stuffing. These kathi rolls make for a good brunch, lunch or tiffin box snack or a portable meal on the go!", "", 1, "Chapati Roll", 5.9900000000000002 },
                    { 5, "They feature a pastry-like crust but are filled with savory and spiced potato and green peas for a hearty, delicious breakfast.", "", 1, "Samosa", 5.4900000000000002 },
                    { 6, "Combining the goodness of the omelette and the versatility of the  bread, this dish can be considered a complete meal by itself.", "", 1, "Bread Omelette", 3.9900000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MenuId",
                table: "Dishes",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
