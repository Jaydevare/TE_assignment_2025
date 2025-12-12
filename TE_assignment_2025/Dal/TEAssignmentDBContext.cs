using Microsoft.EntityFrameworkCore;
using TE_assignment_2025.Model;

namespace TE_assignment_2025.Dal;

public class TEAssignmentDBContext : DbContext
{
    public TEAssignmentDBContext(DbContextOptions<TEAssignmentDBContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<ProjectSkill> ProjectSkills { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectSkill>().HasKey(ps => new { ps.ProjectId , ps.SkillId});

        modelBuilder.Entity<ProjectSkill>().HasOne(ps => ps.project).WithMany(p => p.ProjectSkills).HasForeignKey(ps => ps.ProjectId);

        modelBuilder.Entity<ProjectSkill>().HasOne(ps => ps.skills).WithMany(s => s.ProjectSkills).HasForeignKey(ps => ps.SkillId);

        modelBuilder.Entity<Skills>().HasData(
            new TE_assignment_2025.Model.Skills{SkillsId = 1, SkillName = "Asp.Net" },
            new TE_assignment_2025.Model.Skills { SkillsId = 2, SkillName = "Java" },
            new TE_assignment_2025.Model.Skills { SkillsId = 3, SkillName = "PHP" },
            new TE_assignment_2025.Model.Skills { SkillsId = 4, SkillName = "Python" },
            new TE_assignment_2025.Model.Skills { SkillsId = 5, SkillName = "React-js" },
            new TE_assignment_2025.Model.Skills { SkillsId = 6, SkillName = "Web-Java" },
            new TE_assignment_2025.Model.Skills { SkillsId = 7, SkillName = "Node-js" },
            new TE_assignment_2025.Model.Skills { SkillsId = 8, SkillName = "MySQL" },
            new TE_assignment_2025.Model.Skills { SkillsId = 9, SkillName = "Flutter" },
            new TE_assignment_2025.Model.Skills { SkillsId = 10, SkillName = "CSharp" },
            new TE_assignment_2025.Model.Skills { SkillsId = 11, SkillName = "HTML" },
            new TE_assignment_2025.Model.Skills { SkillsId = 12, SkillName = "CSS" },
            new TE_assignment_2025.Model.Skills { SkillsId = 13, SkillName = "javaScript/Jquery" },
            new TE_assignment_2025.Model.Skills { SkillsId = 14, SkillName = "MongoDB" },
            new TE_assignment_2025.Model.Skills { SkillsId = 15, SkillName = "Asp.Net-core" },
            new TE_assignment_2025.Model.Skills { SkillsId = 16, SkillName = "Next-js" }
            );

        base.OnModelCreating(modelBuilder);
    }
}
