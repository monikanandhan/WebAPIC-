using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace MyBook.Migrations
{
    public partial class MyBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookSample",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateRead = table.Column<DateTime>(type: "datetime", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    Genere = table.Column<string>(type: "text", nullable: true),
                    CoverUrl = table.Column<string>(type: "text", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookSample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookSample_publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_Author", x => x.Id);
                    table.ForeignKey(
                        name: "FK_book_Author_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_Author_bookSample_BookId",
                        column: x => x.BookId,
                        principalTable: "bookSample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_Author_AuthorId",
                table: "book_Author",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_book_Author_BookId",
                table: "book_Author",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookSample_PublisherId",
                table: "bookSample",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_Author");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "bookSample");

            migrationBuilder.DropTable(
                name: "publisher");
        }
    }
}
