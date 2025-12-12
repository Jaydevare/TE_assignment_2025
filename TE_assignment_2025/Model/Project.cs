using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TE_assignment_2025.Model;

public class Project
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Project Name Cannot be Empty")]
    [StringLength(100)]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description Required")]
    public string Description { get; set; }
    [Required(ErrorMessage = "No of members should be atleast one")]
    public int NoOfMembers { get; set; } = 1;
    public Boolean isActive { get; set; } = true;
    public ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
