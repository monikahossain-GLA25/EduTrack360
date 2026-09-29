using System.ComponentModel.DataAnnotations;

namespace EduTrack360.Models;

    public class StudyWorkspace
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(300)]
        public string? Goal { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime? TargetDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Selected top-level domain:
        // University, Job Preparation, BCS, etc.
        public int PreparationDomainId { get; set; }

        public PreparationDomain? PreparationDomain { get; set; }

        // Selected predefined option:
        // CSE, .NET Developer, Bank IT, etc.
        public int? PreparationOptionId { get; set; }

        public PreparationOption? PreparationOption { get; set; }

        // Used when user selects "Other"
        [StringLength(100)]
        public string? CustomOptionName { get; set; }

        public ICollection<StudyTopic> Topics { get; set; }
            = new List<StudyTopic>();
    }

