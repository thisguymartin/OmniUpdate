using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace OmniUpdate.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Archived", "ImageUrl", "CreateDate", "UpdateDate" },
                values: new object[,]
                {
              { 1, "John Doe", false, "https://avatars.githubusercontent.com/u/1001?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 2, "Jane Smith", false, "https://avatars.githubusercontent.com/u/1002?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 3, "Alice Johnsonohnson", false, "https://avatars.githubusercontent.com/u/1003?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 4, "Bob Brown", false, "https://avatars.githubusercontent.com/u/1004?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 5, "Carol White", false, "https://avatars.githubusercontent.com/u/1005?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 6, "David Green",false, "https://avatars.githubusercontent.com/u/1006?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 7, "Eve Black", false, "https://avatars.githubusercontent.com/u/1007?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 8, "Frank Grey", false, "https://avatars.githubusercontent.com/u/1008?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 9, "Grace Hall", false, "https://avatars.githubusercontent.com/u/1009?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 10, "Henry Lee",false, "https://avatars.githubusercontent.com/u/1010?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 11, "Ivy King", false, "https://avatars.githubusercontent.com/u/1011?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 12, "Jack Long", false, "https://avatars.githubusercontent.com/u/1012?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 13, "Kara Young",false, "https://avatars.githubusercontent.com/u/1013?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 14, "Liam Park",  false, "https://avatars.githubusercontent.com/u/1014?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 15, "Mia Wright", false, "https://avatars.githubusercontent.com/u/1015?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 16, "Noah Ford",  false, "https://avatars.githubusercontent.com/u/1016?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 17, "Olivia Hill", false, "https://avatars.githubusercontent.com/u/1017?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 18, "Paul Cook",  false, "https://avatars.githubusercontent.com/u/1018?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 19, "Quinn Bell", false, "https://avatars.githubusercontent.com/u/1019?v=4", DateTime.UtcNow, DateTime.UtcNow },
            { 20, "Ryan Shaw",  false, "https://avatars.githubusercontent.com/u/1020?v=4", DateTime.UtcNow, DateTime.UtcNow }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // In the Down method, you should undo the changes made in the Up method
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2 });
        }
    }
}
