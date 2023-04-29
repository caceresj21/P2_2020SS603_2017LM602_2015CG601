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
            private readonly RegistroCovidContext _covidDbContext;
            public CasosReportadosController(RegistroCovidContext covidDbContext)
            {
                _covidDbContext = covidDbContext;
            }

            public IActionResult Index()
            {

            var listadodepartamentos = (from m in _covidDbContext.Departamentos
                                        select m).ToList();
            ViewData["listadodepartamentos"] = new SelectList(listadodepartamentos, "id", "nombre");

            var listadodegeneros = (from m in _covidDbContext.Generos
                                    select m).ToList();
            ViewData["listadodegeneros"] = new SelectList(listadodegeneros, "Id", "Nombre");
            var listadoCaso = (from c in _covidDbContext.CasosReportados
                                   join d in _covidDbContext.Departamentos on c.departamento_id equals d.id
                                   join g in _covidDbContext.Generos on c.genero_id equals g.Id
                                   select new
                                   {
                                       departamentos = d.nombre,
                                       genero = g.Nombre,
                                       confirmados = c.confirmados,
                                       recuperados = c.recuperados,
                                       fallecidos = c.fallecidos,

                                   }).ToList();
                ViewData["listadoCaso"] = listadoCaso;

                return View();

            }
            public IActionResult CrearDatos(CasosReportados nuevoDato)
            {
                _covidDbContext.Add(nuevoDato);
                _covidDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }

