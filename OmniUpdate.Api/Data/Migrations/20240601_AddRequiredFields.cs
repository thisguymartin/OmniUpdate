using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OmniUpdate.Api.Data.Migrations
{
    public partial class AddRequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "events",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "events",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "events",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "eventintegrations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "eventintegrations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "Credentials",
                table: "userintegrations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Settings",
                table: "userintegrations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "userintegrations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "integrations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "integrations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Name", "users");
            migrationBuilder.DropColumn("Archived", "users");
            migrationBuilder.DropColumn("ImageUrl", "users");
            migrationBuilder.DropColumn("CreateDate", "users");
            migrationBuilder.DropColumn("UpdateDate", "users");
            migrationBuilder.DropColumn("Title", "events");
            migrationBuilder.DropColumn("StartTime", "events");
            migrationBuilder.DropColumn("EndTime", "events");
            migrationBuilder.DropColumn("CreatedAt", "events");
            migrationBuilder.DropColumn("Status", "eventintegrations");
            migrationBuilder.DropColumn("PublishedAt", "eventintegrations");
            migrationBuilder.DropColumn("Credentials", "userintegrations");
            migrationBuilder.DropColumn("Settings", "userintegrations");
            migrationBuilder.DropColumn("CreatedAt", "userintegrations");
            migrationBuilder.DropColumn("Name", "integrations");
            migrationBuilder.DropColumn("Description", "integrations");
        }
    }
}
