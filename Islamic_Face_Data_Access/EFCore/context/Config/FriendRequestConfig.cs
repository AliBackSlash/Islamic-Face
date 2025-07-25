using IslamicFace.Infrastructure.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IslamicFace.Infrastructure.EFCore.context.Config
{
    public class FriendRequestConfig : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.ToTable("FriendRequests");
            builder.HasKey(x => x.Id)
                .HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Id)
                   .HasColumnType("BigInt")
                   .IsRequired();
           
            //make it unique
            builder.HasIndex(x => new { x.senderID, x.ReceiverID })
                .IsUnique();
                

            builder.Property(x => x.senderID)
                .HasColumnType("BigInt")               
                .IsRequired();
           
            builder.Property(x => x.ReceiverID)
                .HasColumnType("BigInt")               
                .IsRequired();

            builder.Property(x => x.RequestStatus)
               .HasColumnType("TinyInt")
               .IsRequired();
            
            builder.Property(x => x.ResponseAt)
               .HasColumnType("DateTime")
               .IsRequired(false);

            builder.Property(x => x.DateSend)
               .HasColumnType("DateTime")
               .HasDefaultValueSql("GETDATE()")
               .IsRequired();



        }
    }
}
