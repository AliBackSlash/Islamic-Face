using IslamicFace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace IslamicFace.Infrastructure.context.Config
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("Int").IsRequired();

            builder.Property(x => x.Name_ENG).HasColumnType("VARCHAR").HasMaxLength(30).IsRequired();

            builder.Property(x => x.Name_ARB).HasColumnType("NVARCHAR").HasMaxLength(30).IsRequired();
            
            builder.HasData(
                     new Country { Id = 1, Name_ENG = "Egypt", Name_ARB = "مصر" },
                     new Country { Id = 2, Name_ENG = "Saudi Arabia", Name_ARB = "السعودية" },
                     new Country { Id = 3, Name_ENG = "United Arab Emirates", Name_ARB = "الإمارات" },
                     new Country { Id = 4, Name_ENG = "Jordan", Name_ARB = "الأردن" },
                     new Country { Id = 5, Name_ENG = "Lebanon", Name_ARB = "لبنان" },
                     new Country { Id = 6, Name_ENG = "Syria", Name_ARB = "سوريا" },
                     new Country { Id = 7, Name_ENG = "Iraq", Name_ARB = "العراق" },
                     new Country { Id = 8, Name_ENG = "Palestine", Name_ARB = "فلسطين" },
                     new Country { Id = 9, Name_ENG = "Sudan", Name_ARB = "السودان" },
                     new Country { Id = 10, Name_ENG = "Libya", Name_ARB = "ليبيا" },
                     new Country { Id = 11, Name_ENG = "Tunisia", Name_ARB = "تونس" },
                     new Country { Id = 12, Name_ENG = "Algeria", Name_ARB = "الجزائر" },
                     new Country { Id = 13, Name_ENG = "Morocco", Name_ARB = "المغرب" },
                     new Country { Id = 14, Name_ENG = "Mauritania", Name_ARB = "موريتانيا" },
                     new Country { Id = 15, Name_ENG = "Somalia", Name_ARB = "الصومال" },
                     new Country { Id = 16, Name_ENG = "Djibouti", Name_ARB = "جيبوتي" },
                     new Country { Id = 17, Name_ENG = "Comoros", Name_ARB = "جزر القمر" },
                     new Country { Id = 18, Name_ENG = "Yemen", Name_ARB = "اليمن" },
                     new Country { Id = 19, Name_ENG = "Bahrain", Name_ARB = "البحرين" },
                     new Country { Id = 20, Name_ENG = "Qatar", Name_ARB = "قطر" },
                     new Country { Id = 21, Name_ENG = "Oman", Name_ARB = "عمان" },
                     new Country { Id = 22, Name_ENG = "Kuwait", Name_ARB = "الكويت" }
                 );

        }
    }
}
