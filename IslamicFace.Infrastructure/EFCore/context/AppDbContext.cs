

using Microsoft.AspNetCore.Identity;

namespace IslamicFace.Infrastructure.context
{
    public class AppDbContext : IdentityDbContext<AppUser,IdentityRole<Guid>,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries => Set<Country>();
        public DbSet<FriendRequest> FriendRequests => Set<FriendRequest>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<PostComment> PostComments => Set<PostComment>();
        public DbSet<PostMedia> PostMedias => Set<PostMedia>();
        public DbSet<PostReaction> PostReactions => Set<PostReaction>();
        public DbSet<PostTag> PostTags => Set<PostTag>();
        public DbSet<Reaction> Reactions => Set<Reaction>();
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<UserSetting> UserSettings => Set<UserSetting>();
        public DbSet<UserInterestField> UserInterestFields => Set<UserInterestField>();
        public DbSet<InterestField> InterestFields => Set<InterestField>();
        public DbSet<UserBlock> UserBlocks => Set<UserBlock>();
        public DbSet<Notification> Notifications => Set<Notification>();

        

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            Builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
