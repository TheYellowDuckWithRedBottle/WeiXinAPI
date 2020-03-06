using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeiXinAPI.Migrations
{
    public partial class initialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    ProvCapital = table.Column<string>(nullable: true),
                    TotalPopulation = table.Column<int>(nullable: false),
                    ConfirmedPopulation = table.Column<int>(nullable: false),
                    CurdPopulation = table.Column<int>(nullable: false),
                    DeadPopulation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProvinceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    TotalPopulation = table.Column<int>(nullable: false),
                    ConfirmedPopulation = table.Column<int>(nullable: false),
                    CurdPopulation = table.Column<int>(nullable: false),
                    DeadPopulation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cities_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    TotalPopulation = table.Column<int>(nullable: false),
                    ConfirmedPopulation = table.Column<int>(nullable: false),
                    CurdPopulation = table.Column<int>(nullable: false),
                    DeadPopulation = table.Column<int>(nullable: false),
                    CityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"), 632, 365, 0, "江苏省", "南京市", 10000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("db0185a5-48af-415f-b73f-46abc3fdc6af"), 536, 265, 2, "上海市", "上海市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("db0185a5-48af-415f-b73f-46abc3fdc6ae"), 536, 265, 2, "黑龙江", "哈尔滨", 20000000 });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvinceId", "TotalPopulation" },
                values: new object[] { new Guid("52e9ee88-dae3-4977-b491-c2ee88044e56"), 83, 25, 0, "南京市", new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"), 10000 });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvinceId", "TotalPopulation" },
                values: new object[] { new Guid("52e9ee88-dae3-4977-b491-c2ee88144e56"), 73, 26, 0, "苏州市", new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"), 20000 });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvinceId", "TotalPopulation" },
                values: new object[] { new Guid("52e9ee88-dae3-4977-b491-c2ee78144e56"), 53, 46, 0, "苏州市", new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"), 30000 });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_ProvinceId",
                table: "cities",
                column: "ProvinceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
