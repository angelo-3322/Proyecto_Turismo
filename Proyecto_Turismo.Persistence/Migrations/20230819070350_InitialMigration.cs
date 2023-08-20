using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Turismo.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurante_Menus_menuId",
                table: "Restaurante");

            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropIndex(
                name: "IX_Restaurante_menuId",
                table: "Restaurante");

            migrationBuilder.DropColumn(
                name: "menuId",
                table: "Restaurante");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Habitaciones",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_IdMenu",
                table: "Restaurante",
                column: "IdMenu");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurante_Menus_IdMenu",
                table: "Restaurante",
                column: "IdMenu",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurante_Menus_IdMenu",
                table: "Restaurante");

            migrationBuilder.DropIndex(
                name: "IX_Restaurante_IdMenu",
                table: "Restaurante");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Habitaciones");

            migrationBuilder.AddColumn<int>(
                name: "menuId",
                table: "Restaurante",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitacionId = table.Column<int>(type: "int", nullable: true),
                    DatosImagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagenes_Habitaciones_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_menuId",
                table: "Restaurante",
                column: "menuId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_HabitacionId",
                table: "Imagenes",
                column: "HabitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurante_Menus_menuId",
                table: "Restaurante",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
