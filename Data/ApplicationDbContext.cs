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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudyTopic>()
                .HasOne(x => x.ParentTopic)
                .WithMany(x => x.SubTopics)
                .HasForeignKey(x => x.ParentTopicId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedPreparationData(modelBuilder);
        }
        private static void SeedPreparationData(
        ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PreparationDomain>().HasData(

                new PreparationDomain
                {
                    Id = 1,
                    Name = "University Study",
                    OptionLabel = "Department"
                },

                new PreparationDomain
                {
                    Id = 2,
                    Name = "Job Preparation",
                    OptionLabel = "Career Track"
                },

                new PreparationDomain
                {
                    Id = 3,
                    Name = "Bank Job Preparation",
                    OptionLabel = "Job Type"
                },

                new PreparationDomain
                {
                    Id = 4,
                    Name = "BCS Preparation",
                    OptionLabel = "Preparation Stage"
                },

                new PreparationDomain
                {
                    Id = 5,
                    Name = "Language Learning",
                    OptionLabel = "Language"
                },

                new PreparationDomain
                {
                    Id = 6,
                    Name = "Higher Studies Preparation",
                    OptionLabel = "Study Goal"
                }
            );

            modelBuilder.Entity<PreparationOption>().HasData(

                // University

                new PreparationOption
                {
                    Id = 1,
                    Name = "CSE",
                    PreparationDomainId = 1
                },

                new PreparationOption
                {
                    Id = 2,
                    Name = "EEE",
                    PreparationDomainId = 1
                },

                new PreparationOption
                {
                    Id = 3,
                    Name = "Civil Engineering",
                    PreparationDomainId = 1
                },

                new PreparationOption
                {
                    Id = 4,
                    Name = "Pharmacy",
                    PreparationDomainId = 1
                },

                new PreparationOption
                {
                    Id = 5,
                    Name = "BBA",
                    PreparationDomainId = 1
                },

                new PreparationOption
                {
                    Id = 6,
                    Name = "Microbiology",
                    PreparationDomainId = 1
                },

                // Job Preparation

                new PreparationOption
                {
                    Id = 7,
                    Name = "C#/.NET Developer",
                    PreparationDomainId = 2
                },

                new PreparationOption
                {
                    Id = 8,
                    Name = "Java Developer",
                    PreparationDomainId = 2
                },

                new PreparationOption
                {
                    Id = 9,
                    Name = "Python Developer",
                    PreparationDomainId = 2
                },

                new PreparationOption
                {
                    Id = 10,
                    Name = "DevOps Engineer",
                    PreparationDomainId = 2
                },

                // Bank

                new PreparationOption
                {
                    Id = 11,
                    Name = "Bank IT",
                    PreparationDomainId = 3
                },

                new PreparationOption
                {
                    Id = 12,
                    Name = "Officer",
                    PreparationDomainId = 3
                },

                // BCS

                new PreparationOption
                {
                    Id = 13,
                    Name = "Preliminary",
                    PreparationDomainId = 4
                },

                new PreparationOption
                {
                    Id = 14,
                    Name = "Written",
                    PreparationDomainId = 4
                },

                new PreparationOption
                {
                    Id = 15,
                    Name = "Viva",
                    PreparationDomainId = 4
                },

                // Language

                new PreparationOption
                {
                    Id = 16,
                    Name = "English",
                    PreparationDomainId = 5
                },

                new PreparationOption
                {
                    Id = 17,
                    Name = "Japanese",
                    PreparationDomainId = 5
                },

                new PreparationOption
                {
                    Id = 18,
                    Name = "German",
                    PreparationDomainId = 5
                },

                // Higher Studies

                new PreparationOption
                {
                    Id = 19,
                    Name = "IELTS",
                    PreparationDomainId = 6
                },

                new PreparationOption
                {
                    Id = 20,
                    Name = "GRE",
                    PreparationDomainId = 6
                },

                new PreparationOption
                {
                    Id = 21,
                    Name = "Masters Admission",
                    PreparationDomainId = 6
                },

                new PreparationOption
                {
                    Id = 22,
                    Name = "PhD Admission",
                    PreparationDomainId = 6
                }
            );
        }
    }
}
