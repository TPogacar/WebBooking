using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBooking.Migrations
{
    /// <inheritdoc />
    public partial class completeddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservation_ReservationId",
                table: "Rooms",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservation_ReservationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Rooms");
        }
    }
}
