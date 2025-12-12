namespace TE_assignment_2025.Model;

public class Skills
{
    public int SkillsId { get; set; }
    public String SkillName { get; set; }
    public ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();
}
