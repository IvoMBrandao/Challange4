using AutoMapper;
using Challange4.Data.Dtos;
using Challange4.Models;

namespace Challange4.Profiles
{
    public class FinanceProfile: Profile
    {
        public FinanceProfile()
        {
            CreateMap<CreateFinancaDto, Receitas>();
            CreateMap<UpdateFinancaDto, Receitas>();
            CreateMap<Receitas,UpdateFinancaDto>();
            CreateMap<Receitas, ReadFinancaDto>();
            CreateMap<ReadFinancaDto,Receitas>();
            CreateMap<List<ReadFinancaDto>,Receitas>();
            CreateMap<List<ReadFinancaDto>,Despesas>();
            CreateMap<Despesas, ReadFinancaDto>();
            CreateMap<ReadFinancaDto, Despesas>();
            CreateMap<CreateFinancaDto, Despesas>();
            CreateMap<UpdateFinancaDto, Despesas>();

        }
    }
}
