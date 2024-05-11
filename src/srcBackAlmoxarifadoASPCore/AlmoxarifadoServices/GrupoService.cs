using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class GrupoService
    {
        private readonly IGrupoRepository _grupoRepository;

        public GrupoService(IGrupoRepository pGrupoRepository)
        {
            _grupoRepository = pGrupoRepository;
        }

        public List<Grupo> ObterTodosProdutos()
        {
            return _grupoRepository.ObterTodosGrupos();
        }

        public Grupo ObterGrupoPorID(int id)
        {
            return _grupoRepository.ObterGrupoPorId(id);
        }

        public GrupoGetDTO CriarGrupo(GrupoPostDTO Model)
        {
            var dados = _grupoRepository.CriarGrupo(
                 new Grupo()
                 {
                     NOME_GRU = Model.NOME_GRU,
                     SUGESTAO_GRU = Model.SUGESTAO_GRU
                 }

                 );

            return new GrupoGetDTO()
            {
                ID_GRU = dados.ID_GRU,
                NOME_GRU = dados.NOME_GRU,
                SUGESTAO_GRU = dados.SUGESTAO_GRU
            };
        }

    }
}
