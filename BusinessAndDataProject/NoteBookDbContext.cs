using BusinessAndDataProject.Models;
using Microsoft.EntityFrameworkCore;


namespace BusinessAndDataProject
{
    public class NoteBookDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        private const string connectionString = "Data Source=DB\\Database.db"; //hate this hardcoded string, could probably inject iconfiguration from the web project and insert here at some point

        public NoteBookDbContext(DbContextOptions<NoteBookDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
