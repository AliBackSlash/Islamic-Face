using Islamic_Face_Data_Access.Entities;
using Islamic_Face_Data_Access.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Islamic_Face_Data_Access.context.Config
{
    public class ReactionConfig : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.ToTable("Reactions");
            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1"); 

            builder.Property(x => x.Id)
              .HasColumnType("TinyInt")
              .IsRequired();

            builder.Property(x => x.ReactType)
               .HasConversion(
                    x => x.ToString(),
                    x => (ReactType)Enum.Parse(typeof(ReactType), x)
               );

        }
    }
}
