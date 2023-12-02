using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Authors",
            columns: table => new
            {
                AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                AuthorOpenLibraryKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Authors", x => x.AuthorId);
            });

        migrationBuilder.CreateTable(
            name: "Departments",
            columns: table => new
            {
                DepartmentId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Departments", x => x.DepartmentId);
            });

        migrationBuilder.CreateTable(
            name: "Locations",
            columns: table => new
            {
                LocationId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Locations", x => x.LocationId);
            });

        migrationBuilder.CreateTable(
            name: "Publishers",
            columns: table => new
            {
                PublisherId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Publishers", x => x.PublisherId);
            });

        migrationBuilder.CreateTable(
            name: "Roles",
            columns: table => new
            {
                RoleId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Roles", x => x.RoleId);
            });

        migrationBuilder.CreateTable(
            name: "Subjects",
            columns: table => new
            {
                SubjectId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Subjects", x => x.SubjectId);
            });

        migrationBuilder.CreateTable(
            name: "Books",
            columns: table => new
            {
                BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                NumberOfPages = table.Column<int>(type: "int", nullable: true),
                DepartmentId = table.Column<int>(type: "int", nullable: true),
                PublisherId = table.Column<int>(type: "int", nullable: true),
                LocationId = table.Column<int>(type: "int", nullable: true),
                PublicationDate = table.Column<DateOnly>(type: "date", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Books", x => x.BookId);
                table.ForeignKey(
                    name: "FK_Books_Departments_DepartmentId",
                    column: x => x.DepartmentId,
                    principalTable: "Departments",
                    principalColumn: "DepartmentId");
                table.ForeignKey(
                    name: "FK_Books_Locations_LocationId",
                    column: x => x.LocationId,
                    principalTable: "Locations",
                    principalColumn: "LocationId");
                table.ForeignKey(
                    name: "FK_Books_Publishers_PublisherId",
                    column: x => x.PublisherId,
                    principalTable: "Publishers",
                    principalColumn: "PublisherId");
            });

        migrationBuilder.CreateTable(
            name: "Staff",
            columns: table => new
            {
                StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                RoleId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Staff", x => x.StaffId);
                table.ForeignKey(
                    name: "FK_Staff_Roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "Roles",
                    principalColumn: "RoleId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Students",
            columns: table => new
            {
                StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Year = table.Column<int>(type: "int", nullable: false),
                DepartmentId = table.Column<int>(type: "int", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                RoleId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Students", x => x.StudentId);
                table.ForeignKey(
                    name: "FK_Students_Departments_DepartmentId",
                    column: x => x.DepartmentId,
                    principalTable: "Departments",
                    principalColumn: "DepartmentId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Students_Roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "Roles",
                    principalColumn: "RoleId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AuthorBook",
            columns: table => new
            {
                AuthorsAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                BooksBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthorId, x.BooksBookId });
                table.ForeignKey(
                    name: "FK_AuthorBook_Authors_AuthorsAuthorId",
                    column: x => x.AuthorsAuthorId,
                    principalTable: "Authors",
                    principalColumn: "AuthorId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AuthorBook_Books_BooksBookId",
                    column: x => x.BooksBookId,
                    principalTable: "Books",
                    principalColumn: "BookId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "BookCopies",
            columns: table => new
            {
                CopyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BookCopies", x => x.CopyId);
                table.ForeignKey(
                    name: "FK_BookCopies_Books_BookId",
                    column: x => x.BookId,
                    principalTable: "Books",
                    principalColumn: "BookId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "BookSubject",
            columns: table => new
            {
                BooksBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SubjectsSubjectId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BookSubject", x => new { x.BooksBookId, x.SubjectsSubjectId });
                table.ForeignKey(
                    name: "FK_BookSubject_Books_BooksBookId",
                    column: x => x.BooksBookId,
                    principalTable: "Books",
                    principalColumn: "BookId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_BookSubject_Subjects_SubjectsSubjectId",
                    column: x => x.SubjectsSubjectId,
                    principalTable: "Subjects",
                    principalColumn: "SubjectId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "InventoryStates",
            columns: table => new
            {
                InventoryStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                AvailableCount = table.Column<int>(type: "int", nullable: true),
                BorrowedCount = table.Column<int>(type: "int", nullable: true),
                ReservedCount = table.Column<int>(type: "int", nullable: true),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InventoryStates", x => x.InventoryStateId);
                table.ForeignKey(
                    name: "FK_InventoryStates_Books_BookId",
                    column: x => x.BookId,
                    principalTable: "Books",
                    principalColumn: "BookId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Reservations",
            columns: table => new
            {
                ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                table.ForeignKey(
                    name: "FK_Reservations_Books_BookId",
                    column: x => x.BookId,
                    principalTable: "Books",
                    principalColumn: "BookId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Reservations_Students_StudentId",
                    column: x => x.StudentId,
                    principalTable: "Students",
                    principalColumn: "StudentId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Loans",
            columns: table => new
            {
                LoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CopyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                LoanStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Loans", x => x.LoanId);
                table.ForeignKey(
                    name: "FK_Loans_BookCopies_CopyId",
                    column: x => x.CopyId,
                    principalTable: "BookCopies",
                    principalColumn: "CopyId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Loans_Students_StudentId",
                    column: x => x.StudentId,
                    principalTable: "Students",
                    principalColumn: "StudentId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Fines",
            columns: table => new
            {
                FineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                PaidStatus = table.Column<bool>(type: "bit", nullable: false),
                IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Fines", x => x.FineId);
                table.ForeignKey(
                    name: "FK_Fines_Loans_LoanId",
                    column: x => x.LoanId,
                    principalTable: "Loans",
                    principalColumn: "LoanId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_AuthorBook_BooksBookId",
            table: "AuthorBook",
            column: "BooksBookId");

        migrationBuilder.CreateIndex(
            name: "IX_BookCopies_BookId",
            table: "BookCopies",
            column: "BookId");

        migrationBuilder.CreateIndex(
            name: "IX_Books_DepartmentId",
            table: "Books",
            column: "DepartmentId");

        migrationBuilder.CreateIndex(
            name: "IX_Books_LocationId",
            table: "Books",
            column: "LocationId");

        migrationBuilder.CreateIndex(
            name: "IX_Books_PublisherId",
            table: "Books",
            column: "PublisherId");

        migrationBuilder.CreateIndex(
            name: "IX_BookSubject_SubjectsSubjectId",
            table: "BookSubject",
            column: "SubjectsSubjectId");

        migrationBuilder.CreateIndex(
            name: "IX_Fines_LoanId",
            table: "Fines",
            column: "LoanId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_InventoryStates_BookId",
            table: "InventoryStates",
            column: "BookId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Loans_CopyId",
            table: "Loans",
            column: "CopyId");

        migrationBuilder.CreateIndex(
            name: "IX_Loans_StudentId",
            table: "Loans",
            column: "StudentId");

        migrationBuilder.CreateIndex(
            name: "IX_Reservations_BookId",
            table: "Reservations",
            column: "BookId");

        migrationBuilder.CreateIndex(
            name: "IX_Reservations_StudentId",
            table: "Reservations",
            column: "StudentId");

        migrationBuilder.CreateIndex(
            name: "IX_Staff_RoleId",
            table: "Staff",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "IX_Students_DepartmentId",
            table: "Students",
            column: "DepartmentId");

        migrationBuilder.CreateIndex(
            name: "IX_Students_RoleId",
            table: "Students",
            column: "RoleId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AuthorBook");

        migrationBuilder.DropTable(
            name: "BookSubject");

        migrationBuilder.DropTable(
            name: "Fines");

        migrationBuilder.DropTable(
            name: "InventoryStates");

        migrationBuilder.DropTable(
            name: "Reservations");

        migrationBuilder.DropTable(
            name: "Staff");

        migrationBuilder.DropTable(
            name: "Authors");

        migrationBuilder.DropTable(
            name: "Subjects");

        migrationBuilder.DropTable(
            name: "Loans");

        migrationBuilder.DropTable(
            name: "BookCopies");

        migrationBuilder.DropTable(
            name: "Students");

        migrationBuilder.DropTable(
            name: "Books");

        migrationBuilder.DropTable(
            name: "Roles");

        migrationBuilder.DropTable(
            name: "Departments");

        migrationBuilder.DropTable(
            name: "Locations");

        migrationBuilder.DropTable(
            name: "Publishers");
    }
}
