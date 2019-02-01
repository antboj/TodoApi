using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { 1, "Social Worker" },
                    { 18, "Biostatistician I" },
                    { 17, "Legal Assistant" },
                    { 16, "Senior Sales Associate" },
                    { 15, "Mechanical Systems Engineer" },
                    { 14, "Junior Executive" },
                    { 13, "Nuclear Power Engineer" },
                    { 12, "Developer III" },
                    { 11, "Account Executive" },
                    { 10, "Web Developer IV" },
                    { 9, "Recruiting Manager" },
                    { 8, "Biostatistician I" },
                    { 7, "Account Executive" },
                    { 6, "Information Systems Manager" },
                    { 5, "Mechanical Systems Engineer" },
                    { 4, "Junior Executive" },
                    { 3, "Statistician I" },
                    { 2, "Programmer II" },
                    { 19, "Biostatistician IV" },
                    { 20, "Associate Professor" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "BirthPlace", "Email", "JobId", "Name" },
                values: new object[,]
                {
                    { 37, new DateTime(1998, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria", "ut.dolor@Nullaeuneque.com", 1, "Scott Hall" },
                    { 63, new DateTime(1951, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovakia", "in.consequat@Mauris.net", 16, "Urielle Puckett" },
                    { 38, new DateTime(1992, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkey", "non.justo@blanditviverraDonec.ca", 16, "Omar Finch" },
                    { 17, new DateTime(2015, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Marino", "ante.bibendum@in.com", 16, "Ebony Dickerson" },
                    { 89, new DateTime(1956, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sierra Leone", "Mauris.non@consequatpurus.net", 15, "Lyle Wise" },
                    { 50, new DateTime(2001, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibraltar", "non.lobortis.quis@hendrerit.com", 15, "Evangeline Wallace" },
                    { 47, new DateTime(1990, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mali", "id.risus.quis@arcu.ca", 15, "Violet Harding" },
                    { 40, new DateTime(1972, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecuador", "egestas.ligula@sedest.edu", 15, "Casey Peters" },
                    { 31, new DateTime(1987, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suriname", "at.arcu@nullaIntegerurna.ca", 15, "Hasad Lamb" },
                    { 22, new DateTime(1979, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venezuela", "justo@dolorDonecfringilla.co.uk", 15, "Darryl Clarke" },
                    { 12, new DateTime(1992, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanzania", "ridiculus@ligulaeu.net", 15, "Destiny Humphrey" },
                    { 93, new DateTime(1978, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albania", "rutrum@arcuSedeu.ca", 14, "James Knapp" },
                    { 92, new DateTime(1954, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mali", "ipsum.dolor.sit@neceleifendnon.edu", 14, "Boris Hutchinson" },
                    { 81, new DateTime(1954, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambia", "tortor@fringillacursuspurus.com", 14, "Zeus Moore" },
                    { 46, new DateTime(1969, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guernsey", "vel.faucibus@non.net", 14, "Elmo Mccarthy" },
                    { 11, new DateTime(1980, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominica", "faucibus.leo.in@dapibusligula.org", 14, "Alan Mosley" },
                    { 9, new DateTime(1971, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain", "mauris.sit@turpisegestasAliquam.org", 14, "Lisandra Colon" },
                    { 1, new DateTime(1979, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Sudan", "posuere.enim@porttitor.edu", 14, "Kasimir Cannon" },
                    { 83, new DateTime(1975, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "�land Islands", "odio@necmollisvitae.com", 13, "Hashim Swanson" },
                    { 72, new DateTime(1952, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morocco", "pharetra.sed@metusAeneansed.co.uk", 13, "Ramona Lawrence" },
                    { 58, new DateTime(1981, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarus", "Vestibulum.ante@Proinvel.net", 13, "Yoshi Wilkins" },
                    { 52, new DateTime(1995, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latvia", "primis.in@eros.co.uk", 13, "Nicholas Harvey" },
                    { 68, new DateTime(2001, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberia", "vulputate@arcuSed.co.uk", 16, "Tiger Hunt" },
                    { 39, new DateTime(1998, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaica", "vestibulum.lorem.sit@Duissit.org", 13, "Caesar Bowman" },
                    { 77, new DateTime(1952, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithuania", "vulputate.velit@urnaNullam.org", 16, "Lance Holloway" },
                    { 57, new DateTime(1986, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland", "at.pretium.aliquet@ametnullaDonec.com", 17, "Clayton Morales" },
                    { 51, new DateTime(2002, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andorra", "non.enim.commodo@ac.ca", 20, "Justin Reid" },
                    { 23, new DateTime(1963, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islands", "porttitor.scelerisque@eu.org", 20, "Herrod Gonzalez" },
                    { 6, new DateTime(1985, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comoros", "nec.ligula@anteiaculis.edu", 20, "Carly Hicks" },
                    { 4, new DateTime(1975, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao", "euismod.mauris@Aliquamvulputateullamcorper.com", 20, "Regina Hess" },
                    { 91, new DateTime(1976, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican Republic", "vel.venenatis@disparturientmontes.org", 19, "Gloria York" },
                    { 80, new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuba", "natoque.penatibus.et@gravidanunc.org", 19, "Tanek Green" },
                    { 76, new DateTime(1960, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece", "ut@Nuncmaurissapien.com", 19, "Juliet Miles" },
                    { 53, new DateTime(1983, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "C�te D'Ivoire (Ivory Coast)", "semper.pretium.neque@nequeInornare.ca", 19, "Savannah Dotson" },
                    { 42, new DateTime(2008, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Southern Territories", "Sed@molestie.org", 19, "Erasmus Head" },
                    { 32, new DateTime(1982, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peru", "posuere.cubilia.Curae@mifelisadipiscing.net", 19, "Daryl Beasley" },
                    { 27, new DateTime(2006, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia", "mollis@ategestas.edu", 19, "Robert Fulton" },
                    { 25, new DateTime(1989, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway", "mi@elit.edu", 19, "Paula Morrison" },
                    { 18, new DateTime(1977, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistan", "at.nisi@nullaante.ca", 19, "Jayme Dalton" },
                    { 97, new DateTime(1998, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samoa", "elementum.sem.vitae@Pellentesquehabitantmorbi.co.uk", 18, "Keiko Hoover" },
                    { 67, new DateTime(1965, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas", "eget.venenatis.a@auctorvitaealiquet.ca", 18, "Olga Bryant" },
                    { 30, new DateTime(1967, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heard Island and Mcdonald Islands", "nonummy.ac@lobortisrisus.co.uk", 18, "Lacota Michael" },
                    { 21, new DateTime(1977, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiribati", "porttitor@ornarelectus.com", 18, "Hop Morrow" },
                    { 15, new DateTime(2000, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angola", "facilisi@eu.org", 18, "Tanya Berg" },
                    { 7, new DateTime(2001, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denmark", "amet.consectetuer.adipiscing@laoreet.net", 18, "Zeus Randolph" },
                    { 2, new DateTime(1975, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montserrat", "Vivamus.molestie@magna.co.uk", 18, "Candace Velasquez" },
                    { 86, new DateTime(1997, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentina", "Sed.id@interdumliberodui.net", 17, "Hillary Shepard" },
                    { 10, new DateTime(1966, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guam", "vehicula.Pellentesque@maurisutmi.com", 17, "Olympia Dunlap" },
                    { 88, new DateTime(1987, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtenstein", "nibh.Quisque.nonummy@FuscemollisDuis.edu", 12, "Melodie Blevins" },
                    { 85, new DateTime(1978, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocos (Keeling) Islands", "Nam.ac.nulla@disparturientmontes.edu", 12, "Pearl Hebert" },
                    { 75, new DateTime(2004, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiribati", "pellentesque.eget@auguemalesuada.net", 12, "Sarah Brown" },
                    { 45, new DateTime(2002, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Falkland Islands", "elit.Curabitur.sed@nonlacinia.edu", 7, "Tate Hutchinson" },
                    { 35, new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guyana", "mauris@quam.ca", 7, "Moses Henderson" },
                    { 16, new DateTime(1995, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chad", "quam.vel@arcu.co.uk", 7, "Yardley Weeks" },
                    { 49, new DateTime(2000, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouvet Island", "risus@ac.com", 6, "Luke Glover" },
                    { 28, new DateTime(1992, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peru", "magna@aneque.co.uk", 6, "Noel Estrada" },
                    { 14, new DateTime(1972, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palestine, State of", "feugiat.Sed.nec@semNullainterdum.ca", 6, "Maris Puckett" },
                    { 8, new DateTime(1992, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo, the Democratic Republic of the", "enim.nisl.elementum@Nullatemporaugue.com", 6, "Lamar Gomez" },
                    { 100, new DateTime(2006, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovakia", "semper.auctor@adipiscinglacus.org", 5, "Price Mcleod" },
                    { 74, new DateTime(2014, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambia", "accumsan@amifringilla.org", 5, "Yasir Norris" },
                    { 54, new DateTime(1987, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweden", "purus.in.molestie@Crasvulputatevelit.edu", 5, "Avye Howard" },
                    { 43, new DateTime(2003, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascar", "ultricies.ligula.Nullam@nisi.edu", 5, "Levi Sampson" },
                    { 71, new DateTime(1961, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberia", "nibh.Phasellus.nulla@placerataugue.org", 4, "Jenette Mcdowell" },
                    { 62, new DateTime(2002, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niue", "vel@amet.com", 4, "Tanisha Gallagher" },
                    { 60, new DateTime(2012, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong", "velit.Aliquam@feugiat.net", 4, "Sheila Owen" },
                    { 44, new DateTime(1991, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samoa", "eu.neque@semNulla.edu", 4, "Colt Leonard" },
                    { 13, new DateTime(1954, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwanda", "euismod@ornareFuscemollis.edu", 4, "Berk Harrell" },
                    { 65, new DateTime(2017, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faroe Islands", "posuere.vulputate@tempus.com", 2, "Honorato Torres" },
                    { 59, new DateTime(1963, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenia", "libero.dui@nisimagnased.co.uk", 2, "Suki Buck" },
                    { 29, new DateTime(1967, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria", "blandit.enim.consequat@acarcu.co.uk", 2, "Yeo Contreras" },
                    { 48, new DateTime(2009, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mali", "senectus.et.netus@quisdiam.co.uk", 1, "Lani Richmond" },
                    { 41, new DateTime(1997, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijan", "libero@afelisullamcorper.edu", 1, "Boris Sykes" },
                    { 56, new DateTime(1966, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanuatu", "quam.dignissim.pharetra@Duisami.net", 7, "Angela Wilder" },
                    { 19, new DateTime(1970, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore", "gravida@Duisa.ca", 8, "Teagan Barnett" },
                    { 34, new DateTime(2012, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cambodia", "non.lacinia@augueSedmolestie.com", 8, "Kennan Allison" },
                    { 64, new DateTime(1967, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portugal", "turpis.egestas@Donec.org", 8, "Nigel Peterson" },
                    { 70, new DateTime(1956, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chad", "vulputate.eu@Proin.net", 12, "Davis Rowe" },
                    { 33, new DateTime(1958, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecuador", "mi@sollicitudincommodoipsum.net", 12, "Kylee Johnston" },
                    { 20, new DateTime(2013, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecuador", "rutrum.eu@pharetraQuisque.org", 12, "Macaulay Luna" },
                    { 84, new DateTime(1994, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtenstein", "Donec.est@nonlaciniaat.edu", 11, "Martin Stuart" },
                    { 79, new DateTime(1964, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuba", "lobortis.mauris@sed.edu", 11, "Clio Wagner" },
                    { 78, new DateTime(1989, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "China", "risus@suscipitest.com", 11, "Tanek Chaney" },
                    { 69, new DateTime(1999, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokelau", "aliquet@sollicitudinadipiscing.com", 11, "Gray Dalton" },
                    { 66, new DateTime(2009, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinique", "dictum@Aliquamfringilla.net", 11, "Neil Thomas" },
                    { 24, new DateTime(1994, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweden", "Maecenas@enimnonnisi.org", 11, "Nita Britt" },
                    { 5, new DateTime(2010, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermuda", "mus@nonloremvitae.co.uk", 11, "Renee Hobbs" },
                    { 61, new DateTime(1990, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tonga", "eu.odio.Phasellus@enimnec.net", 20, "Len Coleman" },
                    { 96, new DateTime(2004, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistan", "tellus.lorem.eu@lobortisquama.co.uk", 10, "Xenos Bean" },
                    { 94, new DateTime(2000, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macedonia", "lacinia.vitae@risus.org", 10, "Leah Gonzalez" },
                    { 90, new DateTime(2017, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook Islands", "magna.nec.quam@aclibero.edu", 10, "Keefe Stewart" },
                    { 55, new DateTime(1960, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian Federation", "luctus.ut.pellentesque@convallisdolorQuisque.com", 10, "Mari Joyner" },
                    { 26, new DateTime(1996, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo (Brazzaville)", "ridiculus.mus.Proin@fermentumfermentum.com", 10, "Nicole Farley" },
                    { 87, new DateTime(1955, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia", "faucibus.leo@ac.co.uk", 9, "Adria Kerr" },
                    { 82, new DateTime(1978, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatar", "blandit@egestasascelerisque.co.uk", 9, "Reese Chambers" },
                    { 73, new DateTime(1982, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korea, South", "amet@Inlorem.co.uk", 9, "Emmanuel Garrett" },
                    { 36, new DateTime(1982, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtenstein", "lacus.Ut@sed.co.uk", 9, "Grace Hines" },
                    { 3, new DateTime(1966, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece", "feugiat.tellus.lorem@etmagnisdis.co.uk", 9, "Ria Sims" },
                    { 99, new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honduras", "sit.amet@interdum.edu", 8, "Haley Gilbert" },
                    { 95, new DateTime(2015, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatar", "dolor.Nulla.semper@tortorNunc.co.uk", 10, "Abbot Dean" },
                    { 98, new DateTime(2006, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakhstan", "tellus.eu.augue@Aeneanegestas.com", 20, "Cassidy Kerr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_JobId",
                table: "User",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
