using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlinkShop.Services.Coupon.Api.Migrations
{
    /// <inheritdoc />
    public partial class thisisfirstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "model",
                keyColumn: "CouponId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 1, 26, 11, 40, 7, 516, DateTimeKind.Local).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "model",
                keyColumn: "CouponId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 1, 26, 11, 40, 7, 516, DateTimeKind.Local).AddTicks(8943));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "model",
                keyColumn: "CouponId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 1, 21, 15, 5, 44, 582, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "model",
                keyColumn: "CouponId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 1, 21, 15, 5, 44, 582, DateTimeKind.Local).AddTicks(8974));
        }
    }
}
