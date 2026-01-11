using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Bancário_Simples.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_Users_UserId",
                table: "PaymentHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaymentHistories_UserId",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PaymentHistories");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PaymentHistories",
                newName: "UserTransferenceId");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "PaymentHistories",
                newName: "transferAmount");

            migrationBuilder.AddColumn<int>(
                name: "UserLogedId",
                table: "PaymentHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_UserLogedId",
                table: "PaymentHistories",
                column: "UserLogedId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_Users_UserLogedId",
                table: "PaymentHistories",
                column: "UserLogedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_Users_UserLogedId",
                table: "PaymentHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaymentHistories_UserLogedId",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "UserLogedId",
                table: "PaymentHistories");

            migrationBuilder.RenameColumn(
                name: "transferAmount",
                table: "PaymentHistories",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "UserTransferenceId",
                table: "PaymentHistories",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PaymentHistories",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_UserId",
                table: "PaymentHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_Users_UserId",
                table: "PaymentHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
