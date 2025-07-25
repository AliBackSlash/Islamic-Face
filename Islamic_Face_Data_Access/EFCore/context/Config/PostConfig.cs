using IslamicFace.Infrastructure.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IslamicFace.Infrastructure.EFCore.context.Config
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Id)
                   .HasColumnType("BigInt")
                   .IsRequired();

            builder.Property(x => x.postText)
                .HasColumnType("VARCHAR")
                .HasMaxLength(500)
                .IsRequired();
           
            builder.Property(x => x.userId)
                .HasColumnType("BigInt")
                .IsRequired();

            builder.Property(x => x.createdAt)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            ////One  to Many
            ////Post => PostComments
            builder.HasMany(x => x.PostComments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.postId);

            //One  to Many
            //Post => PostMedias
            builder.HasMany(x => x.PostMedias)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.postId);

            //One  to Many
            //Post => PostReactions
            builder.HasMany(x => x.PostReactions)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.postId);

            //One  to Many
            //Post => PostTags
            builder.HasMany(x => x.PostTags)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.postId);

        }
    }
}
