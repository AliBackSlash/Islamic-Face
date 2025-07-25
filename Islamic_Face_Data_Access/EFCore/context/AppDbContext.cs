using IslamicFace.Infrastructure.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace IslamicFace.Infrastructure.EFCore.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Country> Countries => Set<Country>();
        public DbSet<FriendRequest> FriendRequests => Set<FriendRequest>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<PostComment> PostComments => Set<PostComment>();
        public DbSet<PostMedia> PostMedias => Set<PostMedia>();
        public DbSet<PostReaction> PostReactions => Set<PostReaction>();
        public DbSet<PostTag> PostTags => Set<PostTag>();
        public DbSet<Reaction> Reactions => Set<Reaction>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserSetting> UserSettings => Set<UserSetting>();

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            Builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
