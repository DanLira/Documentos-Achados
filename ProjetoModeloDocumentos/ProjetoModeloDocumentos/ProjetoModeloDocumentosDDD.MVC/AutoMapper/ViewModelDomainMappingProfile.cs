

using AutoMapper;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.MVC.ViewModels;

namespace ProjetoModeloDocumentosDDD.MVC.AutoMapper
{
    public class ViewModelDomainMappingProfile : Profile
    {

        public override string ProfileName 
        {
            get { return "DomianToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<UsuarioSystem, UsuarioSystemViewModel>();
            Mapper.CreateMap<Rg, RgViewModel>();
            Mapper.CreateMap<Cpf, CpfViewModel>();
            Mapper.CreateMap<Cnh, CnhViewModel>();

        }
    }
}