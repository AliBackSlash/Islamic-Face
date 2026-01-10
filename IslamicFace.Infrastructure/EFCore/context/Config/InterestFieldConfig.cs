namespace IslamicFace.Infrastructure.context.Config
{
    public class InterestFieldConfig : IEntityTypeConfiguration<InterestField>
    {
        public void Configure(EntityTypeBuilder<InterestField> builder)
        {
            builder.ToTable("InterestFields");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("TINYINT");
            builder.Property(x => x.FieldName_ENG).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();
            builder.Property(x => x.FieldName_ARB).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.userInterestFields)
                .WithOne(x => x.InterestField)
                .HasForeignKey(x => x.InterestFieldId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
            new InterestField { Id = 1, FieldName_ENG = "Science", FieldName_ARB = "العلوم" },
            new InterestField { Id = 2, FieldName_ENG = "Technology", FieldName_ARB = "التكنولوجيا" },
            new InterestField { Id = 3, FieldName_ENG = "Education", FieldName_ARB = "التعليم" },
            new InterestField { Id = 4, FieldName_ENG = "Sports", FieldName_ARB = "الرياضة" },
            new InterestField { Id = 5, FieldName_ENG = "Agriculture", FieldName_ARB = "الزراعة" },
            new InterestField { Id = 6, FieldName_ENG = "Arts", FieldName_ARB = "الفنون" },
            new InterestField { Id = 7, FieldName_ENG = "Health", FieldName_ARB = "الصحة" },
            new InterestField { Id = 8, FieldName_ENG = "Business", FieldName_ARB = "الأعمال" },
            new InterestField { Id = 9, FieldName_ENG = "Religion", FieldName_ARB = "الدين" },
            new InterestField { Id = 10, FieldName_ENG = "Politics", FieldName_ARB = "السياسة" });

        }
    }
}
