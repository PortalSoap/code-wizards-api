using code_wizards_api.Data.Map;
using code_wizards_api.Models;
using Microsoft.EntityFrameworkCore;

namespace code_wizards_api.Data
{
    public class NotesSystemDbContext : DbContext
    {
        public NotesSystemDbContext(DbContextOptions<NotesSystemDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<NoteModel> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new NoteMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}