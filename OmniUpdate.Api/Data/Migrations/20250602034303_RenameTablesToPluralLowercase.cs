using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniUpdate.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesToPluralLowercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_UserId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventIntegration_Event_EventId",
                table: "EventIntegration");

            migrationBuilder.DropForeignKey(
                name: "FK_EventIntegration_UserIntegration_UserIntegrationId",
                table: "EventIntegration");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIntegration_Integration_IntegrationId",
                table: "UserIntegration");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIntegration_User_UserId",
                table: "UserIntegration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIntegration",
                table: "UserIntegration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Integration",
                table: "Integration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventIntegration",
                table: "EventIntegration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "UserIntegration",
                newName: "userintegrations");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Integration",
                newName: "integrations");

            migrationBuilder.RenameTable(
                name: "EventIntegration",
                newName: "eventintegrations");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "events");

            migrationBuilder.RenameIndex(
                name: "IX_UserIntegration_UserId",
                table: "userintegrations",
                newName: "IX_userintegrations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserIntegration_IntegrationId",
                table: "userintegrations",
                newName: "IX_userintegrations_IntegrationId");

            migrationBuilder.RenameIndex(
                name: "IX_EventIntegration_UserIntegrationId",
                table: "eventintegrations",
                newName: "IX_eventintegrations_UserIntegrationId");

            migrationBuilder.RenameIndex(
                name: "IX_EventIntegration_EventId",
                table: "eventintegrations",
                newName: "IX_eventintegrations_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_UserId",
                table: "events",
                newName: "IX_events_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userintegrations",
                table: "userintegrations",
                column: "UserIntegrationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_integrations",
                table: "integrations",
                column: "IntegrationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_eventintegrations",
                table: "eventintegrations",
                column: "EventIntegrationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                table: "events",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_eventintegrations_events_EventId",
                table: "eventintegrations",
                column: "EventId",
                principalTable: "events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eventintegrations_userintegrations_UserIntegrationId",
                table: "eventintegrations",
                column: "UserIntegrationId",
                principalTable: "userintegrations",
                principalColumn: "UserIntegrationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_users_UserId",
                table: "events",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userintegrations_integrations_IntegrationId",
                table: "userintegrations",
                column: "IntegrationId",
                principalTable: "integrations",
                principalColumn: "IntegrationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userintegrations_users_UserId",
                table: "userintegrations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_eventintegrations_events_EventId",
                table: "eventintegrations");

            migrationBuilder.DropForeignKey(
                name: "FK_eventintegrations_userintegrations_UserIntegrationId",
                table: "eventintegrations");

            migrationBuilder.DropForeignKey(
                name: "FK_events_users_UserId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_userintegrations_integrations_IntegrationId",
                table: "userintegrations");

            migrationBuilder.DropForeignKey(
                name: "FK_userintegrations_users_UserId",
                table: "userintegrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userintegrations",
                table: "userintegrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_integrations",
                table: "integrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                table: "events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_eventintegrations",
                table: "eventintegrations");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "userintegrations",
                newName: "UserIntegration");

            migrationBuilder.RenameTable(
                name: "integrations",
                newName: "Integration");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "eventintegrations",
                newName: "EventIntegration");

            migrationBuilder.RenameIndex(
                name: "IX_userintegrations_UserId",
                table: "UserIntegration",
                newName: "IX_UserIntegration_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userintegrations_IntegrationId",
                table: "UserIntegration",
                newName: "IX_UserIntegration_IntegrationId");

            migrationBuilder.RenameIndex(
                name: "IX_events_UserId",
                table: "Event",
                newName: "IX_Event_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_eventintegrations_UserIntegrationId",
                table: "EventIntegration",
                newName: "IX_EventIntegration_UserIntegrationId");

            migrationBuilder.RenameIndex(
                name: "IX_eventintegrations_EventId",
                table: "EventIntegration",
                newName: "IX_EventIntegration_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIntegration",
                table: "UserIntegration",
                column: "UserIntegrationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Integration",
                table: "Integration",
                column: "IntegrationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventIntegration",
                table: "EventIntegration",
                column: "EventIntegrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_UserId",
                table: "Event",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventIntegration_Event_EventId",
                table: "EventIntegration",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventIntegration_UserIntegration_UserIntegrationId",
                table: "EventIntegration",
                column: "UserIntegrationId",
                principalTable: "UserIntegration",
                principalColumn: "UserIntegrationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIntegration_Integration_IntegrationId",
                table: "UserIntegration",
                column: "IntegrationId",
                principalTable: "Integration",
                principalColumn: "IntegrationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIntegration_User_UserId",
                table: "UserIntegration",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
