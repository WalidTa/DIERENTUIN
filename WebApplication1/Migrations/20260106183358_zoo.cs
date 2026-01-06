using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class zoo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZooId",
                table: "Enclosures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zoo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 2, "Thalia", 0, 4, 81.530677638989459, "Penguin" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "DietaryClass", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 0, "Jazlyn", null, 0, 2, 34.950541342816834, "Zebra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 1, 1, "Lindsay", null, 0, 1, 31.669077428780607, "Crocodile" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, "Derek", 2, 2, 19.586832900629204, "Penguin" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 0, "Chesley", 0, 2, 76.786698271717285, "Giraffe" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 2, 0, "Carroll", "Eagle", 1, 4, 19.060336125663135, "Tiger" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 2, "Lydia", null, 5, 92.337911571873889, "Zebra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 4, 2, "Madeline", "Giraffe", 2, 3, 81.303310625150942, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "SpaceRequirement", "Species" },
                values: new object[] { 3, 2, "Al", "Giraffe", 2, 47.423661377129847, "Zebra" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DietaryClass", "Name", "SecurityRequirement", "SpaceRequirement" },
                values: new object[] { 0, "Benny", 2, 64.752338835376037 });

            migrationBuilder.UpdateData(
                table: "Enclosures",
                keyColumn: "Id",
                keyValue: 1,
                column: "ZooId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Enclosures",
                keyColumn: "Id",
                keyValue: 2,
                column: "ZooId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Enclosures_ZooId",
                table: "Enclosures",
                column: "ZooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enclosures_Zoo_ZooId",
                table: "Enclosures",
                column: "ZooId",
                principalTable: "Zoo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enclosures_Zoo_ZooId",
                table: "Enclosures");

            migrationBuilder.DropTable(
                name: "Zoo");

            migrationBuilder.DropIndex(
                name: "IX_Enclosures_ZooId",
                table: "Enclosures");

            migrationBuilder.DropColumn(
                name: "ZooId",
                table: "Enclosures");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 2, 3, 0, "Shana", 1, 0, 68.93597349978225, "Crocodile" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "DietaryClass", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 3, 4, "Pinkie", "Penguin", 2, 1, 71.242719877945348, "Crocodile" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 2, 4, 2, "Emily", "Crocodile", 2, 0, 10.424893928016211, "Penguin" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 4, "Roel", 1, 3, 28.777346770880502, "Bear" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityPattern", "DietaryClass", "Name", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, "Emelia", 1, 3, 77.254581098368789, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 0, 1, 3, "Eunice", "Giraffe", 2, 2, 73.156797543067285, "Elephant" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ActivityPattern", "CategoryId", "DietaryClass", "Name", "Prey", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 3, 4, "Lenore", "Tiger", 3, 92.799558072419558, "Wolf" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ActivityPattern", "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species" },
                values: new object[] { 1, 1, 1, "Max", null, 1, 4, 35.185115655186337, "Eagle" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DietaryClass", "EnclosureId", "Name", "Prey", "SecurityRequirement", "SpaceRequirement", "Species" },
                values: new object[] { 4, 1, "Delmer", null, 0, 76.969117172523738, "Wolf" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DietaryClass", "Name", "SecurityRequirement", "SpaceRequirement" },
                values: new object[] { 2, "Zoila", 1, 28.544236243710667 });
        }
    }
}
