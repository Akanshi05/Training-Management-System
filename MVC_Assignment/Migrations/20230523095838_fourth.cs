using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Batches_BatchId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_BatchId",
                table: "Requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Requests_BatchId",
                table: "Requests",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Batches_BatchId",
                table: "Requests",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
