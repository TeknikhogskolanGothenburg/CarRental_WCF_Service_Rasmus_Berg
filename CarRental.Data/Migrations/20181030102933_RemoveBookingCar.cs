using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Data.Migrations
{
    public partial class RemoveBookingCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCars");

            migrationBuilder.AddColumn<int>(
                name: "BookingCarId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingCarId",
                table: "Bookings",
                column: "BookingCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_BookingCarId",
                table: "Bookings",
                column: "BookingCarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cars_BookingCarId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingCarId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingCarId",
                table: "Bookings");

            migrationBuilder.CreateTable(
                name: "BookingCars",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCars", x => new { x.BookingId, x.CarId });
                    table.ForeignKey(
                        name: "FK_BookingCars_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCars_CarId",
                table: "BookingCars",
                column: "CarId");
        }
    }
}
