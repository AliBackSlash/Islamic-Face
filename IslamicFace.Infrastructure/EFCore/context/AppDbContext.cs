using IslamicFace.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace IslamicFace.Infrastructure.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostMedia> PostMedias { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }


        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            Builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
