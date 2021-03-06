﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 25, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Street = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AvailableQuantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatus = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "Email", "FirstName", "LastName", "Phone", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Toruń", "bedpaw111@jakisemail.com", "Pawel", "Bednarczyk", "888777666", "Kolejowa 5/7", "87118" },
                    { 2, "Warszawa", "patiiiii93@jakisemail.com", "Patrycja", "Peczyńska", "333444555", "Konstruktorska 3/4", "02254" },
                    { 3, "Warszawa", "alex@jakisemail.com", "Ola", "Kołacz", "555666777", "Mickiewicza 11/7", "02111" },
                    { 4, "Sandomierz", "wojciechjsky@jakisemail.com", "Wojtek", "Jabłoński", "666777888", "Cybernetyki 6", "27600" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableQuantity", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 50m, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/b9c923fc-b1ea-4ea5-a7fe-8bf4a4d161fc/dbp6tcm-5eaa1d87-5b5d-4eb3-8274-abc0fce4766b.png/v1/fill/w_1024,h_1024,q_80,strp/angry_banana_by_ragenanners258_dbp6tcm-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOiIsImlzcyI6InVybjphcHA6Iiwib2JqIjpbW3siaGVpZ2h0IjoiPD0xMDI0IiwicGF0aCI6IlwvZlwvYjljOTIzZmMtYjFlYS00ZWE1LWE3ZmUtOGJmNGE0ZDE2MWZjXC9kYnA2dGNtLTVlYWExZDg3LTViNWQtNGViMy04Mjc0LWFiYzBmY2U0NzY2Yi5wbmciLCJ3aWR0aCI6Ijw9MTAyNCJ9XV0sImF1ZCI6WyJ1cm46c2VydmljZTppbWFnZS5vcGVyYXRpb25zIl19.ymP9H5-qT7QEIMXnK69ONyAqFbSzLcEdJbf9dMBefhc", "Banana", 0.5m },
                    { 2, 700m, "https://cdn.pixabay.com/photo/2017/10/14/15/51/strawberry-2850845_960_720.png", "Strawberry", 0.9m },
                    { 3, 1000m, "https://cdn.pixabay.com/photo/2017/10/14/15/51/raspberry-2850842_960_720.png", "Raspberry", 0.2m },
                    { 4, 150m, "https://cdn.pixabay.com/photo/2013/07/12/19/34/kiwi-155022_960_720.png", "Kiwi", 1.5m },
                    { 5, 1550m, "https://cdn.pixabay.com/photo/2016/06/23/18/55/apple-1475977_960_720.png", "Apple", 0.6m },
                    { 6, 400m, "https://cdn.pixabay.com/photo/2020/06/23/06/45/apricot-5331575_960_720.png", "Apricot", 0.4m },
                    { 7, 500m, "https://cdn.pixabay.com/photo/2018/02/24/10/03/orange-3177693_960_720.png", "Orange", 1.5m },
                    { 8, 2m, "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.0-9/59922551_304682407111959_1556794403484336128_n.jpg?_nc_cat=106&_nc_sid=09cbfe&_nc_ohc=wSdiX14mNWUAX8IAqOb&_nc_ht=scontent.fzgh1-1.fna&oh=fe1cc92b02e7102c00a71500eddbd36a&oe=5F369CE8", "Avocado", 50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
