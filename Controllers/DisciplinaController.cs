using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiUniversidade.Context;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;



namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class DisciplinaController : Controller

    {
        private readonly ILogger<DisciplinaController> _logger;

         private readonly apiUniversidadeContext _context;

        public DisciplinaController(ILogger<DisciplinaController> logger, apiUniversidadeContext context)


        {
            _logger = logger;
            _context = context;

        }

        [HttpGet(Name = "disciplinas")]
        public List<Disciplina> GetDisciplina(){
            List<Disciplina> Disciplinas = new List<Disciplina>();

            Disciplina d1 = new Disciplina();
            d1.Nome = "programação para internet";
            d1.CargaHoraria = 60;
            d1.Semestre = 8;

            Disciplina d2 = new Disciplina();
            d2.Nome = "projeto de Software";
            d2.CargaHoraria = 60;
            d2.Semestre = 8;

            Disciplina d3 = new Disciplina();
            d3.Nome = "Autoria Web";
            d3.CargaHoraria = 60;
            d3.Semestre = 8;

            Disciplinas.Add(d1);
            Disciplinas.Add(d2);
            Disciplinas.Add(d3);

            return Disciplinas;
        }

        [HttpPost]
        public ActionResult Post (Disciplina disciplina){

            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();

            return new CreatedAtRouteResult ("GetDisciplina", new {id = disciplina.Id},disciplina);
            
                    
        }


         [HttpGet("{id:int}", Name = "GetDisciplina")]
        public ActionResult<Disciplina> Get(int id)

        {
            var disciplina = _context.Disciplinas.FirstOrDefault(p=>p.Id == id);
            if(disciplina is null)
                return NotFound("Disciplina não encontrado");
            return disciplina;

        }


        [HttpPut("id:int")]

        public ActionResult Put ( int id, Disciplina disciplina){
            if(id != disciplina.Id)
                return BadRequest();
            
            _context.Entry(disciplina).State = EntityState.Modified;
            _context.SaveChanges(); 

            return Ok (disciplina);
        }


        [HttpDelete ("{id int}")] 

         public ActionResult Delete(int id) {
            var disciplina= _context.Disciplinas.FirstOrDefault (P=> P.Id == id);

            if (disciplina is null) {

                return NotFound();
             }
                _context.Disciplinas.Remove(disciplina);
                _context.SaveChanges();
                return Ok (disciplina);
        }

    }
}