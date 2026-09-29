using System.ComponentModel.DataAnnotations;

namespace EduTrack360.Models;

    public class PreparationDomain
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string OptionLabel { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public ICollection<PreparationOption> Options { get; set; }
            = new List<PreparationOption>();

        public ICollection<StudyWorkspace> Workspaces { get; set; }
            = new List<StudyWorkspace>();
    }

