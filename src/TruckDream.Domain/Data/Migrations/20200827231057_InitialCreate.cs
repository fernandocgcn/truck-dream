using Microsoft.EntityFrameworkCore.Migrations;

namespace TruckDream.Domain.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_model",
                columns: table => new
                {
                    model_id = table.Column<int>(nullable: false),
                    acronym = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_model", x => x.model_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_truck",
                columns: table => new
                {
                    truck_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    production_year = table.Column<int>(nullable: false),
                    model_year = table.Column<int>(nullable: false),
                    color = table.Column<string>(nullable: true),
                    horsepower = table.Column<int>(nullable: true),
                    mileage = table.Column<double>(nullable: true),
                    model_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_truck", x => x.truck_id);
                    table.ForeignKey(
                        name: "FK_tb_truck_tb_model_model_id",
                        column: x => x.model_id,
                        principalTable: "tb_model",
                        principalColumn: "model_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 1, "XH", "Extra Heavy / Extra Pesado" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 2, "N10", "Nose 10L / Bicudo 10L" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 3, "NL", "Nose Larger / Bicudo Cabine Mais Larga" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 4, "FH", "Frontal High / Frente Reta Cabine Alta" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 5, "FH16", "Frontal High 16L / Frente Reta Cabine Alta 16L" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 6, "VNL", "Volvo Nose Larger / Volvo Bicudo Cabine Mais Larga" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 7, "FL", "Frontal Lower / Frente Reta Cabine Mais Baixa" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 8, "FM", "Frontal Medium / Frente Reta Cabine M�dia" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 9, "FMX", "Frontal Medium Extreme / Frente Reta Cabine M�dia Fora da Estrada" });

            migrationBuilder.InsertData(
                table: "tb_model",
                columns: new[] { "model_id", "acronym", "name" },
                values: new object[] { 10, "VM", "Volvo Medium 32T / Volvo M�dio 32T" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_truck_model_id",
                table: "tb_truck",
                column: "model_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_truck");

            migrationBuilder.DropTable(
                name: "tb_model");
        }
    }
}
