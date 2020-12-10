using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ocean.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hostility",
                columns: table => new
                {
                    HostilityId = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    QQNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    HostilityName = table.Column<string>(type: "varchar(50)", nullable: false),
                    RoleLevel = table.Column<int>(type: "int", nullable: false),
                    MilitaryPower = table.Column<int>(type: "int", nullable: false),
                    HostilityLevel = table.Column<string>(nullable: true),
                    IsSurpass = table.Column<bool>(type: "bit", nullable: false),
                    Remark = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostility", x => x.HostilityId);
                });

            migrationBuilder.CreateTable(
                name: "StoredEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "DateTime", nullable: false),
                    MessageType = table.Column<string>(type: "varchar(100)", nullable: true),
                    AggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<string>(type: "varchar(Max)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    CreateBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    RoleName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nick = table.Column<string>(type: "varchar(50)", nullable: false),
                    AccountName = table.Column<string>(type: "varchar(100)", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: false),
                    QQNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    Tel = table.Column<string>(type: "varchar(20)", nullable: true),
                    EmadilAddress = table.Column<string>(type: "varchar(100)", nullable: true),
                    AddressProvince = table.Column<string>(type: "varchar(50)", nullable: true),
                    AddressCity = table.Column<string>(type: "varchar(50)", nullable: true),
                    AddressLocation = table.Column<string>(type: "varchar(50)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskSchedule",
                columns: table => new
                {
                    TaskId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    TaskGroup = table.Column<string>(nullable: true),
                    TaskName = table.Column<string>(nullable: true),
                    TaskCron = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSchedule", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "SystemUserRoleRelation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserRoleRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserRoleRelation_SystemRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SystemRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemUserRoleRelation_SystemUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRoleRelation_RoleId",
                table: "SystemUserRoleRelation",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRoleRelation_UserId",
                table: "SystemUserRoleRelation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hostility");

            migrationBuilder.DropTable(
                name: "StoredEvent");

            migrationBuilder.DropTable(
                name: "SystemUserRoleRelation");

            migrationBuilder.DropTable(
                name: "TaskSchedule");

            migrationBuilder.DropTable(
                name: "SystemRole");

            migrationBuilder.DropTable(
                name: "SystemUser");
        }
    }
}
