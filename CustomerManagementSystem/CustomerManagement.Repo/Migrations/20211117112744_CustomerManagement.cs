using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagement.Repo.Migrations
{
    public partial class CustomerManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    LastName = table.Column<string>(maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    Email = table.Column<string>(maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    MobileNumber = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "('')"),
                    Password = table.Column<string>(maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    PasswordKey = table.Column<string>(maxLength: 225, nullable: false, defaultValueSql: "('')"),
                    Address = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    Active = table.Column<bool>(nullable: false),
                    UserCreated = table.Column<int>(nullable: false),
                    UserModified = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    Totalorders = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomer");
        }
    }
}
