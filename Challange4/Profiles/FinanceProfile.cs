using AutoMapper;
using Challange4.Data.Dtos;
using Challange4.Models;

namespace Challange4.Profiles
{
    public class FinanceProfile: Profile
    {
        public FinanceProfile()
        {
            CreateMap<CreateReceitasDto, Receitas>();
            CreateMap<UpdateReceitasDto, Receitas>();
            CreateMap<Receitas,UpdateReceitasDto>();
            CreateMap<Receitas, ReadReceitasDto>();
            CreateMap<ReadReceitasDto,Receitas>();
            CreateMap<List<ReadReceitasDto>,Receitas>();
            
        }
    }
}
