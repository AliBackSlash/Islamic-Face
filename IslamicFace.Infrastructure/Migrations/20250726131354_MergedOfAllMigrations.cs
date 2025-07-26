using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MergedOfAllMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Int", nullable: false),
                    Name_ENG = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Name_ARB = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TinyInt", nullable: false),
                    ReactType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TinyInt", nullable: false),
                    GenderOfFriends = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Int", nullable: false),
                    Name_ENG = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Name_ARB = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    CountryId = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(254)", maxLength: 254, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    userName = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    countryID = table.Column<int>(type: "Int", nullable: false),
                    cityID = table.Column<int>(type: "Int", nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "Date", nullable: false),
                    joinDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    gender = table.Column<bool>(type: "Bit", nullable: false),
                    profilePictureURL = table.Column<string>(type: "VARCHAR(2083)", maxLength: 2083, nullable: false),
                    bio = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    userType = table.Column<byte>(type: "TinyInt", nullable: false),
                    settingId = table.Column<byte>(type: "TinyInt", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Countries_countryID",
                        column: x => x.countryID,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserSettings_settingId",
                        column: x => x.settingId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false),
                    senderID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ReceiverID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    RequestStatus = table.Column<byte>(type: "TinyInt", nullable: false),
                    ResponseAt = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DateSend = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_senderID",
                        column: x => x.senderID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false),
                    postText = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    userId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    createdAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    postId = table.Column<long>(type: "BigInt", nullable: false),
                    ParentCommentID = table.Column<long>(type: "BigInt", nullable: true),
                    Comment = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    reactLikeCount = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_PostComments_ParentCommentID",
                        column: x => x.ParentCommentID,
                        principalTable: "PostComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PostComments_Posts_postId",
                        column: x => x.postId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostComments_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PostMedias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false),
                    postId = table.Column<long>(type: "BigInt", nullable: false),
                    mediaType = table.Column<byte>(type: "tinyInt", nullable: false),
                    mediaURL = table.Column<string>(type: "VARCHAR(2083)", maxLength: 2083, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostMedias_Posts_postId",
                        column: x => x.postId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    postId = table.Column<long>(type: "BigInt", nullable: false),
                    reactTypeID = table.Column<byte>(type: "TinyInt", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => new { x.userId, x.postId });
                    table.ForeignKey(
                        name: "FK_PostReactions_Posts_postId",
                        column: x => x.postId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReactions_Reactions_reactTypeID",
                        column: x => x.reactTypeID,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReactions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false),
                    postId = table.Column<long>(type: "BigInt", nullable: false),
                    tag = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_postId",
                        column: x => x.postId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name_ARB", "Name_ENG" },
                values: new object[,]
                {
                    { 1, "مصر", "Egypt" },
                    { 2, "السعودية", "Saudi Arabia" },
                    { 3, "الإمارات", "United Arab Emirates" },
                    { 4, "الأردن", "Jordan" },
                    { 5, "لبنان", "Lebanon" },
                    { 6, "سوريا", "Syria" },
                    { 7, "العراق", "Iraq" },
                    { 8, "فلسطين", "Palestine" },
                    { 9, "السودان", "Sudan" },
                    { 10, "ليبيا", "Libya" },
                    { 11, "تونس", "Tunisia" },
                    { 12, "الجزائر", "Algeria" },
                    { 13, "المغرب", "Morocco" },
                    { 14, "موريتانيا", "Mauritania" },
                    { 15, "الصومال", "Somalia" },
                    { 16, "جيبوتي", "Djibouti" },
                    { 17, "جزر القمر", "Comoros" },
                    { 18, "اليمن", "Yemen" },
                    { 19, "البحرين", "Bahrain" },
                    { 20, "قطر", "Qatar" },
                    { 21, "عمان", "Oman" },
                    { 22, "الكويت", "Kuwait" }
                });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "GenderOfFriends" },
                values: new object[,]
                {
                    { (byte)1, "Male" },
                    { (byte)2, "Female" },
                    { (byte)3, "Both" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name_ARB", "Name_ENG" },
                values: new object[,]
                {
                    { 1, 1, "القاهرة", "Cairo" },
                    { 2, 1, "الجيزة", "Giza" },
                    { 3, 1, "الإسكندرية", "Alexandria" },
                    { 4, 1, "الدقهلية", "Dakahlia" },
                    { 5, 1, "البحر الأحمر", "Red Sea" },
                    { 6, 1, "البحيرة", "Beheira" },
                    { 7, 1, "الفيوم", "Fayoum" },
                    { 8, 1, "الغربية", "Gharbia" },
                    { 9, 1, "الإسماعيلية", "Ismailia" },
                    { 10, 1, "المنوفية", "Monufia" },
                    { 11, 1, "المنيا", "Minya" },
                    { 12, 1, "القليوبية", "Qaliubiya" },
                    { 13, 1, "الوادي الجديد", "New Valley" },
                    { 14, 1, "السويس", "Suez" },
                    { 15, 1, "أسوان", "Aswan" },
                    { 16, 1, "أسيوط", "Asyut" },
                    { 17, 1, "بني سويف", "Beni Suef" },
                    { 18, 1, "بورسعيد", "Port Said" },
                    { 19, 1, "دمياط", "Damietta" },
                    { 20, 1, "سوهاج", "Sohag" },
                    { 21, 1, "شمال سيناء", "North Sinai" },
                    { 22, 1, "جنوب سيناء", "South Sinai" },
                    { 23, 1, "كفر الشيخ", "Kafr El Sheikh" },
                    { 24, 1, "مطروح", "Matruh" },
                    { 25, 1, "الأقصر", "Luxor" },
                    { 26, 1, "قنا", "Qena" },
                    { 27, 2, "الرياض", "Riyadh" },
                    { 28, 2, "جدة", "Jeddah" },
                    { 29, 2, "مكة المكرمة", "Mecca" },
                    { 30, 2, "المدينة المنورة", "Medina" },
                    { 31, 2, "الدمام", "Dammam" },
                    { 32, 2, "الخبر", "Khobar" },
                    { 33, 2, "أبها", "Abha" },
                    { 34, 2, "تبوك", "Tabuk" },
                    { 35, 2, "حائل", "Hail" },
                    { 36, 2, "بريدة", "Buraidah" },
                    { 37, 2, "نجران", "Najran" },
                    { 38, 2, "جازان", "Jazan" },
                    { 39, 2, "الباحة", "Al Bahah" },
                    { 40, 3, "أبو ظبي", "Abu Dhabi" },
                    { 41, 3, "دبي", "Dubai" },
                    { 42, 3, "الشارقة", "Sharjah" },
                    { 43, 3, "عجمان", "Ajman" },
                    { 44, 3, "الفجيرة", "Fujairah" },
                    { 45, 3, "أم القيوين", "Umm Al Quwain" },
                    { 46, 3, "رأس الخيمة", "Ras Al Khaimah" },
                    { 47, 4, "عمّان", "Amman" },
                    { 48, 4, "إربد", "Irbid" },
                    { 49, 4, "الزرقاء", "Zarqa" },
                    { 50, 4, "العقبة", "Aqaba" },
                    { 51, 4, "مأدبا", "Madaba" },
                    { 52, 4, "جرش", "Jerash" },
                    { 53, 4, "عجلون", "Ajloun" },
                    { 54, 4, "المفرق", "Mafraq" },
                    { 55, 4, "الكرك", "Karak" },
                    { 56, 4, "الطفيلة", "Tafilah" },
                    { 57, 4, "معان", "Ma'an" },
                    { 58, 5, "بيروت", "Beirut" },
                    { 59, 5, "طرابلس", "Tripoli" },
                    { 60, 5, "صيدا", "Sidon" },
                    { 61, 5, "صور", "Tyre" },
                    { 62, 5, "زحلة", "Zahle" },
                    { 63, 5, "جونية", "Jounieh" },
                    { 64, 5, "جبيل", "Byblos" },
                    { 65, 6, "دمشق", "Damascus" },
                    { 66, 6, "حلب", "Aleppo" },
                    { 67, 6, "حمص", "Homs" },
                    { 68, 6, "اللاذقية", "Latakia" },
                    { 69, 6, "طرطوس", "Tartus" },
                    { 70, 6, "حماة", "Hama" },
                    { 71, 6, "درعا", "Daraa" },
                    { 72, 6, "دير الزور", "Deir ez-Zor" },
                    { 73, 6, "الرقة", "Raqqa" },
                    { 74, 6, "القنيطرة", "Quneitra" },
                    { 75, 7, "بغداد", "Baghdad" },
                    { 76, 7, "البصرة", "Basra" },
                    { 77, 7, "الموصل", "Mosul" },
                    { 78, 7, "أربيل", "Erbil" },
                    { 79, 7, "كربلاء", "Karbala" },
                    { 80, 7, "النجف", "Najaf" },
                    { 81, 7, "كركوك", "Kirkuk" },
                    { 82, 7, "السليمانية", "Sulaymaniyah" },
                    { 83, 7, "ديالى", "Diyala" },
                    { 84, 7, "ذي قار", "Dhi Qar" },
                    { 85, 8, "القدس", "Jerusalem" },
                    { 86, 8, "غزة", "Gaza" },
                    { 87, 8, "الخليل", "Hebron" },
                    { 88, 8, "نابلس", "Nablus" },
                    { 89, 8, "بيت لحم", "Bethlehem" },
                    { 90, 8, "رام الله", "Ramallah" },
                    { 91, 8, "جنين", "Jenin" },
                    { 92, 8, "طولكرم", "Tulkarm" },
                    { 93, 8, "قلقيلية", "Qalqilya" },
                    { 94, 8, "رفح", "Rafah" },
                    { 95, 9, "الخرطوم", "Khartoum" },
                    { 96, 9, "أم درمان", "Omdurman" },
                    { 97, 9, "بورتسودان", "Port Sudan" },
                    { 98, 9, "كسلا", "Kassala" },
                    { 99, 9, "الأبيض", "El Obeid" },
                    { 100, 9, "نيالا", "Nyala" },
                    { 101, 9, "دنقلا", "Dongola" },
                    { 102, 9, "الفاشر", "El Fasher" },
                    { 103, 10, "طرابلس", "Tripoli" },
                    { 104, 10, "بنغازي", "Benghazi" },
                    { 105, 10, "مصراتة", "Misrata" },
                    { 106, 10, "الزاوية", "Zawiya" },
                    { 107, 10, "سبها", "Sabha" },
                    { 108, 10, "درنة", "Derna" },
                    { 109, 10, "طبرق", "Tobruk" },
                    { 110, 10, "البيضاء", "Al Bayda" },
                    { 111, 11, "تونس", "Tunis" },
                    { 112, 11, "صفاقس", "Sfax" },
                    { 113, 11, "سوسة", "Sousse" },
                    { 114, 11, "القيروان", "Kairouan" },
                    { 115, 11, "بنزرت", "Bizerte" },
                    { 116, 11, "قابس", "Gabes" },
                    { 117, 11, "قفصة", "Gafsa" },
                    { 118, 11, "المنستير", "Monastir" },
                    { 119, 11, "نابل", "Nabeul" },
                    { 120, 11, "سيدي بوزيد", "Sidi Bouzid" },
                    { 121, 11, "قصرين", "Kasserine" },
                    { 122, 11, "جندوبة", "Jendouba" },
                    { 123, 11, "سليانة", "Siliana" },
                    { 124, 11, "توزر", "Tozeur" },
                    { 125, 11, "مدنين", "Medenine" },
                    { 126, 11, "المهدية", "Mahdia" },
                    { 127, 11, "قبلي", "Kebili" },
                    { 128, 11, "أريانة", "Ariana" },
                    { 129, 11, "بن عروس", "Ben Arous" },
                    { 130, 11, "منوبة", "Manouba" },
                    { 131, 11, "الكاف", "Kef" },
                    { 132, 11, "تطاوين", "Tataouine" },
                    { 133, 11, "زغوان", "Zaghouan" },
                    { 134, 12, "الجزائر العاصمة", "Algiers" },
                    { 135, 12, "وهران", "Oran" },
                    { 136, 12, "قسنطينة", "Constantine" },
                    { 137, 12, "عنابة", "Annaba" },
                    { 138, 12, "البليدة", "Blida" },
                    { 139, 12, "سطيف", "Setif" },
                    { 140, 12, "باتنة", "Batna" },
                    { 141, 12, "تلمسان", "Tlemcen" },
                    { 142, 12, "سيدي بلعباس", "Sidi Bel Abbes" },
                    { 143, 12, "بسكرة", "Biskra" },
                    { 144, 12, "تيزي وزو", "Tizi Ouzou" },
                    { 145, 12, "بجاية", "Bejaia" },
                    { 146, 12, "الجلفة", "Djelfa" },
                    { 147, 12, "معسكر", "Mascara" },
                    { 148, 12, "بشار", "Bechar" },
                    { 149, 12, "تمنراست", "Tamanrasset" },
                    { 150, 13, "الرباط", "Rabat" },
                    { 151, 13, "الدار البيضاء", "Casablanca" },
                    { 152, 13, "فاس", "Fes" },
                    { 153, 13, "مراكش", "Marrakesh" },
                    { 154, 13, "طنجة", "Tangier" },
                    { 155, 13, "أكادير", "Agadir" },
                    { 156, 13, "وجدة", "Oujda" },
                    { 157, 13, "القنيطرة", "Kenitra" },
                    { 158, 13, "مكناس", "Meknes" },
                    { 159, 13, "تطوان", "Tetouan" },
                    { 160, 13, "آسفي", "Safi" },
                    { 161, 13, "الجديدة", "El Jadida" },
                    { 162, 13, "بني ملال", "Beni Mellal" },
                    { 163, 13, "الناظور", "Nador" },
                    { 164, 13, "تازة", "Taza" },
                    { 165, 14, "نواكشوط", "Nouakchott" },
                    { 166, 14, "نواذيبو", "Nouadhibou" },
                    { 167, 14, "زويرات", "Zouérat" },
                    { 168, 14, "أطار", "Atar" },
                    { 169, 14, "كيهيدي", "Kaédi" },
                    { 170, 14, "كيفه", "Kiffa" },
                    { 171, 14, "روصو", "Rosso" },
                    { 172, 14, "تجكجه", "Tidjikja" },
                    { 173, 14, "ألاك", "Aleg" },
                    { 174, 14, "سيليبابي", "Sélibaby" },
                    { 175, 14, "النعمة", "Néma" },
                    { 176, 15, "مقديشو", "Mogadishu" },
                    { 177, 15, "هرجيسا", "Hargeisa" },
                    { 178, 15, "بوصاصو", "Bosaso" },
                    { 179, 15, "كيسمايو", "Kismayo" },
                    { 180, 15, "بيدوا", "Baidoa" },
                    { 181, 15, "جالكعيو", "Galkayo" },
                    { 182, 15, "غرووي", "Garowe" },
                    { 183, 15, "بلد وين", "Beledweyne" },
                    { 184, 15, "مركا", "Marka" },
                    { 185, 15, "جوهار", "Jowhar" },
                    { 186, 15, "أفجوي", "Afgooye" },
                    { 187, 16, "جيبوتي", "Djibouti" },
                    { 188, 16, "علي صبيح", "Ali Sabieh" },
                    { 189, 16, "تاجورة", "Tadjourah" },
                    { 190, 16, "أوبوك", "Obock" },
                    { 191, 16, "دخيل", "Dikhil" },
                    { 192, 16, "أرتا", "Arta" },
                    { 193, 17, "موروني", "Moroni" },
                    { 194, 17, "متسامودو", "Mutsamudu" },
                    { 195, 17, "فمبوني", "Fomboni" },
                    { 196, 17, "دوموني", "Domoni" },
                    { 197, 17, "واني", "Ouani" },
                    { 198, 18, "صنعاء", "Sana'a" },
                    { 199, 18, "عدن", "Aden" },
                    { 200, 18, "تعز", "Taiz" },
                    { 201, 18, "إب", "Ibb" },
                    { 202, 18, "الحديدة", "Al Hudaydah" },
                    { 203, 18, "حضرموت", "Hadramout" },
                    { 204, 19, "المنامة", "Manama" },
                    { 205, 19, "المحرق", "Muharraq" },
                    { 206, 19, "الرفاع", "Riffa" },
                    { 207, 19, "مدينة عيسى", "Isa Town" },
                    { 208, 19, "مدينة حمد", "Hamad Town" },
                    { 209, 20, "الدوحة", "Doha" },
                    { 210, 20, "الريان", "Al Rayyan" },
                    { 211, 20, "أم صلال", "Umm Salal" },
                    { 212, 20, "الوكرة", "Al Wakrah" },
                    { 213, 20, "الخور", "Al Khor" },
                    { 214, 21, "مسقط", "Muscat" },
                    { 215, 21, "صلالة", "Salalah" },
                    { 216, 21, "صحار", "Sohar" },
                    { 217, 21, "نزوى", "Nizwa" },
                    { 218, 21, "صور", "Sur" },
                    { 219, 22, "مدينة الكويت", "Kuwait City" },
                    { 220, 22, "الأحمدي", "Al Ahmadi" },
                    { 221, 22, "حولي", "Hawalli" },
                    { 222, 22, "الفروانية", "Farwaniya" },
                    { 223, 22, "الجهراء", "Jahra" },
                    { 224, 22, "مبارك الكبير", "Mubarak Al-Kabeer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverID",
                table: "FriendRequests",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_senderID_ReceiverID",
                table: "FriendRequests",
                columns: new[] { "senderID", "ReceiverID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_ParentCommentID",
                table: "PostComments",
                column: "ParentCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_postId",
                table: "PostComments",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_userId",
                table: "PostComments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedias_postId",
                table: "PostMedias",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_postId",
                table: "PostReactions",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_reactTypeID",
                table: "PostReactions",
                column: "reactTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_userId",
                table: "Posts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_postId",
                table: "PostTags",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_countryID",
                table: "Users",
                column: "countryID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_settingId",
                table: "Users",
                column: "settingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "PostMedias");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "UserSettings");
        }
    }
}
