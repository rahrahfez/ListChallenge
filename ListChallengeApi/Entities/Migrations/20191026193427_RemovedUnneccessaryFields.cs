using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class RemovedUnneccessaryFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "root",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_root", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "factory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RootId = table.Column<Guid>(nullable: false),
                    RangeLow = table.Column<int>(nullable: false),
                    RangeHigh = table.Column<int>(nullable: false),
                    RootTreeModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factory_root_RootTreeModelId",
                        column: x => x.RootTreeModelId,
                        principalTable: "root",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "child",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FactoryId = table.Column<Guid>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    FactoryModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child", x => x.Id);
                    table.ForeignKey(
                        name: "FK_child_factory_FactoryModelId",
                        column: x => x.FactoryModelId,
                        principalTable: "factory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_child_FactoryModelId",
                table: "child",
                column: "FactoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_factory_RootTreeModelId",
                table: "factory",
                column: "RootTreeModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "child");

            migrationBuilder.DropTable(
                name: "factory");

            migrationBuilder.DropTable(
                name: "root");
        }
    }
}
