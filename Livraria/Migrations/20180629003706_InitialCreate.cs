using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Livraria.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    authors = table.Column<string>(maxLength: 300, nullable: true),
                    buy_date = table.Column<DateTime>(nullable: false),
                    buy_price = table.Column<decimal>(nullable: false),
                    edition = table.Column<string>(maxLength: 100, nullable: true),
                    isbn = table.Column<string>(maxLength: 13, nullable: true),
                    name = table.Column<string>(maxLength: 300, nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    publish_year = table.Column<int>(nullable: true),
                    sell_date = table.Column<DateTime>(nullable: true),
                    sell_price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
