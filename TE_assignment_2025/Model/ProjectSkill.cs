using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TE_assignment_2025.Model;

public class ProjectSkill
{
    public int ProjectId { get; set; }
    public Project project { get; set; }

    public int SkillId { get; set; }
    public Skills skills { get; set; }
}
