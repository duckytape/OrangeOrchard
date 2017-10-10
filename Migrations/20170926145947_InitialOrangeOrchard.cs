using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OrangeOrchard.Migrations
{
    public partial class InitialOrangeOrchard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Tree");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tree",
                type: "TEXT",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Tree",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Tree");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tree",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tree",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Tree",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Tree",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
