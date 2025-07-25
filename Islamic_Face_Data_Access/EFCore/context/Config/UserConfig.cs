using IslamicFace.Infrastructure.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IslamicFace.Infrastructure.EFCore.context.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Id)
                   .HasColumnType("BigInt")
                   .IsRequired();

            builder.Property(x => x.userName)
                .HasColumnType("VARCHAR") 
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(x => x.password)
                .HasColumnType("VARCHAR")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.profilePictureURL)
                .HasColumnType("VARCHAR")
                .HasMaxLength(2083)
                .IsRequired();

            builder.Property(x => x.email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(x => x.city)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
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
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.countryID)
                .OnDelete(DeleteBehavior.Restrict);

            //One         to Many
            //User.Sender => FriendRequests
            builder.HasMany(x => x.senderRequests)
                 .WithOne(x => x.Sender)
                 .HasForeignKey(x => x.senderID)
                 .OnDelete(DeleteBehavior.NoAction);

            ////One           to Many
            //User.Receiver => FriendRequests
            builder.HasMany(x => x.RecoversRequests)
                 .WithOne(x => x.Receiver)
                 .HasForeignKey(x => x.ReceiverID)
                 .OnDelete(DeleteBehavior.NoAction);



            //One  to Many
            //User => Posts
            builder.HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.userId);

            //One  to Many
            //User => PostComments
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.userId);

            //One  to Many
            //Post => PostReactions
            builder.HasMany(x => x.PostReactions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.userId);


            //One  to One
            //User => Setting
            builder.HasOne(x => x.UserSetting)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.settingId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
