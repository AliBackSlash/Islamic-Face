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

           

           

            builder.Property(x => x.name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.profilePictureURL)
                .HasColumnType("VARCHAR")
                .HasMaxLength(2083)
                .IsRequired();
       
            builder.Property(x => x.cityID)
                .HasColumnType("Int")
                .IsRequired();

            builder.Property(x => x.bio)
                .HasColumnType("VARCHAR")
                .HasMaxLength(160)
                .IsRequired();

            builder.Property(x => x.gender)
                .HasColumnType("Bit")
                .IsRequired();

            builder.Property(x => x.dateOfBirth)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(x => x.joinDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();
           
            builder.Property(x => x.userType)
                .HasColumnType("TinyInt")               
                .IsRequired();

            //One  to One
            //User => Country
            builder.HasOne(x => x.Country)
                .WithMany()
                .HasForeignKey(x => x.countryID)
                .OnDelete(DeleteBehavior.Restrict);

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
                .WithOne()
                .HasForeignKey<AppUser>(x => x.settingId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
