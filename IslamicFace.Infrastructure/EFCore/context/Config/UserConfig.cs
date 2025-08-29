using IslamicFace.Domain.Enums;

namespace IslamicFace.Infrastructure.context.Config
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                  .HasColumnType("UNIQUEIDENTIFIER")
                  .HasDefaultValueSql("NEWID()")
                  .IsRequired();

            builder.Property(x => x.fName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.lName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.profilePictureURL)
                .HasColumnType("VARCHAR")
                .HasMaxLength(2083)
                .IsRequired(false);

            builder.Property(x => x.profileCoverURL)
                .HasColumnType("VARCHAR")
                .HasMaxLength(2083)
                .IsRequired(false);
       
            builder.Property(x => x.cityID)
                .HasColumnType("Int");

            builder.Property(x => x.bio)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160)
                .IsRequired(false);

            builder.Property(x => x.gender)
                .HasColumnType("Bit")
                .HasDefaultValue(Gender.Male)
                .HasConversion(
                    x => x == Gender.Male, // store as bit: true for Male, false for Female
                    x => x ? Gender.Male : Gender.Female // read: true = Male, false = Female
                );

            builder.Property(x => x.dateOfBirth)
                .HasColumnType("Date");

            builder.Property(x => x.joinDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            //One  to One
            //User => Country
            builder.HasOne(x => x.Country)
                .WithMany()
                .HasForeignKey(x => x.countryID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            
            //One  to One
            //User => Country
            builder.HasOne(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.cityID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            //One         to Many
            //User.Sender => FriendRequests
            builder.HasMany(x => x.senderRequests)
                 .WithOne()
                 .HasForeignKey(x => x.senderID)
                 .OnDelete(DeleteBehavior.NoAction);

            ////One           to Many
            //User.Receiver => FriendRequests
            builder.HasMany(x => x.RecoversRequests)
                 .WithOne()
                 .HasForeignKey(x => x.ReceiverID)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.countryID).IsRequired(false);
            builder.Property(x => x.cityID).IsRequired(false);
            builder.Property(x => x.settingId).IsRequired(false);

            //One  to Many
            //User => Posts
            builder.HasMany(x => x.Posts)
                .WithOne()
                .HasForeignKey(x => x.userId);

            //One  to Many
            //User => PostComments
            builder.HasMany(x => x.Comments)
                .WithOne()
                .HasForeignKey(x => x.userId)
                .OnDelete(DeleteBehavior.NoAction);

            //One  to Many
            //Post => PostReactions
            builder.HasMany(x => x.PostReactions)
                .WithOne()
                .HasForeignKey(x => x.userId).OnDelete(DeleteBehavior.NoAction);


            //One  to One
            //User => Setting
            builder.HasOne(x => x.UserSetting)
                .WithMany()
                .HasForeignKey(x => x.settingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            //Many              to One
            //UserInterestField => User
            builder.HasMany(x => x.UserInterestFields)
                .WithOne()
                .HasForeignKey(x =>  x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.UserBlockedFrom)
                .WithOne()
                .HasForeignKey(x => x.BlockerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.UserBlockedUsers)
                .WithOne()
                .HasForeignKey(x => x.BlockedId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
           
            builder.HasMany(x => x.TriggerNotifications)
                .WithOne()
                .HasForeignKey(x => x.TriggeredByUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.ReceiveNotifications)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
