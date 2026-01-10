namespace IslamicFace.Infrastructure.context.Config
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.Property(x => x.Id).HasColumnType("UNIQUEIDENTIFIER").HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(x => x.UserId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.TriggeredByUserId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.PostId).HasColumnType("UNIQUEIDENTIFIER").IsRequired(false);
            builder.Property(x => x.CommentId).HasColumnType("UNIQUEIDENTIFIER").IsRequired(false);
            builder.Property(x => x.Type).HasColumnType("TINYINT").IsRequired();
            builder.Property(x => x.IsRead).HasColumnType("BIT").HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasColumnType("DATETIME").HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.NotificationURL).HasColumnType("VARCHAR").HasMaxLength(2083).IsRequired();
        }
    }
}
