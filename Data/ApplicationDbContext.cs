using EduTrack360.Models;
using Microsoft.EntityFrameworkCore;

namespace EduTrack360.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PreparationDomain> PreparationDomains => Set<PreparationDomain>();
        public DbSet<StudyWorkspace> StudyWorkspaces => Set<StudyWorkspace>();

        public DbSet<PreparationOption> PreparationOptions => Set<PreparationOption>();

        public DbSet<StudyTopic> StudyTopics => Set<StudyTopic>();


    }
}
