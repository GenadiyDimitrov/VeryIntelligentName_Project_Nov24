using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeryIntelligentName.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Entity identifier"),
                    Level = table.Column<int>(type: "int", nullable: false, comment: "Increase stats or loot"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the entity"),
                    ATK = table.Column<int>(type: "int", nullable: false, comment: "Atack stat of entity"),
                    CON = table.Column<int>(type: "int", nullable: false, comment: "Contitution stat of entity"),
                    DEX = table.Column<int>(type: "int", nullable: false, comment: "Dextirity stat of entity"),
                    DexModifier = table.Column<double>(type: "float", nullable: false, comment: "Dependent on class"),
                    ConModifier = table.Column<double>(type: "float", nullable: false, comment: "Dependent on class"),
                    AtkModifier = table.Column<double>(type: "float", nullable: false, comment: "Dependent on class"),
                    InitiativeModifier = table.Column<double>(type: "float", nullable: false, comment: "Dependent on class. Range classes have higher modifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "ATK", "AtkModifier", "CON", "ConModifier", "DEX", "DexModifier", "InitiativeModifier", "Level", "Name" },
                values: new object[,]
                {
                    { new Guid("0d32bc3f-0826-4618-952f-2b37170cd4b5"), 12, 1.5, 10, 0.5, 8, 0.59999999999999998, 1.5, 1, "Wizard" },
                    { new Guid("63d0109f-7fa8-4cc6-b794-6dca5db60207"), 11, 1.0, 11, 1.0, 8, 0.59999999999999998, 1.0, 1, "Warrior" },
                    { new Guid("a2001a3f-2d5c-48cf-a420-321fa129adc5"), 10, 0.80000000000000004, 10, 0.80000000000000004, 10, 1.0, 1.0, 1, "Thief" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterClasses");
        }
    }
}
