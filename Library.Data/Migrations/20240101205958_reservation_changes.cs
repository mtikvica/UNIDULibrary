using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations;

/// <inheritdoc />
public partial class reservation_changes : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Reservations_Books_BookId",
            table: "Reservations");

        migrationBuilder.RenameColumn(
            name: "BookId",
            table: "Reservations",
            newName: "BookCopyId");

        migrationBuilder.RenameIndex(
            name: "IX_Reservations_BookId",
            table: "Reservations",
            newName: "IX_Reservations_BookCopyId");

        migrationBuilder.AddForeignKey(
            name: "FK_Reservations_BookCopies_BookCopyId",
            table: "Reservations",
            column: "BookCopyId",
            principalTable: "BookCopies",
            principalColumn: "CopyId",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Reservations_BookCopies_BookCopyId",
            table: "Reservations");

        migrationBuilder.RenameColumn(
            name: "BookCopyId",
            table: "Reservations",
            newName: "BookId");

        migrationBuilder.RenameIndex(
            name: "IX_Reservations_BookCopyId",
            table: "Reservations",
            newName: "IX_Reservations_BookId");

        migrationBuilder.AddForeignKey(
            name: "FK_Reservations_Books_BookId",
            table: "Reservations",
            column: "BookId",
            principalTable: "Books",
            principalColumn: "BookId",
            onDelete: ReferentialAction.Cascade);
    }
}
