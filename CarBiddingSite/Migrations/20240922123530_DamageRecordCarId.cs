using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBiddingSite.Migrations
{
    /// <inheritdoc />
    public partial class DamageRecordCarId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRecords_Cars_CarId",
                table: "DamageRecords");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "DamageRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRecords_Cars_CarId",
                table: "DamageRecords",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRecords_Cars_CarId",
                table: "DamageRecords");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "DamageRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRecords_Cars_CarId",
                table: "DamageRecords",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
