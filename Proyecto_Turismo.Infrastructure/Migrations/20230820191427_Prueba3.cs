using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Turismo.Infrastructure.Migrations
{
    public partial class Prueba3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_AspNetUsers_UserId",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Habitacion_IdHabitaciones",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Paquete_IdPaquete",
                table: "Reservaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones");

            migrationBuilder.RenameTable(
                name: "Reservaciones",
                newName: "Reservacion");

            migrationBuilder.RenameIndex(
                name: "IX_Reservaciones_UserId",
                table: "Reservacion",
                newName: "IX_Reservacion_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservaciones_IdPaquete",
                table: "Reservacion",
                newName: "IX_Reservacion_IdPaquete");

            migrationBuilder.RenameIndex(
                name: "IX_Reservaciones_IdHabitaciones",
                table: "Reservacion",
                newName: "IX_Reservacion_IdHabitaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservacion",
                table: "Reservacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_AspNetUsers_UserId",
                table: "Reservacion",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_Habitacion_IdHabitaciones",
                table: "Reservacion",
                column: "IdHabitaciones",
                principalTable: "Habitacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_Paquete_IdPaquete",
                table: "Reservacion",
                column: "IdPaquete",
                principalTable: "Paquete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_AspNetUsers_UserId",
                table: "Reservacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_Habitacion_IdHabitaciones",
                table: "Reservacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_Paquete_IdPaquete",
                table: "Reservacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservacion",
                table: "Reservacion");

            migrationBuilder.RenameTable(
                name: "Reservacion",
                newName: "Reservaciones");

            migrationBuilder.RenameIndex(
                name: "IX_Reservacion_UserId",
                table: "Reservaciones",
                newName: "IX_Reservaciones_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservacion_IdPaquete",
                table: "Reservaciones",
                newName: "IX_Reservaciones_IdPaquete");

            migrationBuilder.RenameIndex(
                name: "IX_Reservacion_IdHabitaciones",
                table: "Reservaciones",
                newName: "IX_Reservaciones_IdHabitaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservaciones",
                table: "Reservaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_AspNetUsers_UserId",
                table: "Reservaciones",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Habitacion_IdHabitaciones",
                table: "Reservaciones",
                column: "IdHabitaciones",
                principalTable: "Habitacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Paquete_IdPaquete",
                table: "Reservaciones",
                column: "IdPaquete",
                principalTable: "Paquete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
