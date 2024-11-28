using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeryIntelligentName.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfile_Added_CharAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("0d32bc3f-0826-4618-952f-2b37170cd4b5"));

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("63d0109f-7fa8-4cc6-b794-6dca5db60207"));

            migrationBuilder.DeleteData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("a2001a3f-2d5c-48cf-a420-321fa129adc5"));

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Entity identifier"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User it belongs to"),
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
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayersCharacters",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User it belongs to"),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Character it belongs to")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersCharacters", x => new { x.PlayerId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_PlayersCharacters_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlayersCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "ATK", "AtkModifier", "CON", "ConModifier", "DEX", "DexModifier", "InitiativeModifier", "Level", "Name" },
                values: new object[,]
                {
                    { new Guid("3ccaf9ac-e348-4c15-b996-9d8fe54a678e"), 10, 0.8, 10, 0.8, 10, 1.0, 1.0, 1, "Thief" },
                    { new Guid("5e8a5c71-dabf-4ed9-b57c-b517a47e2d7a"),12, 1.5, 10, 0.5, 8, 0.6, 1.5, 1, "Wizard" },
                    { new Guid("637d5037-c3d0-4ed9-b694-c831d94afc9c"),11, 1.0, 11, 1.0, 8, 0.6, 1.0, 1, "Warrior" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerId",
                table: "Characters",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersCharacters_CharacterId",
                table: "PlayersCharacters",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersCharacters");

            migrationBuilder.DropTable(
                name: "Characters");

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

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "ATK", "AtkModifier", "CON", "ConModifier", "DEX", "DexModifier", "InitiativeModifier", "Level", "Name" },
                values: new object[,]
                {
                    { new Guid("0d32bc3f-0826-4618-952f-2b37170cd4b5"), 12, 1.5, 10, 0.5, 8, 0.6, 1.5, 1, "Wizard" },
                    { new Guid("63d0109f-7fa8-4cc6-b794-6dca5db60207"), 11, 1.0, 11, 1.0, 8, 0.6, 1.0, 1, "Warrior" },
                    { new Guid("a2001a3f-2d5c-48cf-a420-321fa129adc5"), 10, 0.8, 10, 0.8, 10, 1.0, 1.0, 1, "Thief" }
                });
        }
    }
}
