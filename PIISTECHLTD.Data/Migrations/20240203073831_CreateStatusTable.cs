using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIISTECHLTD.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shipment");

            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "Shipment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_StatusId",
                table: "Shipment",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Status_StatusId",
                table: "Shipment",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Status_StatusId",
                table: "Shipment");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_StatusId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Shipment");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Shipment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
