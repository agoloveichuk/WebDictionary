using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    DictionaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.DictionaryId);
                });

            migrationBuilder.CreateTable(
                name: "Phrase",
                columns: table => new
                {
                    PhraseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictionaryId = table.Column<int>(type: "int", nullable: false),
                    EnPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UaPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrase", x => x.PhraseId);
                    table.ForeignKey(
                        name: "FK_Phrase_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictionaryId = table.Column<int>(type: "int", nullable: false),
                    EnWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UaWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.WordId);
                    table.ForeignKey(
                        name: "FK_Word_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dictionary",
                columns: new[] { "DictionaryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Animals", "Animals" },
                    { 2, "Days", "Days" },
                    { 3, "Food", "Food" }
                });

            migrationBuilder.InsertData(
                table: "Phrase",
                columns: new[] { "PhraseId", "Definition", "DictionaryId", "EnPhrase", "UaPhrase" },
                values: new object[,]
                {
                    { 1, "Animal Phrase Description", 1, "Mantis Shrimp", "Креветка богомол" },
                    { 2, "Animal Phrase Description", 1, "Wolf Fish", "Риба Вовк" }
                });

            migrationBuilder.InsertData(
                table: "Word",
                columns: new[] { "WordId", "Definition", "DictionaryId", "EnWord", "UaWord" },
                values: new object[,]
                {
                    { 1, "Animal Description", 1, "Cat", "Кіт" },
                    { 2, "Animal Description", 1, "Dog", "Собака" },
                    { 3, "Animal Description", 1, "Pig", "Свиня" },
                    { 4, "Animal Description", 1, "Mouse", "Миша" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phrase_DictionaryId",
                table: "Phrase",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Word_DictionaryId",
                table: "Word",
                column: "DictionaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phrase");

            migrationBuilder.DropTable(
                name: "Word");

            migrationBuilder.DropTable(
                name: "Dictionary");
        }
    }
}
