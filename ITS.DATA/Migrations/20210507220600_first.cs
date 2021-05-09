using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITS.DATA.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(nullable: true),
                    AdminParola = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grup",
                columns: table => new
                {
                    GrupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grup", x => x.GrupId);
                });

            migrationBuilder.CreateTable(
                name: "Isveren",
                columns: table => new
                {
                    IsverenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsverenAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsverenSoyadi = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isveren", x => x.IsverenId);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRefreshToken",
                columns: table => new
                {
                    CavusId = table.Column<string>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: false),
                    RefreshTokenOmru = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRefreshToken", x => x.CavusId);
                });

            migrationBuilder.CreateTable(
                name: "Ucret",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsUcreti = table.Column<decimal>(type: "decimal(5,3)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucret", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aile",
                columns: table => new
                {
                    AileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AileAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    GrupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aile", x => x.AileId);
                    table.ForeignKey(
                        name: "FK_Aile_Grup1",
                        column: x => x.GrupId,
                        principalTable: "Grup",
                        principalColumn: "GrupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    GrupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Grup_GrupId",
                        column: x => x.GrupId,
                        principalTable: "Grup",
                        principalColumn: "GrupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Is",
                columns: table => new
                {
                    IsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsverenId = table.Column<int>(nullable: false),
                    GrupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Is", x => x.IsId);
                    table.ForeignKey(
                        name: "FK_Work_Grup",
                        column: x => x.GrupId,
                        principalTable: "Grup",
                        principalColumn: "GrupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Is_Isveren",
                        column: x => x.IsverenId,
                        principalTable: "Isveren",
                        principalColumn: "IsverenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Isci",
                columns: table => new
                {
                    IsciId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsciAdi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsciSoyadi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AileId = table.Column<int>(nullable: false),
                    GrupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isci_1", x => x.IsciId);
                    table.ForeignKey(
                        name: "FK_Isci_Aile",
                        column: x => x.AileId,
                        principalTable: "Aile",
                        principalColumn: "AileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Isci_Grup",
                        column: x => x.GrupId,
                        principalTable: "Grup",
                        principalColumn: "GrupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gider",
                columns: table => new
                {
                    GiderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiderTutar = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    GiderAciklama = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    GiderTarih = table.Column<DateTime>(type: "datetime", nullable: false),
                    GiderKisi = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsciId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gider", x => x.GiderId);
                    table.ForeignKey(
                        name: "FK_Gider_Isci",
                        column: x => x.IsciId,
                        principalTable: "Isci",
                        principalColumn: "IsciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IsIsci",
                columns: table => new
                {
                    IsciId = table.Column<int>(nullable: false),
                    IsId = table.Column<int>(nullable: false),
                    Durumu = table.Column<bool>(nullable: true),
                    Yövmiye = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsIsci", x => new { x.IsciId, x.IsId });
                    table.ForeignKey(
                        name: "FK_Is_Isci_Is",
                        column: x => x.IsId,
                        principalTable: "Is",
                        principalColumn: "IsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Is_Isci_Isci",
                        column: x => x.IsciId,
                        principalTable: "Isci",
                        principalColumn: "IsciId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aile_GrupId",
                table: "Aile",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GrupId",
                table: "AspNetUsers",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gider_IsciId",
                table: "Gider",
                column: "IsciId");

            migrationBuilder.CreateIndex(
                name: "IX_Is_GrupId",
                table: "Is",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_Is_IsverenId",
                table: "Is",
                column: "IsverenId");

            migrationBuilder.CreateIndex(
                name: "IX_Isci_AileId",
                table: "Isci",
                column: "AileId");

            migrationBuilder.CreateIndex(
                name: "IX_Isci",
                table: "Isci",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_IsIsci_IsId",
                table: "IsIsci",
                column: "IsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Gider");

            migrationBuilder.DropTable(
                name: "IsIsci");

            migrationBuilder.DropTable(
                name: "KullaniciRefreshToken");

            migrationBuilder.DropTable(
                name: "Ucret");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Is");

            migrationBuilder.DropTable(
                name: "Isci");

            migrationBuilder.DropTable(
                name: "Isveren");

            migrationBuilder.DropTable(
                name: "Aile");

            migrationBuilder.DropTable(
                name: "Grup");
        }
    }
}
