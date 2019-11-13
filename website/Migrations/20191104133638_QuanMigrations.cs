using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace website.Migrations
{
    public partial class QuanMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Fee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                    PayPercent = table.Column<double>(nullable: false),
                    PayLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Session = table.Column<string>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Faculty_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Faculties_Faculty_Id",
                        column: x => x.Faculty_Id,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsuranceType_Id = table.Column<int>(nullable: false),
                    NameFirst = table.Column<string>(maxLength: 100, nullable: false),
                    NameMiddle = table.Column<string>(maxLength: 100, nullable: true),
                    NameLast = table.Column<string>(maxLength: 100, nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    AddressApartment = table.Column<string>(nullable: false),
                    AddressStreet = table.Column<string>(nullable: false),
                    AddressDistrict = table.Column<string>(nullable: false),
                    AddressCity = table.Column<string>(nullable: false),
                    DateRegistration = table.Column<DateTime>(nullable: false),
                    DateExpire = table.Column<DateTime>(nullable: false),
                    DateLastUsed = table.Column<DateTime>(nullable: false),
                    PhoneNumberPersonal = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumberHome = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurances_InsuranceTypes_InsuranceType_Id",
                        column: x => x.InsuranceType_Id,
                        principalTable: "InsuranceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role_Id = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateModify = table.Column<DateTime>(nullable: false),
                    DateLastUsed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role_Id = table.Column<int>(nullable: false),
                    Faculty_Id = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    NameFirst = table.Column<string>(maxLength: 100, nullable: false),
                    NameMiddle = table.Column<string>(maxLength: 100, nullable: true),
                    NameLast = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Faculties_Faculty_Id",
                        column: x => x.Faculty_Id,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Doctors_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pharamacists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role_Id = table.Column<int>(nullable: false),
                    NameFirst = table.Column<string>(maxLength: 100, nullable: false),
                    NameMiddle = table.Column<string>(maxLength: 100, nullable: true),
                    NameLast = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateModify = table.Column<DateTime>(nullable: false),
                    DateLastUsed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharamacists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharamacists_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Insurance_Id = table.Column<int>(nullable: false),
                    Role_Id = table.Column<int>(nullable: false),
                    NameFirst = table.Column<string>(maxLength: 100, nullable: false),
                    NameMiddle = table.Column<string>(maxLength: 100, nullable: true),
                    NameLast = table.Column<string>(maxLength: 100, nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    AddressApartment = table.Column<string>(nullable: false),
                    AddressStreet = table.Column<string>(nullable: false),
                    AddressDistrict = table.Column<string>(nullable: false),
                    AddressCity = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Weight = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Blood_Type = table.Column<string>(nullable: true),
                    Rh = table.Column<string>(nullable: true),
                    BMP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Insurances_Insurance_Id",
                        column: x => x.Insurance_Id,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Patients_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Admin_Id = table.Column<int>(nullable: false),
                    MedicineUnit_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Instore = table.Column<int>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateModify = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Admins_Admin_Id",
                        column: x => x.Admin_Id,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineUnits_MedicineUnit_Id",
                        column: x => x.MedicineUnit_Id,
                        principalTable: "MedicineUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ShiftPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Room_Id = table.Column<int>(nullable: false),
                    Doctor_Id = table.Column<int>(nullable: false),
                    Shift_Id = table.Column<int>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftPlans_Doctors_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShiftPlans_Rooms_Room_Id",
                        column: x => x.Room_Id,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShiftPlans_Shifts_Shift_Id",
                        column: x => x.Shift_Id,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Perscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Faculty_Id = table.Column<int>(nullable: false),
                    Doctor_Id = table.Column<int>(nullable: false),
                    Patient_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateModify = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perscriptions_Doctors_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Perscriptions_Faculties_Faculty_Id",
                        column: x => x.Faculty_Id,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Perscriptions_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WaitingLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Patient_Id = table.Column<int>(nullable: false),
                    Room_Id = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingLines_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WaitingLines_Rooms_Room_Id",
                        column: x => x.Room_Id,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Perscription_Id = table.Column<int>(nullable: false),
                    Pharamacist_Id = table.Column<int>(nullable: false),
                    Insurance_Id = table.Column<int>(nullable: false),
                    PayTotal = table.Column<int>(nullable: false),
                    PayInsurance = table.Column<int>(nullable: false),
                    PayPatient = table.Column<int>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Insurances_Insurance_Id",
                        column: x => x.Insurance_Id,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bills_Perscriptions_Perscription_Id",
                        column: x => x.Perscription_Id,
                        principalTable: "Perscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bills_Pharamacists_Pharamacist_Id",
                        column: x => x.Pharamacist_Id,
                        principalTable: "Pharamacists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PerscriptionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Perscription_Id = table.Column<int>(nullable: false),
                    Medicine_Id = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Morning = table.Column<int>(nullable: false),
                    Noon = table.Column<int>(nullable: false),
                    Evening = table.Column<int>(nullable: false),
                    Days = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerscriptionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerscriptionDetails_Medicines_Medicine_Id",
                        column: x => x.Medicine_Id,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PerscriptionDetails_Perscriptions_Perscription_Id",
                        column: x => x.Perscription_Id,
                        principalTable: "Perscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Role_Id",
                table: "Admins",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Username",
                table: "Admins",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Insurance_Id",
                table: "Bills",
                column: "Insurance_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Perscription_Id",
                table: "Bills",
                column: "Perscription_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Pharamacist_Id",
                table: "Bills",
                column: "Pharamacist_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Faculty_Id",
                table: "Doctors",
                column: "Faculty_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PhoneNumber",
                table: "Doctors",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Role_Id",
                table: "Doctors",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Username",
                table: "Doctors",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Name",
                table: "Faculties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_InsuranceType_Id",
                table: "Insurances",
                column: "InsuranceType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTypes_Type",
                table: "InsuranceTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_Admin_Id",
                table: "Medicines",
                column: "Admin_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineUnit_Id",
                table: "Medicines",
                column: "MedicineUnit_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_Name",
                table: "Medicines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicineUnits_Unit",
                table: "MedicineUnits",
                column: "Unit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Insurance_Id",
                table: "Patients",
                column: "Insurance_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Role_Id",
                table: "Patients",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PerscriptionDetails_Medicine_Id",
                table: "PerscriptionDetails",
                column: "Medicine_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PerscriptionDetails_Perscription_Id",
                table: "PerscriptionDetails",
                column: "Perscription_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_Doctor_Id",
                table: "Perscriptions",
                column: "Doctor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_Faculty_Id",
                table: "Perscriptions",
                column: "Faculty_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_Patient_Id",
                table: "Perscriptions",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pharamacists_Email",
                table: "Pharamacists",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pharamacists_PhoneNumber",
                table: "Pharamacists",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pharamacists_Role_Id",
                table: "Pharamacists",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pharamacists_Username",
                table: "Pharamacists",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Faculty_Id",
                table: "Rooms",
                column: "Faculty_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Name",
                table: "Rooms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPlans_Doctor_Id",
                table: "ShiftPlans",
                column: "Doctor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPlans_Room_Id",
                table: "ShiftPlans",
                column: "Room_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPlans_Shift_Id",
                table: "ShiftPlans",
                column: "Shift_Id");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLines_Patient_Id",
                table: "WaitingLines",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingLines_Room_Id",
                table: "WaitingLines",
                column: "Room_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "PerscriptionDetails");

            migrationBuilder.DropTable(
                name: "ShiftPlans");

            migrationBuilder.DropTable(
                name: "WaitingLines");

            migrationBuilder.DropTable(
                name: "Pharamacists");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Perscriptions");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "MedicineUnits");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "InsuranceTypes");
        }
    }
}
