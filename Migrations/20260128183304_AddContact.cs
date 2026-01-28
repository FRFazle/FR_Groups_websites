using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FR_Groups_websites.Migrations
{
    /// <inheritdoc />
    public partial class AddContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create T_Contacts table only
            migrationBuilder.CreateTable(
                name: "T_Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SocialLinks_Facebook = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SocialLinks_LinkedIn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SocialLinks_Twitter = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SocialLinks_YouTube = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Contacts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop only T_Contacts table
            migrationBuilder.DropTable(
                name: "T_Contacts");
        }
    }
}
