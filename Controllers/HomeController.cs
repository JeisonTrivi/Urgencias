
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urgencias.Models;

namespace Urgencias.Controllers;

public class HomeController : Controller
{
    private ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    //Consulta  Datos
    public IActionResult Index()
    {
        return View(_context.Pacientes.ToList());
    }

    public IActionResult Registro()
    {
        return View();
    }


    //Insertar un nuevo paciente
    [HttpPost]
    public IActionResult Registro(Paciente pacientes)
    {
        if (ModelState.IsValid)
        {
            pacientes.calculoEdad(pacientes.FechaNacimiento);
            pacientes.Atendido = true;
            _context.Pacientes.Add(pacientes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(pacientes);
        }
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(int id = 0)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        return View(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> AddEdit(Paciente paciente)
    {
        if (ModelState.IsValid)
        {
            if (paciente.idPaciente == 0)
            {
                paciente.calculoEdad(paciente.FechaNacimiento);
                _context.Add(paciente);

            }
            else
                paciente.calculoEdad(paciente.FechaNacimiento);
            paciente.Atendido = true;
            _context.Update(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(paciente);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

     public IActionResult getPaciente()
    {
        return View();
    }
    
    [HttpGet("getPaciente/{Nombre}")]
    public async Task<IActionResult> getPaciente(string Nombre){
        Console.WriteLine(Nombre);
        var paciente = await _context.Pacientes.FindAsync(Nombre);
        return View(paciente);

    }
}


