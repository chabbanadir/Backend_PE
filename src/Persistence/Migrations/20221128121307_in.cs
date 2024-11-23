using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            /*migrationBuilder.CreateIndex(
                name: "IX_Infos_FK_ComponentId",
                table: "Infos",
                column: "FK_ComponentId");*/
                migrationBuilder.CreateTable(
                name: "DrawingData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TEPartNumber = table.Column<string>(nullable: true),
                    CustomerPN = table.Column<string>(nullable: true),
                    ProjectNumber = table.Column<string>(nullable: true),
                    OEM = table.Column<string>(nullable: true),
                    HarnessMaker = table.Column<string>(nullable: true),
                    NumberOfConnectors = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentWithSide",
                columns: table => new
                {
                    DrawingDataId = table.Column<Guid>(nullable: false),
                    ComponentId = table.Column<Guid>(nullable: false),
                    Side = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentWithSide", x => new { x.DrawingDataId, x.ComponentId });
                    table.ForeignKey(
                        name: "FK_ComponentWithSide_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components", // Update the table name to match your 'Component' table
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentWithSide_DrawingData_DrawingDataId",
                        column: x => x.DrawingDataId,
                        principalTable: "DrawingData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<string>(
            name: "CDPath",
            table: "DrawingData",
            nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PDPath",
                table: "DrawingData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExcelFilePath",
                table: "DrawingData",
                nullable: true);
                
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "DrawingData",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentWithSide_ComponentId",
                table: "ComponentWithSide",
                column: "ComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentWithSide");

            migrationBuilder.DropTable(
                name: "DrawingData");
            
            migrationBuilder.DropColumn(
                name: "CDPath",
                table: "DrawingData");

            migrationBuilder.DropColumn(
                name: "PDPath",
                table: "DrawingData");

            migrationBuilder.DropColumn(
                name: "ExcelFilePath",
                table: "DrawingData");
        }
    }
}


