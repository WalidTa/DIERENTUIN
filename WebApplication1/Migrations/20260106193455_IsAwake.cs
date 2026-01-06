using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class IsAwake : Migration
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
                columns: new[] { "DietaryClass", "EnclosureId", "IsAwake", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, true, "Elena", "Wolf", 3, 14.998542844609043, "Giraffe" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "IsAwake", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 3, 1, true, "Faye", "Wolf", 2, 0, 18.137954847590706, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "IsAwake", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, true, "Freddy", "Tiger", 2, 96.633362720468241, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "IsAwake", "Name", "SpaceRequirement", "Species" },
                values: new object[] { 2, 3, 2, true, "Letha", 26.968942397382961, "Zebra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 2, 1, true, "Alexie", "Giraffe", 1, 35.213925589134817, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 4, 2, true, "Torrance", "Penguin", 0, 3, 92.697805482546002, "Giraffe" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "DietaryClass", "IsAwake", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 3, 4, true, "Fausto", 1, 2, 12.05269937600929, "Bear" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 2, 0, 1, true, "Janie", null, 1, 4, 18.792361164691158, "Tiger" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 2, 1, true, "Anne", null, 0, 5, 70.868349809432829, "Lion" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "IsAwake", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 1, 3, 1, true, "Unique", "Elephant", 5, 68.05258486503331, "Penguin" });
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
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 1, "Thalia", null, 4, 81.530677638989459, "Penguin" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 2, 0, "Jazlyn", null, 0, 2, 34.950541342816834, "Zebra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, "Lindsay", null, 1, 31.669077428780607, "Crocodile" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 1, "Derek", 19.586832900629204, "Penguin" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 0, 2, "Chesley", null, 2, 76.786698271717285, "Giraffe" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 0, 1, "Carroll", "Eagle", 1, 4, 19.060336125663135, "Tiger" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 2, "Lydia", 2, 5, 92.337911571873889, "Zebra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 1, 4, 2, "Madeline", "Giraffe", 2, 3, 81.303310625150942, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 3, 3, 2, "Al", "Giraffe", 2, 1, 47.423661377129847, "Zebra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 2, 0, 2, "Benny", null, 4, 64.752338835376037, "Wolf" });
        }
    }
}
