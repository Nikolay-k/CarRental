using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CarRental.Context.Migrations
{
    using Builders;

    [DbContext(typeof(AppDbContext))]
    [Migration("20201108124330_Init")]
    public class Init : Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            UserModelBuilder.BuildModel(modelBuilder);
            CarModelBuilder.BuildModel(modelBuilder);
            OrderModelBuilder.BuildModel(modelBuilder);
#pragma warning restore 612, 618
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    DrivingLicenseNumber = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(maxLength: 20, nullable: false),
                    Model = table.Column<string>(maxLength: 20, nullable: false),
                    Class = table.Column<string>(maxLength: 10, nullable: false),
                    IssueYear = table.Column<short>(nullable: false),
                    RegistrationNumber = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    RentalStartDate = table.Column<DateTime>(nullable: false),
                    RentalEndDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
