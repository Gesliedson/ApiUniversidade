using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiUniversidade.Model;
using Microsoft.AspNetCore.Mvc;
using apiUniversidade.Context;
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

    }
}