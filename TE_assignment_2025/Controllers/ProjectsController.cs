using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TE_assignment_2025.Dal;
using TE_assignment_2025.Model;

namespace TE_assignment_2025.Controllers;

public class ProjectsController : Controller
{
    private readonly TEAssignmentDBContext _dBContext;

    public ProjectsController(TEAssignmentDBContext dBContext) => _dBContext = dBContext;

    public async Task<IActionResult> Index(string search = "" )
    {
        var query = _dBContext.Projects.Include(p => p.ProjectSkills).ThenInclude(p => p.skills).AsQueryable();

        if(!string.IsNullOrWhiteSpace(search) )
        {
            query = query.Where(p => p.Name.Contains(search) || p.Description.Contains(search));
        }

        var list = await query.OrderByDescending(p => p.CreatedAt).ToListAsync();
        ViewBag.Search = search;
        return View(list);
    }

    public async Task<IActionResult> Details(int id)
    {
        var projects = await _dBContext.Projects.Include(p => p.ProjectSkills).ThenInclude(ps => ps.skills).FirstOrDefaultAsync(p => p.Id == id);
        if(projects == null)
            return NotFound();
        return View(projects);
    }

    public IActionResult Create()
    {
        ViewBag.AllSkills = _dBContext.Skills.OrderBy(s => s.SkillName).ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Project project, int[]? selectedSkills)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.AllSkills = _dBContext.Skills.OrderBy(s => s.SkillName).ToList();
            return View(project);
        }

        project.CreatedAt = DateTime.UtcNow;
        if (selectedSkills != null)
        {
            foreach (var sid in selectedSkills.Distinct())
            {
                project.ProjectSkills.Add(new ProjectSkill { SkillId = sid });
            }
        }

        _dBContext.Projects.Add(project);
        await _dBContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var project = await _dBContext.Projects.Include(p => p.ProjectSkills).FirstOrDefaultAsync(ps => ps.Id == id);

        if(project == null)
            return NotFound();

        ViewBag.AllSkills = _dBContext.Skills.OrderBy(s => s.SkillName).ToList();
        ViewBag.SelectedSkillIds = project.ProjectSkills.Select(p => p.SkillId).ToArray();
        return View(project);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Project updated, int[]? selectedSkills)
    {
        if (id != updated.Id)
            return BadRequest();

        if(!ModelState.IsValid)
        {
            ViewBag.AllSkills = _dBContext.Skills.OrderBy(s => s.SkillName).ToList();
            ViewBag.SelectedSkillsId = selectedSkills ?? Array.Empty<int>();
            return View(updated);
        }

        var project = await _dBContext.Projects.Include(p => p.ProjectSkills).FirstOrDefaultAsync(ps => ps.Id == id);
        if(project == null)
            return NotFound();
        project.Name = updated.Name;
        project.Description = updated.Description;
        project.isActive = updated.isActive;
        project.NoOfMembers = updated.NoOfMembers;

        project.ProjectSkills.Clear();
        if(selectedSkills != null)
        {
            foreach(var sid in selectedSkills)
                project.ProjectSkills.Add(new ProjectSkill { ProjectId = id, SkillId = sid });
        }

        await _dBContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _dBContext.Projects.FindAsync(id);

        if (project != null)
        {
            _dBContext.Projects.Remove(project);
            await _dBContext.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
