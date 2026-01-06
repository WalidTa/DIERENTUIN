using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enclosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityLevel = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Habitat = table.Column<int>(type: "int", nullable: false),
                    Climate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    DietaryClass = table.Column<int>(type: "int", nullable: false),
                    ActivityPattern = table.Column<int>(type: "int", nullable: false),
                    Prey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpaceRequirement = table.Column<double>(type: "float", nullable: false),
                    SecurityRequirement = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    EnclosureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Animals_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mammal" },
                    { 2, "Bird" },
                    { 3, "Reptile" }
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "Climate", "Habitat", "Name", "SecurityLevel", "Size" },
                values: new object[,]
                {
                    { 1, 1, 3, "Savannah Enclosure", 1, 500.0 },
                    { 2, 0, 0, "Jungle Enclosure", 2, 300.0 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[,]
                {
                    { 1, 2, 3, 0, 1, "Shana", null, 1, 0, 68.93597349978225, "Crocodile" },
                    { 2, 1, 3, 4, 2, "Pinkie", "Penguin", 2, 1, 71.242719877945348, "Crocodile" },
                    { 3, 0, 2, 4, 2, "Emily", "Crocodile", 2, 0, 10.424893928016211, "Penguin" },
                    { 4, 1, 1, 4, 1, "Roel", null, 1, 3, 28.777346770880502, "Bear" },
                    { 5, 1, 1, 1, 2, "Emelia", null, 1, 3, 77.254581098368789, "Elephant" },
                    { 6, 0, 1, 3, 1, "Eunice", "Giraffe", 2, 2, 73.156797543067285, "Elephant" },
                    { 7, 1, 3, 4, 1, "Lenore", "Tiger", 2, 3, 92.799558072419558, "Wolf" },
                    { 8, 1, 1, 1, 1, "Max", null, 1, 4, 35.185115655186337, "Eagle" },
                    { 9, 2, 3, 4, 1, "Delmer", null, 0, 1, 76.969117172523738, "Wolf" },
                    { 10, 1, 2, 2, 2, "Zoila", null, 1, 4, 28.544236243710667, "Wolf" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_EnclosureId",
                table: "Animals",
                column: "EnclosureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Enclosures");
        }
    }
}
