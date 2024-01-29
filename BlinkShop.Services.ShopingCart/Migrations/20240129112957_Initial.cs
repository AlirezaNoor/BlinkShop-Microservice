using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlinkShop.Services.ShopingCart.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CratHeaders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CratHeaders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CardDtailes",
                columns: table => new
                {
                    CardDtailesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardHeaderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDtailes", x => x.CardDtailesId);
                    table.ForeignKey(
                        name: "FK_CardDtailes_CratHeaders_CardHeaderId",
                        column: x => x.CardHeaderId,
                        principalTable: "CratHeaders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardDtailes_CardHeaderId",
                table: "CardDtailes",
                column: "CardHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDtailes");

            migrationBuilder.DropTable(
                name: "CratHeaders");
        }
    }
}
