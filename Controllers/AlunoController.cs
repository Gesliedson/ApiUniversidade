using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Context;
using Microsoft.EntityFrameworkCore;

namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class AlunoController : Controller

    {
        private readonly ILogger<AlunoController> _logger;

         private readonly apiUniversidadeContext _context;

       public AlunoController(ILogger<AlunoController> logger, apiUniversidadeContext context)


        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "alunos")]
        public List<Aluno> getAluno(){
            List<Aluno> alunos = new List<Aluno>();

            Aluno a1 = new Aluno();
            a1.Nome = "Gesliedson";
            a1.Id = 2020;
            a1.DataNascimento = "10-10-2004";
            a1.CPF = "xxx.xxx.xxx-xx";

            alunos.Add(a1);
            
            return alunos;
        }

        [HttpPost]
        public ActionResult Post (Aluno aluno){

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return new CreatedAtRouteResult ("GetAluno", new {id = aluno.Id},aluno);
            
                    
        }


         [HttpGet("{id:int}", Name = "GetAluno")]
        public ActionResult<Aluno> Get(int id)

        {
            var aluno = _context.Alunos.FirstOrDefault(p=>p.Id == id);
            if(aluno is null)
                return NotFound("Curso não encontrado");
            return aluno;

        }


        [HttpPut("id:int")]

        public ActionResult Put ( int id, Aluno aluno){
            if(id != aluno.Id)
                return BadRequest();
            
            _context.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges(); 

            return Ok (aluno);
        }


        [HttpDelete ("{id int}")] 

         public ActionResult Delete(int id) {
            var aluno= _context.Alunos.FirstOrDefault (P=> P.Id == id);

            if (aluno is null) {

                return NotFound();
             }
                _context.Alunos.Remove(aluno);
                _context.SaveChanges();
                return Ok (aluno);
        }

    }
}