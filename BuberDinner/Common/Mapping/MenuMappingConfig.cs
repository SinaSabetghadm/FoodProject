using Buber.Application.Menus.Command;
using Buber.Contracts.Menu;
using Mapster;

namespace BuberDinner.Common.Mapping
{
    public class MenuMappingConfig:IRegister
    {
        public void Register(TypeAdapterConfig config) { config.NewConfig<CreateMenuRequest, CreateMenuCommand>(); ; }  
    }
}
