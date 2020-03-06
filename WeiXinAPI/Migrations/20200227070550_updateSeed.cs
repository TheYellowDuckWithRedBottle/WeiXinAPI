using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeiXinAPI.Migrations
{
    public partial class updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: new Guid("52e9ee88-dae3-4977-b491-c2ee78144e56"));

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: new Guid("52e9ee88-dae3-4977-b491-c2ee88044e56"));

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: new Guid("52e9ee88-dae3-4977-b491-c2ee88144e56"));

            migrationBuilder.UpdateData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("db0185a5-48af-415f-b73f-46abc3fdc6ae"),
                column: "ProvCapital",
                value: "哈尔滨市");

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvinceId", "TotalPopulation" },
                values: new object[] { new Guid("52e9ee28-dae3-4977-b491-c1ee88014e56"), 513, 16, 0, "哈尔滨市", new Guid("db0185a5-48af-415f-b73f-46abc3fdc6ae"), 10000 });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvinceId", "TotalPopulation" },
                values: new object[] { new Guid("52e9ee88-dae3-4977-b491-c2ee88054e56"), 513, 16, 0, "上海市", new Guid("db0185a5-48af-415f-b73f-46abc3fdc6af"), 10000 });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvinceId", "TotalPopulation" },
                values: new object[] { new Guid("52e9ee88-dae3-5977-b491-c2ee88044e56"), 83, 25, 0, "南京市", new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"), 10000 });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvinceId", "TotalPopulation" },
                values: new object[] { new Guid("52e9ee88-dae3-4917-b491-c2ee88144e56"), 73, 26, 0, "苏州市", new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"), 20000 });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvinceId", "TotalPopulation" },
                values: new object[] { new Guid("52e9ea88-dae3-4977-b491-c2ee78144e56"), 53, 46, 0, "镇江市", new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"), 30000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: new Guid("52e9ea88-dae3-4977-b491-c2ee78144e56"));

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: new Guid("52e9ee28-dae3-4977-b491-c1ee88014e56"));

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: new Guid("52e9ee88-dae3-4917-b491-c2ee88144e56"));

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: new Guid("52e9ee88-dae3-4977-b491-c2ee88054e56"));

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: new Guid("52e9ee88-dae3-5977-b491-c2ee88044e56"));

            migrationBuilder.UpdateData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("db0185a5-48af-415f-b73f-46abc3fdc6ae"),
                column: "ProvCapital",
                value: "哈尔滨");

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
        }
    }
}
