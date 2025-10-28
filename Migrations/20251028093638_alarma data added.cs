using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Axios.Migrations
{
    /// <inheritdoc />
    public partial class alarmadataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alarmas",
                columns: new[] { "Id_Alarma", "Nombre", "Ruta" },
                values: new object[,]
                {
                    { 1, "", "" },
                    { 2, "Zumbido", "xxxxx/Zumbido.mp3" },
                    { 3, "Pitido", "xxxxx/Pitido.mp3" },
                    { 4, "Himno", "xxxxx/Colombia.mp3" }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id_Tarea", "Descripcion", "Fecha_Limite", "Hora", "ID_Alarma", "ID_Usuario", "Titulo" },
                values: new object[,]
                {
                    { 1, "Tengo que salir por más tardar a esta hora para llegar", new DateOnly(2025, 10, 28), new TimeOnly(12, 30, 0), 0, 1, "Cita Odontologica" },
                    { 2, "El Examen comienza a esta hora", new DateOnly(2025, 12, 5), new TimeOnly(10, 0, 0), 1, 2, "Examen Estadistica" },
                    { 3, "A esta hora tengo que tomar mis pastillas", new DateOnly(2025, 10, 15), new TimeOnly(9, 30, 0), 2, 3, "Pastillas para presión" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id_Usuario", "Contraseña", "Correo", "Nombre" },
                values: new object[,]
                {
                    { 1, "DispositivosMoviles", "Fernando.buelvas176@pascualbravo.edu.co", "Fernando José" },
                    { 2, "DispositivosMoviles123", "Juan.Calderon698@pascualbravo.edu.co", "Juan Calderon" },
                    { 3, "Cardona", "Omar.Cardona@pascualbravo.edu.co", "Omar Andres" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alarmas",
                keyColumn: "Id_Alarma",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alarmas",
                keyColumn: "Id_Alarma",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Alarmas",
                keyColumn: "Id_Alarma",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Alarmas",
                keyColumn: "Id_Alarma",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id_Tarea",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id_Tarea",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id_Tarea",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id_Usuario",
                keyValue: 3);
        }
    }
}
