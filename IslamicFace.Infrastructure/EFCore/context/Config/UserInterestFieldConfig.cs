namespace IslamicFace.Infrastructure.context.Config
{
    public class UserInterestFieldConfig : IEntityTypeConfiguration<UserInterestField>
    {
        public void Configure(EntityTypeBuilder<UserInterestField> builder)
        {
            builder.ToTable("UserInterestFields");
            builder.HasKey(ub => new { ub.UserId, ub.InterestFieldId });
            builder.Property(x => x.UserId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.InterestFieldId).HasColumnType("TINYINT").IsRequired();


        }
 
    }
}
