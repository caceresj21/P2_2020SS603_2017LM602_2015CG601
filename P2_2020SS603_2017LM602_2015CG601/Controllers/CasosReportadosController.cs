using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020SS603_2017LM602_2015CG601.Models;

namespace P2_2020SS603_2017LM602_2015CG601.Controllers
{
    public class CasosReportadosController : Controller
    {
        private readonly RegistroCovidContext _context;

        public CasosReportadosController(RegistroCovidContext context)
        {
            _context = context;
        }

        // GET: CasosReportados
        public IActionResult Index()
        {
            var listadodepartamentos = (from m in _context.Departamentos
                                        select m).ToList();
            ViewData["listadodepartamentos"] = new SelectList(listadodepartamentos, "id", "nombre");

            var listadogenero = (from m in _context.Generos
                                 select m).ToList();
            ViewData["listadogenero"] = new SelectList(listadogenero, "id", "nombre");

            var listadocovids = (from c in _context.CasosReportados
                                 join d in _context.Departamentos on c.departamento_id equals d.id
                                 join g in _context.Generos on c.genero_id equals g.Id
                                 select new
                                 {
                                     departamentos = d.nombre,
                                     genero = g.Nombre,
                                     confirmados = c.confirmados,
                                     recuperados = c.recuperados,
                                     fallecidos = c.fallecidos,

                                 }).ToList();
            ViewData["listadocovid"] = listadocovids;

            return View();


        }
        public IActionResult CrearDatos(CasosReportados nuevoDato)
        {
            _context.Add(nuevoDato);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}