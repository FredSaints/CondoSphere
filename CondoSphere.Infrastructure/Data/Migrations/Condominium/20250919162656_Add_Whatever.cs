using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondoSphere.Infrastructure.Data.Migrations.Condominium
{
    /// <inheritdoc />
    public partial class Add_Whatever : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssemblyMessages");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "AssemblyParticipants");

            migrationBuilder.DropColumn(
                name: "IsEmployee",
                table: "AssemblyParticipants");

            migrationBuilder.DropColumn(
                name: "IsInvited",
                table: "AssemblyParticipants");

            migrationBuilder.DropColumn(
                name: "InvitedUserId",
                table: "AssemblyInvites");

            migrationBuilder.DropColumn(
                name: "RespondedAt",
                table: "AssemblyInvites");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AssemblyInvites");

            migrationBuilder.DropColumn(
                name: "MinutesUrl",
                table: "Assemblies");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AssemblyInvites",
                newName: "CondominiumId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AssemblyInvites",
                newName: "SentAt");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AssemblyParticipants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ExternalName",
                table: "AssemblyParticipants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedAt",
                table: "AssemblyParticipants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LeftAt",
                table: "AssemblyParticipants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AssemblyInvites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "participants",
                table: "Assemblies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalName",
                table: "AssemblyParticipants");

            migrationBuilder.DropColumn(
                name: "JoinedAt",
                table: "AssemblyParticipants");

            migrationBuilder.DropColumn(
                name: "LeftAt",
                table: "AssemblyParticipants");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AssemblyInvites");

            migrationBuilder.DropColumn(
                name: "participants",
                table: "Assemblies");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "AssemblyInvites",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CondominiumId",
                table: "AssemblyInvites",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AssemblyParticipants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "AssemblyParticipants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmployee",
                table: "AssemblyParticipants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInvited",
                table: "AssemblyParticipants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "InvitedUserId",
                table: "AssemblyInvites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RespondedAt",
                table: "AssemblyInvites",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AssemblyInvites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MinutesUrl",
                table: "Assemblies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssemblyMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssemblyId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderUserId = table.Column<int>(type: "int", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyMessages", x => x.Id);
                });
        }
    }
}
