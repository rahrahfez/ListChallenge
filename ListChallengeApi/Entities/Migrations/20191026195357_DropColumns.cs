using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class DropColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_child_factory_FactoryModelId",
                table: "child");

            migrationBuilder.DropForeignKey(
                name: "FK_factory_root_RootTreeModelId",
                table: "factory");

            migrationBuilder.DropIndex(
                name: "IX_factory_RootTreeModelId",
                table: "factory");

            migrationBuilder.DropIndex(
                name: "IX_child_FactoryModelId",
                table: "child");

            migrationBuilder.DropColumn(
                name: "RootTreeModelId",
                table: "factory");

            migrationBuilder.DropColumn(
                name: "FactoryModelId",
                table: "child");

            migrationBuilder.CreateIndex(
                name: "IX_factory_RootId",
                table: "factory",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_child_FactoryId",
                table: "child",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_child_factory_FactoryId",
                table: "child",
                column: "FactoryId",
                principalTable: "factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_factory_root_RootId",
                table: "factory",
                column: "RootId",
                principalTable: "root",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_child_factory_FactoryId",
                table: "child");

            migrationBuilder.DropForeignKey(
                name: "FK_factory_root_RootId",
                table: "factory");

            migrationBuilder.DropIndex(
                name: "IX_factory_RootId",
                table: "factory");

            migrationBuilder.DropIndex(
                name: "IX_child_FactoryId",
                table: "child");

            migrationBuilder.AddColumn<Guid>(
                name: "RootTreeModelId",
                table: "factory",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FactoryModelId",
                table: "child",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_factory_RootTreeModelId",
                table: "factory",
                column: "RootTreeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_child_FactoryModelId",
                table: "child",
                column: "FactoryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_child_factory_FactoryModelId",
                table: "child",
                column: "FactoryModelId",
                principalTable: "factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_factory_root_RootTreeModelId",
                table: "factory",
                column: "RootTreeModelId",
                principalTable: "root",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
