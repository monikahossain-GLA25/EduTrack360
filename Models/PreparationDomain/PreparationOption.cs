using System.ComponentModel.DataAnnotations;

namespace EduTrack360.Models;

public class PreparationOption
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public bool IsSystemDefined { get; set; } = true;

    public bool IsActive { get; set; } = true;

    public int PreparationDomainId { get; set; }

    public PreparationDomain? PreparationDomain { get; set; }

    public ICollection<StudyWorkspace> Workspaces { get; set; }
        = new List<StudyWorkspace>();
}