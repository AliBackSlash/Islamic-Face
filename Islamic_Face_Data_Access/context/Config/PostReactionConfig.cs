using Islamic_Face_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Islamic_Face_Data_Access.context.Config
{
    public class PostReactionConfig : IEntityTypeConfiguration<PostReaction>
    {
        public void Configure(EntityTypeBuilder<PostReaction> builder)
        {
            builder.ToTable("PostReactions");
            builder.HasKey(x => new { x.userId, x.postId });


            builder.Property(x => x.userId)
              .HasColumnType("BigInt")
              .IsRequired();

            builder.Property(x => x.postId)
              .HasColumnType("BigInt")
              .IsRequired();


            builder.HasOne(x => x.Reaction)
                .WithOne(x => x.PostReaction)
                .HasForeignKey<PostReaction>(x => x.reactTypeID);

        }
    }
}
