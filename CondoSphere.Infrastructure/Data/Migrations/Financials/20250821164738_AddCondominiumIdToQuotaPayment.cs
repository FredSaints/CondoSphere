using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondoSphere.Infrastructure.Data.Migrations.Financials
{
    /// <inheritdoc />
    public partial class AddCondominiumIdToQuotaPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CondominiumId",
                table: "QuotaPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CondominiumId",
                table: "QuotaPayments");
        }
    }
}
