using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondoSphere.Infrastructure.Data.Migrations.Condominium
{
    /// <inheritdoc />
    public partial class AddJitsiFieldsToAssemblyCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AssemblyMessages",
                newName: "SentAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "AssemblyMessages",
                newName: "CreatedAt");
        }
    }
}
