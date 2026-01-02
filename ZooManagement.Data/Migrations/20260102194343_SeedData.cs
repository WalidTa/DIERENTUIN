using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mammals" },
                    { 2, "Birds" },
                    { 3, "Reptiles" },
                    { 4, "Aquatic" }
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "Climate", "HabitatType", "Name", "SecurityLevel", "Size", "ZooId" },
                values: new object[,]
                {
                    { 1, 1, 8, "Savannah", 1, 500.0, null },
                    { 2, 0, 1, "Tropical Forest", 2, 300.0, null },
                    { 3, 1, 2, "Aquarium", 0, 200.0, null }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "ActivityPattern", "AnimalId", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[,]
                {
                    { 1, 1, null, 4, 3, 2, "Immanuel", 2, 0, 79.62290173717733, "Elephant" },
                    { 2, 1, null, 4, 0, 2, "Emmalee", 1, 5, 96.490143199190911, "Parrot" },
                    { 3, 0, null, 3, 1, 2, "Gladyce", 1, 1, 7.3245487596863157, "Shark" },
                    { 4, 1, null, 3, 4, 2, "Lamont", 0, 0, 68.270703024039648, "Parrot" },
                    { 5, 2, null, 1, 1, 3, "D'angelo", 0, 5, 62.826350777953458, "Shark" },
                    { 6, 0, null, 3, 1, 1, "Aniya", 2, 0, 76.674433266436907, "Cobra" },
                    { 7, 0, null, 2, 0, 1, "Jarrod", 2, 4, 26.439160072136616, "Cobra" },
                    { 8, 2, null, 1, 0, 1, "Johnson", 2, 4, 59.685090950197903, "Parrot" },
                    { 9, 2, null, 1, 3, 3, "Ayden", 2, 2, 12.026959841142791, "Lion" },
                    { 10, 0, null, 1, 1, 3, "Helen", 1, 3, 67.776741736632943, "Shark" },
                    { 11, 2, null, 2, 1, 3, "Jameson", 0, 1, 41.893782173733122, "Lion" },
                    { 12, 2, null, 3, 3, 2, "Alexandro", 2, 0, 33.498107022748933, "Elephant" },
                    { 13, 2, null, 1, 0, 1, "Sheila", 1, 4, 66.175937542274738, "Shark" },
                    { 14, 2, null, 2, 3, 1, "Darron", 1, 2, 22.272768836316111, "Lion" },
                    { 15, 2, null, 1, 3, 2, "Erica", 1, 2, 46.659074123308301, "Lion" },
                    { 16, 2, null, 4, 3, 1, "Hilton", 2, 1, 38.642342025493463, "Lion" },
                    { 17, 2, null, 2, 2, 3, "Maude", 2, 1, 61.158485954115555, "Lion" },
                    { 18, 0, null, 4, 2, 1, "King", 2, 0, 48.73074652494887, "Lion" },
                    { 19, 0, null, 2, 4, 1, "Sonny", 1, 3, 31.433329972781667, "Parrot" },
                    { 20, 2, null, 3, 4, 2, "Larry", 1, 1, 70.710237004903604, "Shark" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enclosures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enclosures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enclosures",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
