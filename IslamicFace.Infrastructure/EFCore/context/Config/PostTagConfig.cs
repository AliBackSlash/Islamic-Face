using IslamicFace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IslamicFace.Infrastructure.context.Config
{
    public class PostTagConfig : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.ToTable("PostTags");
            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Id)
              .HasColumnType("BigInt")
              .IsRequired();

            builder.Property(x => x.postId)
               .HasColumnType("BigInt")
               .IsRequired();

            builder.Property(x => x.tag)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();
           
        }
    }
}
