using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Loan_Update : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "EndDate",
            table: "Loan");

        migrationBuilder.RenameColumn(
            name: "DateRange_DueDate",
            table: "Loan",
            newName: "DueDate");

        migrationBuilder.RenameColumn(
            name: "StartDate",
            table: "Loan",
            newName: "LoanedDate");

        migrationBuilder.AlterColumn<DateOnly>(
            name: "DueDate",
            table: "Loan",
            type: "date",
            nullable: false,
            defaultValue: new DateOnly(1, 1, 1),
            oldClrType: typeof(DateOnly),
            oldType: "date",
            oldNullable: true);

        migrationBuilder.AddColumn<DateOnly>(
            name: "ReturnedDate",
            table: "Loan",
            type: "date",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ReturnedDate",
            table: "Loan");

        migrationBuilder.RenameColumn(
            name: "DueDate",
            table: "Loan",
            newName: "DateRange_DueDate");

        migrationBuilder.RenameColumn(
            name: "LoanedDate",
            table: "Loan",
            newName: "StartDate");

        migrationBuilder.AlterColumn<DateOnly>(
            name: "DateRange_DueDate",
            table: "Loan",
            type: "date",
            nullable: true,
            oldClrType: typeof(DateOnly),
            oldType: "date");

        migrationBuilder.AddColumn<DateOnly>(
            name: "EndDate",
            table: "Loan",
            type: "date",
            nullable: false,
            defaultValue: new DateOnly(1, 1, 1));
    }
}
