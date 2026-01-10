namespace IslamicFace.Infrastructure.context.Config
{
    public class UserBlockConfig : IEntityTypeConfiguration<UserBlock>
    {
        public void Configure(EntityTypeBuilder<UserBlock> builder)
        {
            builder.ToTable("UserBlocks");
            builder.HasKey(ub => new { ub.BlockerId, ub.BlockedId });
            builder.Property(x => x.BlockerId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.BlockedId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.IsBlocked).HasColumnType("BIT").HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME").HasDefaultValueSql("GETUTCDATE()");


        }
    }
}
