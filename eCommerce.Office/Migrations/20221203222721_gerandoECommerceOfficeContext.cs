using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Office.Migrations
{
    /// <inheritdoc />
    public partial class gerandoECommerceOfficeContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradoresSetores_Setor_SetorId",
                table: "ColaboradoresSetores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Setor",
                table: "Setor");

            migrationBuilder.RenameTable(
                name: "Setor",
                newName: "Setores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Setores",
                table: "Setores",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 1, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 22, 27, 20, 968, DateTimeKind.Unspecified).AddTicks(4777), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 6, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 22, 27, 20, 968, DateTimeKind.Unspecified).AddTicks(4782), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 4, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 22, 27, 20, 968, DateTimeKind.Unspecified).AddTicks(4784), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 5, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 22, 27, 20, 968, DateTimeKind.Unspecified).AddTicks(4783), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 7, 3 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 22, 27, 20, 968, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 2, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 22, 27, 20, 968, DateTimeKind.Unspecified).AddTicks(4786), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 3, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 22, 27, 20, 968, DateTimeKind.Unspecified).AddTicks(4787), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradoresSetores_Setores_SetorId",
                table: "ColaboradoresSetores",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradoresSetores_Setores_SetorId",
                table: "ColaboradoresSetores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Setores",
                table: "Setores");

            migrationBuilder.RenameTable(
                name: "Setores",
                newName: "Setor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Setor",
                table: "Setor",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 1, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 1, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(6828), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 6, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 1, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(6830), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 4, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 1, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(6831), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 5, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 1, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(6831), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 7, 3 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 1, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 2, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 1, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 3, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 12, 3, 1, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradoresSetores_Setor_SetorId",
                table: "ColaboradoresSetores",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
