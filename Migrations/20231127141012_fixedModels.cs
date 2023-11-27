using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBooking.Migrations
{
    /// <inheritdoc />
    public partial class fixedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Rooms_SelectedRoomId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_SelectedRoomId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "SelectedRoomId",
                table: "Reservation",
                newName: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Reservation",
                newName: "SelectedRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SelectedRoomId",
                table: "Reservation",
                column: "SelectedRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Rooms_SelectedRoomId",
                table: "Reservation",
                column: "SelectedRoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
