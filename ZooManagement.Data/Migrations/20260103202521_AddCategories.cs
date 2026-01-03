using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, 0, 2, "Stanton", 1, 3, 23.338537296060061, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 4, "Elva", 5, 36.420605399128121, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 1, "Estel", 0, 3, 77.524129372207483, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { "Lorena", 3, 15.411379341187006, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 1, 3, "Everett", 0, 2, 63.764159459293786, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, "Mateo", 0, 2, 90.161728164764256, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 0, "Raul", 5, 42.1707677559397, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "SpaceRequirement", "Species" },
                values: new object[] { 4, 2, 2, "Stacey", 0, 68.611033760941055, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 4, 1, 2, "Rupert", 2, 2, 23.6083601758647, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 0, 4, 1, 3, "Irwin", 2, 2, 21.954520598944892 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 3, 3, "Shayna", 5, 12.78916655564295, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement" },
                values: new object[] { 1, 4, 3, 3, "Drew", 0, 5.9485672174236539 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ActivityPattern", "CategoryId", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 2, 3, "Hanna", 2, 91.485897085383925, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 3, 2, "Bryce", 0, 1, 83.337475826370678, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 2, "Catherine", 0, 73.675340659414118, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ActivityPattern", "CategoryId", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 1, "Pinkie", 5, 23.684759411554563, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "SpaceRequirement", "Species" },
                values: new object[] { 3, 2, "Emmet", 98.742507888073774, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "SpaceRequirement", "Species" },
                values: new object[] { 3, 4, 1, "Lindsey", 1, 36.123076379197983, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 3, 4, 1, "Nathan", 1, 4, 46.77394995484206 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 1, "Brenden", 0, 2, 75.611361668698507, "Parrot" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 2, 3, "Pink", 2, 1, 72.787403885596632, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, "Bertram", 2, 98.398148699681173, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 2, "Elsa", 1, 0, 10.699170042194158, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { "Henry", 5, 66.973539018793673, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 3, 3, 1, "Estella", 2, 1, 44.552166810854224, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, "Nona", 1, 5, 11.377058682221229, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 4, 3, "Houston", 3, 88.950137174424256, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 1, "Jason", 1, 50.067184427813999, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 3, "Asa", 0, 0, 8.9999368541582427, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 2, 1, 3, 1, "Emily", 0, 5, 20.490179198700485 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 1, 1, "Tristin", 2, 44.934256752240152, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement" },
                values: new object[] { 2, 3, 0, 2, "Kenton", 1, 23.282339472664567 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ActivityPattern", "CategoryId", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 2, "Amina", 0, 45.682154690874327, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, 0, 3, "Macie", 1, 0, 26.070464567642876, "Cobra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 4, 3, "Gianni", 1, 82.70908628688511, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ActivityPattern", "CategoryId", "EnclosureId", "Name", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, 3, "Lawrence", 0, 21.290831451446934, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, "Janessa", 81.548930851206293, "Parrot" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 2, "Julie", 2, 9.7548362264315074, "Shark" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement" },
                values: new object[] { 1, 1, 3, "Nelda", 0, 0, 7.5096603844147509 });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 2, "Gaston", 2, 0, 65.425796755346141, "Cobra" });
        }
    }
}
