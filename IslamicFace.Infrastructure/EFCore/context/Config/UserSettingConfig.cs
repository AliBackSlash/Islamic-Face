using IslamicFace.Domain.Entities;
using IslamicFace.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IslamicFace.Infrastructure.context.Config
{
    public class UserSettingConfig : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            builder.ToTable("UserSettings");
            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Id)
              .HasColumnType("TinyInt")
              .IsRequired();

            builder.Property(x => x.GenderOfFriends)
               .HasConversion(
                    x => x.ToString(),
                    x => (GenderOfFriends)Enum.Parse(typeof(GenderOfFriends), x)
               );

            builder.HasData(
                new UserSetting { Id = 1, GenderOfFriends = GenderOfFriends.Male},
                new UserSetting { Id = 2, GenderOfFriends = GenderOfFriends.Female},
                new UserSetting { Id = 3, GenderOfFriends = GenderOfFriends.Both}
                );

        }
    }
}
