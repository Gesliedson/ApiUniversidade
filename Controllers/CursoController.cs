using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}