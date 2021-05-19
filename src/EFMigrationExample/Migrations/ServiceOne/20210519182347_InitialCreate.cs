using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMigrationExample.Migrations.ServiceOne
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ServiceOne");

            migrationBuilder.CreateTable(
                name: "CarModels",
                schema: "ServiceOne",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "ServiceOne",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "ServiceOne",
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Name",
                schema: "ServiceOne",
                table: "CarModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TypeId",
                schema: "ServiceOne",
                table: "Cars",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars",
                schema: "ServiceOne");

            migrationBuilder.DropTable(
                name: "CarModels",
                schema: "ServiceOne");
        }
    }
}
