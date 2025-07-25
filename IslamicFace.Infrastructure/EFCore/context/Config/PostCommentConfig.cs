using IslamicFace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IslamicFace.Infrastructure.context.Config
{
    public class PostCommentConfig : IEntityTypeConfiguration<PostComment>
    {
        
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.ToTable("PostComments");

            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Id)
                .HasColumnType("BigInt")
                .IsRequired();

            builder.Property(x => x.userId)
                .HasColumnType("BigInt")
                .IsRequired();

            builder.Property(x => x.postId)
                .HasColumnType("BigInt")
                .IsRequired();

            builder.Property(x => x.ParentCommentID)
                .HasColumnType("BigInt")
                .IsRequired(false);
            
            builder.Property(x => x.Comment)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.reactLikeCount)
              .HasColumnType("int")
              .IsRequired();

            builder.Property(x => x.createdAt)
              .HasColumnType("DateTime")
               .HasDefaultValueSql("GETDATE()")
              .IsRequired();


            builder.HasMany(x => x.Post_Comments)
                .WithOne(x => x.comment)
                .HasForeignKey(x => x.ParentCommentID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
