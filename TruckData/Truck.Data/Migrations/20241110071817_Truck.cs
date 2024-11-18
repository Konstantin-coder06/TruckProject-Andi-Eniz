using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Truck.Data.Migrations
{
    public partial class Truck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompaniesStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainAdress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfStock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    FromAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrucksCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckCompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckCompanyPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainTruckAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckCompanyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrucksCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesStocks_Shipments",
                columns: table => new
                {
                    CompanyStock_Id = table.Column<int>(type: "int", nullable: false),
                    Shipment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesStocks_Shipments", x => new { x.Shipment_Id, x.CompanyStock_Id });
                    table.ForeignKey(
                        name: "FK_CompaniesStocks_Shipments_CompaniesStocks_CompanyStock_Id",
                        column: x => x.CompanyStock_Id,
                        principalTable: "CompaniesStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompaniesStocks_Shipments_Shipments_Shipment_Id",
                        column: x => x.Shipment_Id,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_TrucksCompanies_TruckCompanyId",
                        column: x => x.TruckCompanyId,
                        principalTable: "TrucksCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TruckCompanies_Shipments",
                columns: table => new
                {
                    TruckCompany_Id = table.Column<int>(type: "int", nullable: false),
                    Shipment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckCompanies_Shipments", x => new { x.Shipment_Id, x.TruckCompany_Id });
                    table.ForeignKey(
                        name: "FK_TruckCompanies_Shipments_Shipments_Shipment_Id",
                        column: x => x.Shipment_Id,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TruckCompanies_Shipments_TrucksCompanies_TruckCompany_Id",
                        column: x => x.TruckCompany_Id,
                        principalTable: "TrucksCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    LiscenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_TrucksCompanies_TruckCompanyId",
                        column: x => x.TruckCompanyId,
                        principalTable: "TrucksCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesStocks_Shipments_CompanyStock_Id",
                table: "CompaniesStocks_Shipments",
                column: "CompanyStock_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TruckCompanyId",
                table: "Drivers",
                column: "TruckCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckCompanies_Shipments_TruckCompany_Id",
                table: "TruckCompanies_Shipments",
                column: "TruckCompany_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TruckCompanyId",
                table: "Vehicles",
                column: "TruckCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesStocks_Shipments");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "TruckCompanies_Shipments");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "CompaniesStocks");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "TrucksCompanies");
        }
    }
}
