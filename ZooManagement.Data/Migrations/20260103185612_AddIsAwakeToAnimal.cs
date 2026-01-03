using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAwakeToAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAwake",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 2, 3, false, "Pink", 1, 72.787403885596632, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 1, 3, false, "Bertram", 2, 2, 98.398148699681173, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 2, 3, false, "Elsa", 0, 10.699170042194158, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "IsAwake", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, false, "Henry", 5, 66.973539018793673, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 3, 3, 1, false, "Estella", 2, 1, 44.552166810854224, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 2, 4, false, "Nona", 1, 5, 11.377058682221229, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 4, 3, 2, false, "Houston", 0, 3, 88.950137174424256, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ActivityPattern", "DietaryClass", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, false, "Jason", 1, 2, 50.067184427813999, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "DietaryClass", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, false, "Asa", 0, 0, 8.9999368541582427, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 3, 1, false, "Emily", 0, 5, 20.490179198700485, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 1, 1, false, "Tristin", 2, 2, 44.934256752240152 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DietaryClass", "IsAwake", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, false, "Kenton", 1, 23.282339472664567, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 4, 2, 2, false, "Amina", 0, 0, 45.682154690874327, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 0, 3, false, "Macie", 0, 26.070464567642876, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Size", "SpaceRequirement" },
                values: new object[] { 4, 4, 3, false, "Gianni", 1, 82.70908628688511 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, 0, 3, false, "Lawrence", 1, 0, 21.290831451446934, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 1, 1, false, "Janessa", 0, 4, 81.548930851206293, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 1, 2, false, "Julie", 1, 9.7548362264315074, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 1, 3, false, "Nelda", 0, 0, 7.5096603844147509, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 1, false, "Gaston", 2, 0, 65.425796755346141, "Cobra" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAwake",
                table: "Animals");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 2, "Immanuel", 0, 79.62290173717733, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 4, 0, 2, "Emmalee", 1, 5, 96.490143199190911, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 3, 1, 2, "Gladyce", 1, 7.3245487596863157, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 3, "Lamont", 0, 68.270703024039648, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 3, "D'angelo", 0, 5, 62.826350777953458, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 3, 1, "Aniya", 2, 0, 76.674433266436907, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, 0, 1, "Jarrod", 2, 4, 26.439160072136616, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 0, "Johnson", 2, 4, 59.685090950197903, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, "Ayden", 2, 2, 12.026959841142791, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 3, "Helen", 1, 3, 67.776741736632943, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 2, 3, "Jameson", 0, 1, 41.893782173733122 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 3, "Alexandro", 0, 33.498107022748933, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 0, 1, "Sheila", 1, 4, 66.175937542274738, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 3, 1, "Darron", 2, 22.272768836316111, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement" },
                values: new object[] { 1, 3, 2, "Erica", 2, 46.659074123308301 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 3, 1, "Hilton", 2, 1, 38.642342025493463, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 2, 2, 3, "Maude", 2, 1, 61.158485954115555, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 4, 2, 1, "King", 0, 48.73074652494887, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, 4, 1, "Sonny", 1, 3, 31.433329972781667, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 3, 4, "Larry", 1, 1, 70.710237004903604, "Shark" });
        }
    }
}
