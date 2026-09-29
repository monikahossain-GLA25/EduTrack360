using EduTrack360.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduTrack360.Models;

public class StudyTopic
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public TopicStatus Status { get; set; }
        = TopicStatus.NotStarted;

    public PriorityLevel Priority { get; set; }
        = PriorityLevel.Medium;

    [Range(0, 1000)]
    public double PlannedHours { get; set; }

    [Range(0, 1000)]
    public double ActualHours { get; set; }

    [DataType(DataType.Date)]
    public DateTime? TargetDate { get; set; }

    public int StudyWorkspaceId { get; set; }

    public StudyWorkspace? StudyWorkspace { get; set; }

    public int? ParentTopicId { get; set; }

    public StudyTopic? ParentTopic { get; set; }

    public ICollection<StudyTopic> SubTopics { get; set; }
        = new List<StudyTopic>();
}