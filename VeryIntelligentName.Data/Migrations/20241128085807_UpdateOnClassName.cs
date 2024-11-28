using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeryIntelligentName.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnClassName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("3ccaf9ac-e348-4c15-b996-9d8fe54a678e"));

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("5e8a5c71-dabf-4ed9-b57c-b517a47e2d7a"));

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("637d5037-c3d0-4ed9-b694-c831d94afc9c"));

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Characters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Name of class");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "CharacterClasses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Name of class");

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "ATK", "AtkModifier", "CON", "ClassName", "ConModifier", "DEX", "DexModifier", "InitiativeModifier", "Level", "Name" },
                values: new object[,]
                {
                    { new Guid("2d12adf8-48fe-45a6-8645-224ce5517501"), 11, 1.0, 11, "Warrior", 1.0, 8, 0.59999999999999998, 1.0, 1, "Warrior" },
                    { new Guid("f6edeed2-19d2-4cc5-9d86-47e5da556ace"), 12, 1.5, 10, "Wizard", 0.5, 8, 0.59999999999999998, 1.5, 1, "Wizard" },
                    { new Guid("fc17162a-7d58-49ae-9268-087428084c38"), 10, 0.80000000000000004, 10, "Thief", 0.80000000000000004, 10, 1.0, 1.0, 1, "Thief" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("2d12adf8-48fe-45a6-8645-224ce5517501"));

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("f6edeed2-19d2-4cc5-9d86-47e5da556ace"));

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("fc17162a-7d58-49ae-9268-087428084c38"));

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "CharacterClasses");

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "ATK", "AtkModifier", "CON", "ConModifier", "DEX", "DexModifier", "InitiativeModifier", "Level", "Name" },
                values: new object[,]
                {
                    { new Guid("3ccaf9ac-e348-4c15-b996-9d8fe54a678e"), 10, 0.80000000000000004, 10, 0.80000000000000004, 10, 1.0, 1.0, 1, "Thief" },
                    { new Guid("5e8a5c71-dabf-4ed9-b57c-b517a47e2d7a"), 12, 1.5, 10, 0.5, 8, 0.59999999999999998, 1.5, 1, "Wizard" },
                    { new Guid("637d5037-c3d0-4ed9-b694-c831d94afc9c"), 11, 1.0, 11, 1.0, 8, 0.59999999999999998, 1.0, 1, "Warrior" }
                });
        }
    }
}
