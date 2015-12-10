
using AutoMapper;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.MVC.ViewModels;

namespace ProjetoModeloDocumentosDDD.MVC.AutoMapper
{
    public class DomianToViewModelMappingProfile : Profile
    {

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }

        }

        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<UsuarioSystemViewModel, UsuarioSystem>();
            Mapper.CreateMap<RgViewModel, Rg>();
            Mapper.CreateMap<CpfViewModel, Cpf>();
            Mapper.CreateMap<CnhViewModel, Cnh>();


        }
    }
}