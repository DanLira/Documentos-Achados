

using AutoMapper;

namespace ProjetoModeloDocumentosDDD.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void ResgisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomianToViewModelMappingProfile>();
                x.AddProfile<ViewModelDomainMappingProfile>();

            });

        }

    }
}