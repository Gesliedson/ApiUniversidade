using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;

namespace apiUniversidade.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CursoController : Controller
    {
       private readonly ILogger<CursoController> _logger;

        public CursoController(ILogger<CursoController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            var Cursos = context.Cursos.ToList();
            if (Cursos is null)
                return NotFound();
            
            return Cursos;
            
        }       
    }
}