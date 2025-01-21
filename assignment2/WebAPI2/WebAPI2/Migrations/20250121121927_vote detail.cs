using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI2.Migrations
{
    /// <inheritdoc />
    public partial class votedetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoteDetails",
                columns: table => new
                {
                    VoteDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TopicDetail = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteDetails", x => x.VoteDetailID);
                });

            migrationBuilder.CreateTable(
                name: "OptionDetails",
                columns: table => new
                {
                    OptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    OptionScore = table.Column<int>(type: "int", nullable: false),
                    OptionIsVote = table.Column<bool>(type: "bit", nullable: false),
                    VoteDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionDetails", x => x.OptionID);
                    table.ForeignKey(
                        name: "FK_OptionDetails_VoteDetails_VoteDetailId",
                        column: x => x.VoteDetailId,
                        principalTable: "VoteDetails",
                        principalColumn: "VoteDetailID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptionDetails_VoteDetailId",
                table: "OptionDetails",
                column: "VoteDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionDetails");

            migrationBuilder.DropTable(
                name: "VoteDetails");
        }
    }
}
