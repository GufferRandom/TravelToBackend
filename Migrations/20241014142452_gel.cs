using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelToBackend.Migrations
{
    /// <inheritdoc />
    public partial class gel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companiebi",
                columns: table => new
                {
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    owner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    img_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companiebi", x => x.Company_Id);
                });

            migrationBuilder.CreateTable(
                name: "Turebi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turebi", x => x.id);
                    table.ForeignKey(
                        name: "FK_Turebi_Companiebi_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Companiebi",
                        principalColumn: "Company_Id");
                });

            migrationBuilder.InsertData(
                table: "Companiebi",
                columns: new[] { "Company_Id", "Name", "description", "img_name", "owner" },
                values: new object[,]
                {
                    { 1, "TBCKVADRO", "saswauli kompania romelic arasdros iarsebs", "tbc_image.png", "gela" },
                    { 2, "liberti", "raxdeba sh", "liberti_img.png", "NEKA" },
                    { 3, "bog", "imedia", "bog_image.png", "NAK" },
                    { 4, "kripto", "iarsebs", "credit_bank.png", "bark" }
                });

            migrationBuilder.InsertData(
                table: "Turebi",
                columns: new[] { "id", "Company_Id", "Description", "Name", "Price", "image_name" },
                values: new object[,]
                {
                    { 1, 1, "aq iyo batoni wyali romelmac wyali dalia", "Antarqtida", 5.9900000000000002, "31394_1.jpg" },
                    { 2, 3, "tbilo tibifli", "Tbilisi", 15.99, "59564_1.jpg" },
                    { 3, 2, "parizelta dedaqali", "Parizi", 6.9900000000000002, "59564_1.jpg" },
                    { 4, 4, "მაგარიი პონტიიი", "Los-Angeles, CA", 15555.0, "ee2aa1e4-37d6-41e1-a3b5-ee7d35f0202d.jfif" },
                    { 5, 1, "მაგარიი პონტიიი", "Italy", 12341.0, "bffe2b9f-956c-41a5-a72e-12b08c899a45.jfif" },
                    { 6, 2, "მაგარიი პონტიიი", "Brazil", 15111.0, "b373e51c-0ba1-4f3b-887d-3499cb200d3c.jpg" },
                    { 7, 4, "მაგარიი პონტიიი", "Denmark", 19000.0, "f521cee9-6c84-4a02-8f75-9800f0002a53.jfif" },
                    { 8, 3, "მაგარიი პონტიიი", "Spain", 23000.0, "6d4ea991-f9a5-4ec6-8550-0e4e02e5ab4c.jfif" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turebi_Company_Id",
                table: "Turebi",
                column: "Company_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turebi");

            migrationBuilder.DropTable(
                name: "Companiebi");
        }
    }
}
