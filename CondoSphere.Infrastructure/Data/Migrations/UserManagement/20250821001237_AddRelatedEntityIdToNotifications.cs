using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondoSphere.Infrastructure.Data.Migrations.UserManagement
{
    /// <inheritdoc />
    public partial class AddRelatedEntityIdToNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedEntityId",
                table: "Notifications",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedEntityId",
                table: "Notifications");
        }
    }
}
