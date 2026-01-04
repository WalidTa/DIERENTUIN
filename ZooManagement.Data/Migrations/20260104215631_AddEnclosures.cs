using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEnclosures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 1, "Antwan", 5, 34.131533094697048, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DietaryClass", "Name", "SpaceRequirement", "Species" },
                values: new object[] { 0, "Hayden", 35.100830061599112, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 1, "Eloisa", 2, 86.52101113364948, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 0, "Ayana", 2, 0, 52.58629642574914, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Size", "SpaceRequirement" },
                values: new object[] { 2, 3, 4, "Wilfrid", 1, 65.326199660464795 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 2, 2, 1, 2, "Elda", 2, 0, 87.257918847400489 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 4, 4, 3, "Ansel", 2, 3, 56.493584603695034, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement" },
                values: new object[] { 1, 3, 1, "Odessa", 4, 46.061876310729104 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, 4, "Marie", 0, 3, 42.691950122346164, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 2, "Tanner", 1, 3, 45.231654175821774, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 1, 2, "Abbie", 2, 11.824358065819027, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 2, "Danika", 4, 52.627548332350408, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, "Henri", 2, 3, 68.313847363406751, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ActivityPattern", "CategoryId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 0, 4, "Sister", 1, 3, 35.400365996162932 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 3, "Ruben", 2, 5, 19.285776591594043, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 2, 4, 2, "Cathy", 2, 4, 58.373979225322174, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 4, 3, "Reymundo", 1, 5, 38.292548378679257, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ActivityPattern", "CategoryId", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 0, 2, 3, "Triston", 0, 2, 41.532915362688627 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 2, 3, 3, "Jenifer", 5, 94.348935680158561, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 4, 1, 3, "Brayan", 1, 1, 47.368920967226188, "Shark" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 0, 2, "Stanton", 3, 23.338537296060061, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DietaryClass", "Name", "SpaceRequirement", "Species" },
                values: new object[] { 4, "Elva", 36.420605399128121, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, "Estel", 3, 77.524129372207483, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 4, "Lorena", 0, 3, 15.411379341187006, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Size", "SpaceRequirement" },
                values: new object[] { 1, 1, 1, "Everett", 2, 63.764159459293786 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 1, 1, 3, 1, "Mateo", 0, 2, 90.161728164764256 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 0, 2, "Raul", 0, 5, 42.1707677559397, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement" },
                values: new object[] { 4, 2, 2, "Stacey", 2, 68.611033760941055 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 1, "Rupert", 2, 2, 23.6083601758647, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 3, "Irwin", 2, 2, 21.954520598944892, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 3, 3, 1, "Shayna", 5, 12.78916655564295, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 4, 3, "Drew", 0, 5.9485672174236539, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, "Hanna", 0, 2, 91.485897085383925, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ActivityPattern", "CategoryId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 1, 3, "Bryce", 0, 1, 83.337475826370678 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 2, "Catherine", 1, 0, 73.675340659414118, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 0, 1, "Pinkie", 1, 5, 23.684759411554563, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 3, 2, "Emmet", 0, 4, 98.742507888073774, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ActivityPattern", "CategoryId", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 1, 3, 1, "Lindsey", 1, 1, 36.123076379197983 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 4, 1, "Nathan", 4, 46.77394995484206, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 2, 1, "Brenden", 0, 2, 75.611361668698507, "Parrot" });
        }
    }
}
