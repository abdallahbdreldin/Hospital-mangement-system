//UPDATE-DAusing Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace Hospital.DAL.Migrations
//{
//    /// <inheritdoc />
//    public partial class addDises : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_patients_AspNetUsers_UserId",
//                table: "patients");

//            migrationBuilder.DropIndex(
//                name: "IX_patients_UserId",
//                table: "patients");

//            migrationBuilder.DropColumn(
//                name: "UserId",
//                table: "patients");

//            migrationBuilder.AddColumn<string>(
//                name: "UserId",
//                table: "Disease",
//                type: "nvarchar(450)",
//                nullable: false,
//                defaultValue: "");

//            migrationBuilder.CreateIndex(
//                name: "IX_Disease_UserId",
//                table: "Disease",
//                column: "UserId",
//                unique: true);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Disease_AspNetUsers_UserId",
//                table: "Disease",
//                column: "UserId",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Disease_AspNetUsers_UserId",
//                table: "Disease");

//            migrationBuilder.DropIndex(
//                name: "IX_Disease_UserId",
//                table: "Disease");

//            migrationBuilder.DropColumn(
//                name: "UserId",
//                table: "Disease");

//            migrationBuilder.AddColumn<string>(
//                name: "UserId",
//                table: "patients",
//                type: "nvarchar(450)",
//                nullable: false,
//                defaultValue: "");

//            migrationBuilder.CreateIndex(
//                name: "IX_patients_UserId",
//                table: "patients",
//                column: "UserId",
//                unique: true);

//            migrationBuilder.AddForeignKey(
//                name: "FK_patients_AspNetUsers_UserId",
//                table: "patients",
//                column: "UserId",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }
//    }
//}
