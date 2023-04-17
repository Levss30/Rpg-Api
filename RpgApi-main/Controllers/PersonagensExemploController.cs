using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExemploController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Alice", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Chapeleiro", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Coelho Branco", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Rainha de Copas", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Rainha Branca", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Cheshire", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Valete de Copas", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 8, Nome = "Absolem", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetAll")]
        public IActionResult Get() {
            return Ok(personagens);
        }

        [HttpGet("Get")]
        public IActionResult GetFirst() {
            return Ok(personagens[0]);
        }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem() {
            List<Personagem> listaFinal = personagens.OrderBy(p => p.Forca).ToList();
            return Ok(listaFinal);
        }

        [HttpGet("GetContagem")]
        public IActionResult GetQuantidade() {
            return Ok("Quantidade de personagens: " + personagens.Count);
        }

        [HttpGet("GetSemCavaleiro")]
        public IActionResult GetSemCavaleiro() {
            List<Personagem> listaBusca = personagens.FindAll(pe => pe.Classe != ClasseEnum.Cavaleiro);
            return Ok(listaBusca);
        }

        [HttpGet("GetNomeAproximado/{nome}")]
        public IActionResult GetByNomeAproximado(string nome) {
            List<Personagem> listaBusca = personagens.FindAll(pe => pe.Nome.Contains(nome));
            return Ok(listaBusca);
        }

        [HttpGet("GetRemovendoMago")]
        public IActionResult GetRemovendoMagos() {
            Personagem? pRemove = personagens.Find(pe => pe.Classe == ClasseEnum.Mago);
            if(pRemove != null) {
                personagens.Remove(pRemove);
                return Ok("Personagem removido: " + pRemove.Nome);
            } else
                return Ok("Não há magos para remover");
        }

        [HttpGet("GetByForca/{forca}")]
        public IActionResult GetByForca(int forca) {
            Personagem? personagem = personagens.Find(p => p.Forca == forca);
            return Ok(personagem);
        }

        [HttpGet("GetByEnum/{enumId}")]
        public IActionResult GetByEnum(int enumId) {
            //Conversao explicita de int para enum
            ClasseEnum enumDigitado = (ClasseEnum)enumId;

            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe == enumDigitado);

            return Ok(listaBusca);
        }

        [HttpGet("GetSomaForca")]
        public IActionResult GetSomaForca() {
            return Ok(personagens.Sum(pe => pe.Forca));
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id) {
            return Ok(personagens.FirstOrDefault(pe => pe.Id == id));
        }

        [HttpPost]
        public IActionResult AddPersonagem(Personagem novoPersonagem) {
            if (novoPersonagem.Inteligencia == 0)
                return BadRequest("Inteligência não pode ter o valor igual a 0 (zero).");
            
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpPut]
        public IActionResult UpdatePersonagem(Personagem p) {
            Personagem? personagemAlterado = personagens.Find(pe => pe.Id == p.Id);
            if(personagemAlterado != null) {
                personagemAlterado.Nome = p.Nome;
                personagemAlterado.PontosVida = p.PontosVida;
                personagemAlterado.Forca = p.Forca;
                personagemAlterado.Defesa = p.Defesa;
                personagemAlterado.Inteligencia = p.Inteligencia;
                personagemAlterado.Classe = p.Classe;
                return Ok(personagens);
            } else
                return BadRequest("Não existe um personagem com esse ID");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            personagens.RemoveAll(pe => pe.Id == id);
            return Ok(personagens);
        }
    }
}
