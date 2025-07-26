using IslamicFace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace IslamicFace.Infrastructure.context.Config
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("Int").IsRequired();

            builder.Property(x => x.Name_ENG).HasColumnType("VARCHAR").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Name_ARB).HasColumnType("VARCHAR").HasMaxLength(30).IsRequired();

            builder.Property(x => x.CountryId).HasColumnType("Int").IsRequired();

            builder.HasOne(x => x.Country).WithMany(x => x.Cities).HasForeignKey(x => x.CountryId);

            builder.HasData(
                //egypt
                new City { Id = 1, Name_ENG = "Cairo", Name_ARB = "القاهرة", CountryId = 1 },
                new City { Id = 2, Name_ENG = "Giza", Name_ARB = "الجيزة", CountryId = 1 },
                new City { Id = 3, Name_ENG = "Alexandria", Name_ARB = "الإسكندرية", CountryId = 1 },
                new City { Id = 4, Name_ENG = "Dakahlia", Name_ARB = "الدقهلية", CountryId = 1 },
                new City { Id = 5, Name_ENG = "Red Sea", Name_ARB = "البحر الأحمر", CountryId = 1 },
                new City { Id = 6, Name_ENG = "Beheira", Name_ARB = "البحيرة", CountryId = 1 },
                new City { Id = 7, Name_ENG = "Fayoum", Name_ARB = "الفيوم", CountryId = 1 },
                new City { Id = 8, Name_ENG = "Gharbia", Name_ARB = "الغربية", CountryId = 1 },
                new City { Id = 9, Name_ENG = "Ismailia", Name_ARB = "الإسماعيلية", CountryId = 1 },
                new City { Id = 10, Name_ENG = "Monufia", Name_ARB = "المنوفية", CountryId = 1 },
                new City { Id = 11, Name_ENG = "Minya", Name_ARB = "المنيا", CountryId = 1 },
                new City { Id = 12, Name_ENG = "Qaliubiya", Name_ARB = "القليوبية", CountryId = 1 },
                new City { Id = 13, Name_ENG = "New Valley", Name_ARB = "الوادي الجديد", CountryId = 1 },
                new City { Id = 14, Name_ENG = "Suez", Name_ARB = "السويس", CountryId = 1 },
                new City { Id = 15, Name_ENG = "Aswan", Name_ARB = "أسوان", CountryId = 1 },
                new City { Id = 16, Name_ENG = "Asyut", Name_ARB = "أسيوط", CountryId = 1 },
                new City { Id = 17, Name_ENG = "Beni Suef", Name_ARB = "بني سويف", CountryId = 1 },
                new City { Id = 18, Name_ENG = "Port Said", Name_ARB = "بورسعيد", CountryId = 1 },
                new City { Id = 19, Name_ENG = "Damietta", Name_ARB = "دمياط", CountryId = 1 },
                new City { Id = 20, Name_ENG = "Sohag", Name_ARB = "سوهاج", CountryId = 1 },
                new City { Id = 21, Name_ENG = "North Sinai", Name_ARB = "شمال سيناء", CountryId = 1 },
                new City { Id = 22, Name_ENG = "South Sinai", Name_ARB = "جنوب سيناء", CountryId = 1 },
                new City { Id = 23, Name_ENG = "Kafr El Sheikh", Name_ARB = "كفر الشيخ", CountryId = 1 },
                new City { Id = 24, Name_ENG = "Matruh", Name_ARB = "مطروح", CountryId = 1 },
                new City { Id = 25, Name_ENG = "Luxor", Name_ARB = "الأقصر", CountryId = 1 },
                new City { Id = 26, Name_ENG = "Qena", Name_ARB = "قنا", CountryId = 1 },

                //Saudi Arabia

                new City { Id = 27, Name_ENG = "Riyadh", Name_ARB = "الرياض", CountryId = 2 },
                new City { Id = 28, Name_ENG = "Jeddah", Name_ARB = "جدة", CountryId = 2 },
                new City { Id = 29, Name_ENG = "Mecca", Name_ARB = "مكة المكرمة", CountryId = 2 },
                new City { Id = 30, Name_ENG = "Medina", Name_ARB = "المدينة المنورة", CountryId = 2 },
                new City { Id = 31, Name_ENG = "Dammam", Name_ARB = "الدمام", CountryId = 2 },
                new City { Id = 32, Name_ENG = "Khobar", Name_ARB = "الخبر", CountryId = 2 },
                new City { Id = 33, Name_ENG = "Abha", Name_ARB = "أبها", CountryId = 2 },
                new City { Id = 34, Name_ENG = "Tabuk", Name_ARB = "تبوك", CountryId = 2 },
                new City { Id = 35, Name_ENG = "Hail", Name_ARB = "حائل", CountryId = 2 },
                new City { Id = 36, Name_ENG = "Buraidah", Name_ARB = "بريدة", CountryId = 2 },
                new City { Id = 37, Name_ENG = "Najran", Name_ARB = "نجران", CountryId = 2 },
                new City { Id = 38, Name_ENG = "Jazan", Name_ARB = "جازان", CountryId = 2 },
                new City { Id = 39, Name_ENG = "Al Bahah", Name_ARB = "الباحة", CountryId = 2 },

                new City { Id = 40, Name_ENG = "Abu Dhabi", Name_ARB = "أبو ظبي", CountryId = 3 },
                new City { Id = 41, Name_ENG = "Dubai", Name_ARB = "دبي", CountryId = 3 },
                new City { Id = 42, Name_ENG = "Sharjah", Name_ARB = "الشارقة", CountryId = 3 },
                new City { Id = 43, Name_ENG = "Ajman", Name_ARB = "عجمان", CountryId = 3 },
                new City { Id = 44, Name_ENG = "Fujairah", Name_ARB = "الفجيرة", CountryId = 3 },
                new City { Id = 45, Name_ENG = "Umm Al Quwain", Name_ARB = "أم القيوين", CountryId = 3 },
                new City { Id = 46, Name_ENG = "Ras Al Khaimah", Name_ARB = "رأس الخيمة", CountryId = 3 },


                new City { Id = 47, Name_ENG = "Amman", Name_ARB = "عمّان", CountryId = 4 },
                new City { Id = 48, Name_ENG = "Irbid", Name_ARB = "إربد", CountryId = 4 },
                new City { Id = 49, Name_ENG = "Zarqa", Name_ARB = "الزرقاء", CountryId = 4 },
                new City { Id = 50, Name_ENG = "Aqaba", Name_ARB = "العقبة", CountryId = 4 },
                new City { Id = 51, Name_ENG = "Madaba", Name_ARB = "مأدبا", CountryId = 4 },
                new City { Id = 52, Name_ENG = "Jerash", Name_ARB = "جرش", CountryId = 4 },
                new City { Id = 53, Name_ENG = "Ajloun", Name_ARB = "عجلون", CountryId = 4 },
                new City { Id = 54, Name_ENG = "Mafraq", Name_ARB = "المفرق", CountryId = 4 },
                new City { Id = 55, Name_ENG = "Karak", Name_ARB = "الكرك", CountryId = 4 },
                new City { Id = 56, Name_ENG = "Tafilah", Name_ARB = "الطفيلة", CountryId = 4 },
                new City { Id = 57, Name_ENG = "Ma'an", Name_ARB = "معان", CountryId = 4 },


                new City { Id = 58, Name_ENG = "Beirut", Name_ARB = "بيروت", CountryId = 5 },
                new City { Id = 59, Name_ENG = "Tripoli", Name_ARB = "طرابلس", CountryId = 5 },
                new City { Id = 60, Name_ENG = "Sidon", Name_ARB = "صيدا", CountryId = 5 },
                new City { Id = 61, Name_ENG = "Tyre", Name_ARB = "صور", CountryId = 5 },
                new City { Id = 62, Name_ENG = "Zahle", Name_ARB = "زحلة", CountryId = 5 },
                new City { Id = 63, Name_ENG = "Jounieh", Name_ARB = "جونية", CountryId = 5 },
                new City { Id = 64, Name_ENG = "Byblos", Name_ARB = "جبيل", CountryId = 5 },

                new City { Id = 65, Name_ENG = "Damascus", Name_ARB = "دمشق", CountryId = 6 },
                new City { Id = 66, Name_ENG = "Aleppo", Name_ARB = "حلب", CountryId = 6 },
                new City { Id = 67, Name_ENG = "Homs", Name_ARB = "حمص", CountryId = 6 },
                new City { Id = 68, Name_ENG = "Latakia", Name_ARB = "اللاذقية", CountryId = 6 },
                new City { Id = 69, Name_ENG = "Tartus", Name_ARB = "طرطوس", CountryId = 6 },
                new City { Id = 70, Name_ENG = "Hama", Name_ARB = "حماة", CountryId = 6 },
                new City { Id = 71, Name_ENG = "Daraa", Name_ARB = "درعا", CountryId = 6 },
                new City { Id = 72, Name_ENG = "Deir ez-Zor", Name_ARB = "دير الزور", CountryId = 6 },
                new City { Id = 73, Name_ENG = "Raqqa", Name_ARB = "الرقة", CountryId = 6 },
                new City { Id = 74, Name_ENG = "Quneitra", Name_ARB = "القنيطرة", CountryId = 6 },


                new City { Id = 75, Name_ENG = "Baghdad", Name_ARB = "بغداد", CountryId = 7 },
                new City { Id = 76, Name_ENG = "Basra", Name_ARB = "البصرة", CountryId = 7 },
                new City { Id = 77, Name_ENG = "Mosul", Name_ARB = "الموصل", CountryId = 7 },
                new City { Id = 78, Name_ENG = "Erbil", Name_ARB = "أربيل", CountryId = 7 },
                new City { Id = 79, Name_ENG = "Karbala", Name_ARB = "كربلاء", CountryId = 7 },
                new City { Id = 80, Name_ENG = "Najaf", Name_ARB = "النجف", CountryId = 7 },
                new City { Id = 81, Name_ENG = "Kirkuk", Name_ARB = "كركوك", CountryId = 7 },
                new City { Id = 82, Name_ENG = "Sulaymaniyah", Name_ARB = "السليمانية", CountryId = 7 },
                new City { Id = 83, Name_ENG = "Diyala", Name_ARB = "ديالى", CountryId = 7 },
                new City { Id = 84, Name_ENG = "Dhi Qar", Name_ARB = "ذي قار", CountryId = 7 },


                new City { Id = 85, Name_ENG = "Jerusalem", Name_ARB = "القدس", CountryId = 8 },
                new City { Id = 86, Name_ENG = "Gaza", Name_ARB = "غزة", CountryId = 8 },
                new City { Id = 87, Name_ENG = "Hebron", Name_ARB = "الخليل", CountryId = 8 },
                new City { Id = 88, Name_ENG = "Nablus", Name_ARB = "نابلس", CountryId = 8 },
                new City { Id = 89, Name_ENG = "Bethlehem", Name_ARB = "بيت لحم", CountryId = 8 },
                new City { Id = 90, Name_ENG = "Ramallah", Name_ARB = "رام الله", CountryId = 8 },
                new City { Id = 91, Name_ENG = "Jenin", Name_ARB = "جنين", CountryId = 8 },
                new City { Id = 92, Name_ENG = "Tulkarm", Name_ARB = "طولكرم", CountryId = 8 },
                new City { Id = 93, Name_ENG = "Qalqilya", Name_ARB = "قلقيلية", CountryId = 8 },
                new City { Id = 94, Name_ENG = "Rafah", Name_ARB = "رفح", CountryId = 8 },


                new City { Id = 95, Name_ENG = "Khartoum", Name_ARB = "الخرطوم", CountryId = 9 },
                new City { Id = 96, Name_ENG = "Omdurman", Name_ARB = "أم درمان", CountryId = 9 },
                new City { Id = 97, Name_ENG = "Port Sudan", Name_ARB = "بورتسودان", CountryId = 9 },
                new City { Id = 98, Name_ENG = "Kassala", Name_ARB = "كسلا", CountryId = 9 },
                new City { Id = 99, Name_ENG = "El Obeid", Name_ARB = "الأبيض", CountryId = 9 },
                new City { Id = 100, Name_ENG = "Nyala", Name_ARB = "نيالا", CountryId = 9 },
                new City { Id = 101, Name_ENG = "Dongola", Name_ARB = "دنقلا", CountryId = 9 },
                new City { Id = 102, Name_ENG = "El Fasher", Name_ARB = "الفاشر", CountryId = 9 },


                new City { Id = 103, Name_ENG = "Tripoli", Name_ARB = "طرابلس", CountryId = 10 },
                new City { Id = 104, Name_ENG = "Benghazi", Name_ARB = "بنغازي", CountryId = 10 },
                new City { Id = 105, Name_ENG = "Misrata", Name_ARB = "مصراتة", CountryId = 10 },
                new City { Id = 106, Name_ENG = "Zawiya", Name_ARB = "الزاوية", CountryId = 10 },
                new City { Id = 107, Name_ENG = "Sabha", Name_ARB = "سبها", CountryId = 10 },
                new City { Id = 108, Name_ENG = "Derna", Name_ARB = "درنة", CountryId = 10 },
                new City { Id = 109, Name_ENG = "Tobruk", Name_ARB = "طبرق", CountryId = 10 },
                new City { Id = 110, Name_ENG = "Al Bayda", Name_ARB = "البيضاء", CountryId = 10 },


                 new City { Id = 111, Name_ENG = "Tunis", Name_ARB = "تونس", CountryId = 11 },
                new City { Id = 112, Name_ENG = "Sfax", Name_ARB = "صفاقس", CountryId = 11 },
                new City { Id = 113, Name_ENG = "Sousse", Name_ARB = "سوسة", CountryId = 11 },
                new City { Id = 114, Name_ENG = "Kairouan", Name_ARB = "القيروان", CountryId = 11 },
                new City { Id = 115, Name_ENG = "Bizerte", Name_ARB = "بنزرت", CountryId = 11 },
                new City { Id = 116, Name_ENG = "Gabes", Name_ARB = "قابس", CountryId = 11 },
                new City { Id = 117, Name_ENG = "Gafsa", Name_ARB = "قفصة", CountryId = 11 },
                new City { Id = 118, Name_ENG = "Monastir", Name_ARB = "المنستير", CountryId = 11 },
                new City { Id = 119, Name_ENG = "Nabeul", Name_ARB = "نابل", CountryId = 11 },
                new City { Id = 120, Name_ENG = "Sidi Bouzid", Name_ARB = "سيدي بوزيد", CountryId = 11 },
                new City { Id = 121, Name_ENG = "Kasserine", Name_ARB = "قصرين", CountryId = 11 },
                new City { Id = 122, Name_ENG = "Jendouba", Name_ARB = "جندوبة", CountryId = 11 },
                new City { Id = 123, Name_ENG = "Siliana", Name_ARB = "سليانة", CountryId = 11 },
                new City { Id = 124, Name_ENG = "Tozeur", Name_ARB = "توزر", CountryId = 11 },
                new City { Id = 125, Name_ENG = "Medenine", Name_ARB = "مدنين", CountryId = 11 },
                new City { Id = 126, Name_ENG = "Mahdia", Name_ARB = "المهدية", CountryId = 11 },
                new City { Id = 127, Name_ENG = "Kebili", Name_ARB = "قبلي", CountryId = 11 },
                new City { Id = 128, Name_ENG = "Ariana", Name_ARB = "أريانة", CountryId = 11 },
                new City { Id = 129, Name_ENG = "Ben Arous", Name_ARB = "بن عروس", CountryId = 11 },
                new City { Id = 130, Name_ENG = "Manouba", Name_ARB = "منوبة", CountryId = 11 },
                new City { Id = 131, Name_ENG = "Kef", Name_ARB = "الكاف", CountryId = 11 },
                new City { Id = 132, Name_ENG = "Tataouine", Name_ARB = "تطاوين", CountryId = 11 },
                new City { Id = 133, Name_ENG = "Zaghouan", Name_ARB = "زغوان", CountryId = 11 },


                    new City { Id = 134, Name_ENG = "Algiers", Name_ARB = "الجزائر العاصمة", CountryId = 12 },
                new City { Id = 135, Name_ENG = "Oran", Name_ARB = "وهران", CountryId = 12 },
                new City { Id = 136, Name_ENG = "Constantine", Name_ARB = "قسنطينة", CountryId = 12 },
                new City { Id = 137, Name_ENG = "Annaba", Name_ARB = "عنابة", CountryId = 12 },
                new City { Id = 138, Name_ENG = "Blida", Name_ARB = "البليدة", CountryId = 12 },
                new City { Id = 139, Name_ENG = "Setif", Name_ARB = "سطيف", CountryId = 12 },
                new City { Id = 140, Name_ENG = "Batna", Name_ARB = "باتنة", CountryId = 12 },
                new City { Id = 141, Name_ENG = "Tlemcen", Name_ARB = "تلمسان", CountryId = 12 },
                new City { Id = 142, Name_ENG = "Sidi Bel Abbes", Name_ARB = "سيدي بلعباس", CountryId = 12 },
                new City { Id = 143, Name_ENG = "Biskra", Name_ARB = "بسكرة", CountryId = 12 },
                new City { Id = 144, Name_ENG = "Tizi Ouzou", Name_ARB = "تيزي وزو", CountryId = 12 },
                new City { Id = 145, Name_ENG = "Bejaia", Name_ARB = "بجاية", CountryId = 12 },
                new City { Id = 146, Name_ENG = "Djelfa", Name_ARB = "الجلفة", CountryId = 12 },
                new City { Id = 147, Name_ENG = "Mascara", Name_ARB = "معسكر", CountryId = 12 },
                new City { Id = 148, Name_ENG = "Bechar", Name_ARB = "بشار", CountryId = 12 },
                new City { Id = 149, Name_ENG = "Tamanrasset", Name_ARB = "تمنراست", CountryId = 12 },

                new City { Id = 150, Name_ENG = "Rabat", Name_ARB = "الرباط", CountryId = 13 },
                new City { Id = 151, Name_ENG = "Casablanca", Name_ARB = "الدار البيضاء", CountryId = 13 },
                new City { Id = 152, Name_ENG = "Fes", Name_ARB = "فاس", CountryId = 13 },
                new City { Id = 153, Name_ENG = "Marrakesh", Name_ARB = "مراكش", CountryId = 13 },
                new City { Id = 154, Name_ENG = "Tangier", Name_ARB = "طنجة", CountryId = 13 },
                new City { Id = 155, Name_ENG = "Agadir", Name_ARB = "أكادير", CountryId = 13 },
                new City { Id = 156, Name_ENG = "Oujda", Name_ARB = "وجدة", CountryId = 13 },
                new City { Id = 157, Name_ENG = "Kenitra", Name_ARB = "القنيطرة", CountryId = 13 },
                new City { Id = 158, Name_ENG = "Meknes", Name_ARB = "مكناس", CountryId = 13 },
                new City { Id = 159, Name_ENG = "Tetouan", Name_ARB = "تطوان", CountryId = 13 },
                new City { Id = 160, Name_ENG = "Safi", Name_ARB = "آسفي", CountryId = 13 },
                new City { Id = 161, Name_ENG = "El Jadida", Name_ARB = "الجديدة", CountryId = 13 },
                new City { Id = 162, Name_ENG = "Beni Mellal", Name_ARB = "بني ملال", CountryId = 13 },
                new City { Id = 163, Name_ENG = "Nador", Name_ARB = "الناظور", CountryId = 13 },
                new City { Id = 164, Name_ENG = "Taza", Name_ARB = "تازة", CountryId = 13 },



                new City { Id = 165, Name_ENG = "Nouakchott", Name_ARB = "نواكشوط", CountryId = 14 },
                new City { Id = 166, Name_ENG = "Nouadhibou", Name_ARB = "نواذيبو", CountryId = 14 },
                new City { Id = 167, Name_ENG = "Zouérat", Name_ARB = "زويرات", CountryId = 14 },
                new City { Id = 168, Name_ENG = "Atar", Name_ARB = "أطار", CountryId = 14 },
                new City { Id = 169, Name_ENG = "Kaédi", Name_ARB = "كيهيدي", CountryId = 14 },
                new City { Id = 170, Name_ENG = "Kiffa", Name_ARB = "كيفه", CountryId = 14 },
                new City { Id = 171, Name_ENG = "Rosso", Name_ARB = "روصو", CountryId = 14 },
                new City { Id = 172, Name_ENG = "Tidjikja", Name_ARB = "تجكجه", CountryId = 14 },
                new City { Id = 173, Name_ENG = "Aleg", Name_ARB = "ألاك", CountryId = 14 },
                new City { Id = 174, Name_ENG = "Sélibaby", Name_ARB = "سيليبابي", CountryId = 14 },
                new City { Id = 175, Name_ENG = "Néma", Name_ARB = "النعمة", CountryId = 14 },



                new City { Id = 176, Name_ENG = "Mogadishu", Name_ARB = "مقديشو", CountryId = 15 },
                new City { Id = 177, Name_ENG = "Hargeisa", Name_ARB = "هرجيسا", CountryId = 15 },
                new City { Id = 178, Name_ENG = "Bosaso", Name_ARB = "بوصاصو", CountryId = 15 },
                new City { Id = 179, Name_ENG = "Kismayo", Name_ARB = "كيسمايو", CountryId = 15 },
                new City { Id = 180, Name_ENG = "Baidoa", Name_ARB = "بيدوا", CountryId = 15 },
                new City { Id = 181, Name_ENG = "Galkayo", Name_ARB = "جالكعيو", CountryId = 15 },
                new City { Id = 182, Name_ENG = "Garowe", Name_ARB = "غرووي", CountryId = 15 },
                new City { Id = 183, Name_ENG = "Beledweyne", Name_ARB = "بلد وين", CountryId = 15 },
                new City { Id = 184, Name_ENG = "Marka", Name_ARB = "مركا", CountryId = 15 },
                new City { Id = 185, Name_ENG = "Jowhar", Name_ARB = "جوهار", CountryId = 15 },
                new City { Id = 186, Name_ENG = "Afgooye", Name_ARB = "أفجوي", CountryId = 15 },

                new City { Id = 187, Name_ENG = "Djibouti", Name_ARB = "جيبوتي", CountryId = 16 },
                new City { Id = 188, Name_ENG = "Ali Sabieh", Name_ARB = "علي صبيح", CountryId = 16 },
                new City { Id = 189, Name_ENG = "Tadjourah", Name_ARB = "تاجورة", CountryId = 16 },
                new City { Id = 190, Name_ENG = "Obock", Name_ARB = "أوبوك", CountryId = 16 },
                new City { Id = 191, Name_ENG = "Dikhil", Name_ARB = "دخيل", CountryId = 16 },
                new City { Id = 192, Name_ENG = "Arta", Name_ARB = "أرتا", CountryId = 16 },


                new City { Id = 193, Name_ENG = "Moroni", Name_ARB = "موروني", CountryId = 17 },
                new City { Id = 194, Name_ENG = "Mutsamudu", Name_ARB = "متسامودو", CountryId = 17 },
                new City { Id = 195, Name_ENG = "Fomboni", Name_ARB = "فمبوني", CountryId = 17 },
                new City { Id = 196, Name_ENG = "Domoni", Name_ARB = "دوموني", CountryId = 17 },
                new City { Id = 197, Name_ENG = "Ouani", Name_ARB = "واني", CountryId = 17 },

    
                new City { Id = 198, Name_ENG = "Sana'a", Name_ARB = "صنعاء", CountryId = 18 },
                new City { Id = 199, Name_ENG = "Aden", Name_ARB = "عدن", CountryId = 18 },
                new City { Id = 200, Name_ENG = "Taiz", Name_ARB = "تعز", CountryId = 18 },
                new City { Id = 201, Name_ENG = "Ibb", Name_ARB = "إب", CountryId = 18 },
                new City { Id = 202, Name_ENG = "Al Hudaydah", Name_ARB = "الحديدة", CountryId = 18 },
                new City { Id = 203, Name_ENG = "Hadramout", Name_ARB = "حضرموت", CountryId = 18 },

                    new City { Id = 204, Name_ENG = "Manama", Name_ARB = "المنامة", CountryId = 19 },
                new City { Id = 205, Name_ENG = "Muharraq", Name_ARB = "المحرق", CountryId = 19 },
                new City { Id = 206, Name_ENG = "Riffa", Name_ARB = "الرفاع", CountryId = 19 },
                new City { Id = 207, Name_ENG = "Isa Town", Name_ARB = "مدينة عيسى", CountryId = 19 },
                new City { Id = 208, Name_ENG = "Hamad Town", Name_ARB = "مدينة حمد", CountryId = 19 },


                    new City { Id = 209, Name_ENG = "Doha", Name_ARB = "الدوحة", CountryId = 20 },
                new City { Id = 210, Name_ENG = "Al Rayyan", Name_ARB = "الريان", CountryId = 20 },
                new City { Id = 211, Name_ENG = "Umm Salal", Name_ARB = "أم صلال", CountryId = 20 },
                new City { Id = 212, Name_ENG = "Al Wakrah", Name_ARB = "الوكرة", CountryId = 20 },
                new City { Id = 213, Name_ENG = "Al Khor", Name_ARB = "الخور", CountryId = 20 },

                    new City { Id = 214, Name_ENG = "Muscat", Name_ARB = "مسقط", CountryId = 21 },
                new City { Id = 215, Name_ENG = "Salalah", Name_ARB = "صلالة", CountryId = 21 },
                new City { Id = 216, Name_ENG = "Sohar", Name_ARB = "صحار", CountryId = 21 },
                new City { Id = 217, Name_ENG = "Nizwa", Name_ARB = "نزوى", CountryId = 21 },
                new City { Id = 218, Name_ENG = "Sur", Name_ARB = "صور", CountryId = 21 },


                    new City { Id = 219, Name_ENG = "Kuwait City", Name_ARB = "مدينة الكويت", CountryId = 22 },
                new City { Id = 220, Name_ENG = "Al Ahmadi", Name_ARB = "الأحمدي", CountryId = 22 },
                new City { Id = 221, Name_ENG = "Hawalli", Name_ARB = "حولي", CountryId = 22 },
                new City { Id = 222, Name_ENG = "Farwaniya", Name_ARB = "الفروانية", CountryId = 22 },
                new City { Id = 223, Name_ENG = "Jahra", Name_ARB = "الجهراء", CountryId = 22 },
                new City { Id = 224, Name_ENG = "Mubarak Al-Kabeer", Name_ARB = "مبارك الكبير", CountryId = 22 }
    );
        }
    }
}
