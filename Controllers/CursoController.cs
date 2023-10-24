using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using apiUniversidade.Context;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;

namespace apiUniversidade.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CursoController : Controller
    {
       private readonly ILogger<CursoController> _logger;
         private readonly apiUniversidadeContext _context;
         public CursoController(ILogger<CursoController> logger, apiUniversidadeContext context)
         {
            _logger = logger;
            _context = context;
         }
        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            var Cursos = _context.Cursos.ToList();
            if (Cursos is null)
                return NotFound();
            
            return Cursos;

        }   

        [HttpPost]
        public ActionResult Post (Curso curso){
            _context.Cursos.Add(curso);
            _context.SaveChanges();

            return new CreatedAtRouteResult ("GetCurso", new {id = curso.Id},curso);

        }

        //PROCURA ALGO NO BANCO DE DADOS. RETORNA NULO SE NÃO ENCONTRAR NADA

        [HttpGet("{id:int}", Name = "GetCurso")]
        public ActionResult<Curso> Get(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(p=>p.Id == id);
            if(curso is null)
                return NotFound("Curso não encontrado");
            return curso;
            
        }
    }
}