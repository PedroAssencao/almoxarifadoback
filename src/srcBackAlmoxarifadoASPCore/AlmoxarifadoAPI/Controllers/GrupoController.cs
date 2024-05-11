using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using Microsoft.AspNetCore.Mvc;
using AlmoxarifadoServices.DTO;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoController : ControllerBase
    {
        private readonly GrupoService _grupoService;
        public GrupoController(GrupoService grupoService)
        {
            _grupoService = grupoService;
        }

  
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var grupos = _grupoService.ObterTodosProdutos();
                return Ok(grupos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
         
        }

        [HttpGet("/Grupo/{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var grupo = _grupoService.ObterGrupoPorID(id);
                if (grupo == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(grupo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpPost]
        public IActionResult CriarGrupo(GrupoPostDTO Model)
        {
            try
            {
                var dados = _grupoService.CriarGrupo(Model);
                return Ok(dados);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao tentar adicionar dados. Por favor, tente novamente mais tarde.");
            }

        }
    }
}
