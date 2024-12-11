using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAuditIdName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "audit",
                table: "AuditLog",
                newName: "AuditId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuditId",
                schema: "audit",
                table: "AuditLog",
                newName: "Id");
        }
    }
}
