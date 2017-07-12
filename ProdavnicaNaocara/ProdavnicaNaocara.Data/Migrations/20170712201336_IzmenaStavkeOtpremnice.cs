using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdavnicaNaocara.Data.Migrations
{
    public partial class IzmenaStavkeOtpremnice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StavkeOtpremnice_ProizvodId",
                table: "StavkeOtpremnice",
                column: "ProizvodId");

            migrationBuilder.AddForeignKey(
                name: "FK_StavkeOtpremnice_Proizvodi_ProizvodId",
                table: "StavkeOtpremnice",
                column: "ProizvodId",
                principalTable: "Proizvodi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkeOtpremnice_Proizvodi_ProizvodId",
                table: "StavkeOtpremnice");

            migrationBuilder.DropIndex(
                name: "IX_StavkeOtpremnice_ProizvodId",
                table: "StavkeOtpremnice");
        }
    }
}
