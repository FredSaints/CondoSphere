using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondoSphere.Infrastructure.Data.Migrations.Condominium
{
    /// <inheritdoc />
    public partial class AddJitsiFieldsToAssembly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JitsiRoomName",
                table: "Assemblies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JitsiRoomPassword",
                table: "Assemblies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JitsiRoomName",
                table: "Assemblies");

            migrationBuilder.DropColumn(
                name: "JitsiRoomPassword",
                table: "Assemblies");
        }
    }
}
