using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreshLifie.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Type",
                columns: table => new
                {
                    Product_TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Type", x => x.Product_TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    UserPhone = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    UserAddress = table.Column<string>(nullable: false),
                    UserLength = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    UserWeight = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    UserPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProviderName = table.Column<string>(nullable: false),
                    ProviderURL = table.Column<string>(nullable: false),
                    ProductTypeID = table.Column<int>(nullable: false),
                    _Product_TypeProduct_TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderID);
                    table.ForeignKey(
                        name: "FK_Providers_Product_Type__Product_TypeProduct_TypeId",
                        column: x => x._Product_TypeProduct_TypeId,
                        principalTable: "Product_Type",
                        principalColumn: "Product_TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order_price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Provider",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProviderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Provider", x => new { x.UserId, x.ProviderID });
                    table.ForeignKey(
                        name: "FK_User_Provider_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Provider_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Item",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Item", x => new { x.ItemId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Order_Item_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Item_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provider_Order",
                columns: table => new
                {
                    ProviderID = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider_Order", x => new { x.ProviderID, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Provider_Order_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provider_Order_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Item_OrderId",
                table: "Order_Item",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_Order_OrderId",
                table: "Provider_Order",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers__Product_TypeProduct_TypeId",
                table: "Providers",
                column: "_Product_TypeProduct_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Provider_ProviderID",
                table: "User_Provider",
                column: "ProviderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Item");

            migrationBuilder.DropTable(
                name: "Provider_Order");

            migrationBuilder.DropTable(
                name: "User_Provider");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Product_Type");
        }
    }
}
