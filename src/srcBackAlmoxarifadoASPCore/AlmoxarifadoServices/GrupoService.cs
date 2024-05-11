using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class GrupoService
    {
        //instalaer o pacote do autoMapper
        private readonly IGrupoRepository _grupoRepository;
        private readonly MapperConfiguration mapperConfiguration;
        public GrupoService(IGrupoRepository pGrupoRepository)
        {
            _grupoRepository = pGrupoRepository;
            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Grupo, GrupoGetDTO>();
                cfg.CreateMap<GrupoGetDTO, Grupo>();
            });
        }

        public List<GrupoGetDTO> ObterTodosProdutos()
        {
            //exemplo sem alto mapper

            /*var dados = _grupoRepository.ObterTodosGrupos();
            List<GrupoGetDTO> lista = new List<GrupoGetDTO>();
            foreach (var item in dados)
            {
                GrupoGetDTO Model = new GrupoGetDTO
                {
                    ID_GRU = item.ID_GRU,
                    NOME_GRU = item.NOME_GRU,
                    SUGESTAO_GRU = item.SUGESTAO_GRU
                };
                lista.Add(Model);
            }
            return lista;*/

            //exemplo com alto mapper

            var mapper = mapperConfiguration.CreateMapper();

            return mapper.Map<List<GrupoGetDTO>>(_grupoRepository.ObterTodosGrupos());
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
