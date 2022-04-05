using Microsoft.AspNetCore.Mvc;
using Urgencias.Models;

public class PacientesController : Controller
{
    private readonly ApplicationDbContext context;
 
    public PacientesController(ApplicationDbContext context)
    {
        this.context = context;
    }
    public IActionResult Index()
    {
        return View(context.Pacientes.ToList());
    }
 
    [HttpGet]
    public async Task<IActionResult> AddEdit(int id = 0)
    {
        var paciente = await context.Pacientes.FindAsync(id);
        return View(paciente);
    }
 
    [HttpPost]
    public async Task<IActionResult> AddEdit(Paciente paciente)
    {
        if (ModelState.IsValid)
        {
            if (paciente.idPaciente == 0)
                context.Add(paciente);
            else
                context.Update(paciente);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(paciente);
    }
 
 
    public async Task<IActionResult> Delete(int id)
    {
        var paciente = await context.Pacientes.FindAsync(id);
        context.Pacientes.Remove(paciente);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}