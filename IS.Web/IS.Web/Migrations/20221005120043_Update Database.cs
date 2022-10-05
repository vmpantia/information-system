using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IS.Web.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.RenameColumn(
                name: "InternalId",
                table: "Position_TRN",
                newName: "InternalID");

            migrationBuilder.RenameColumn(
                name: "Department_InternalId",
                table: "Position_TRN",
                newName: "Department_InternalID");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Position_TRN",
                newName: "RequestID");

            migrationBuilder.RenameColumn(
                name: "Manager_InternalId",
                table: "Department_TRN",
                newName: "Manager_InternalID");

            migrationBuilder.RenameColumn(
                name: "InternalId",
                table: "Department_TRN",
                newName: "InternalID");

            migrationBuilder.CreateTable(
                name: "Department_MST",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_MST", x => x.InternalID);
                });

            migrationBuilder.CreateTable(
                name: "Position_MST",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position_MST", x => x.InternalID);
                });

            migrationBuilder.CreateTable(
                name: "Request_LST",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FunctionID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_LST", x => x.RequestID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department_MST");

            migrationBuilder.DropTable(
                name: "Position_MST");

            migrationBuilder.DropTable(
                name: "Request_LST");

            migrationBuilder.RenameColumn(
                name: "InternalID",
                table: "Position_TRN",
                newName: "InternalId");

            migrationBuilder.RenameColumn(
                name: "Department_InternalID",
                table: "Position_TRN",
                newName: "Department_InternalId");

            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "Position_TRN",
                newName: "RequestId");

            migrationBuilder.RenameColumn(
                name: "Manager_InternalID",
                table: "Department_TRN",
                newName: "Manager_InternalId");

            migrationBuilder.RenameColumn(
                name: "InternalID",
                table: "Department_TRN",
                newName: "InternalId");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manager_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.InternalID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department_InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.InternalID);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FunctionID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestID);
                });
        }
    }
}
