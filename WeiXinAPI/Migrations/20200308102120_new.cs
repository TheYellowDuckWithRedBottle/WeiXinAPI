using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeiXinAPI.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_cities_Province_ProvinceId",
            //    table: "cities");

            migrationBuilder.UpdateData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("db0185a5-48af-415f-b73f-46abc3fdc6ae"),
                column: "Name",
                value: "黑龙江省");

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("db0185a5-41af-415f-b73f-46abc3fdc6af"), 536, 265, 2, "北京市", "北京市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("db0185a5-424f-415f-b73f-46abc3fdc6af"), 536, 265, 2, "辽宁市", "沈阳", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("d14b43dc-60b0-454f-a2f1-13e3575cc130"), 536, 265, 2, "吉林省", "长春市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("b452ed51-935e-4558-9780-e5c70b305f5b"), 536, 265, 2, "江西省", "南昌市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("306d2712-d177-4fd7-9144-567e45790bbb"), 536, 265, 2, "湖北省", "武汉市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("9775cb29-a41c-4352-9abc-700c8029b892"), 536, 265, 2, "湖南省", "长沙市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("480e74a5-e6a0-46c8-91cf-169983d792f8"), 536, 265, 2, "内蒙古自治区", "呼和浩特", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("86ef5962-1dbf-4532-8521-90744f358736"), 536, 265, 2, "浙江省", "杭州市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("53764d2a-88a5-466f-9da0-3e06de021c92"), 536, 265, 2, "福建省", "福州市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("5e564e63-53c6-49db-906f-b5b9b80513a3"), 536, 265, 2, "河北省", "石家庄市", 20000000 });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "ConfirmedPopulation", "CurdPopulation", "DeadPopulation", "Name", "ProvCapital", "TotalPopulation" },
                values: new object[] { new Guid("32f83f2b-8e43-447d-842f-eda95a158ea1"), 536, 265, 2, "云南省", "昆明市", 20000000 });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_cities_Province_ProvinceId",
            //    table: "cities",
            //    column: "ProvinceId",
            //    principalTable: "Province",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_Province_ProvinceId",
                table: "cities");

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("306d2712-d177-4fd7-9144-567e45790bbb"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("32f83f2b-8e43-447d-842f-eda95a158ea1"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("480e74a5-e6a0-46c8-91cf-169983d792f8"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("53764d2a-88a5-466f-9da0-3e06de021c92"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("5e564e63-53c6-49db-906f-b5b9b80513a3"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("86ef5962-1dbf-4532-8521-90744f358736"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("9775cb29-a41c-4352-9abc-700c8029b892"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("b452ed51-935e-4558-9780-e5c70b305f5b"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("d14b43dc-60b0-454f-a2f1-13e3575cc130"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("db0185a5-41af-415f-b73f-46abc3fdc6af"));

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("db0185a5-424f-415f-b73f-46abc3fdc6af"));

            migrationBuilder.UpdateData(
                table: "Province",
                keyColumn: "Id",
                keyValue: new Guid("db0185a5-48af-415f-b73f-46abc3fdc6ae"),
                column: "Name",
                value: "黑龙江");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_Province_ProvinceId",
                table: "cities",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
