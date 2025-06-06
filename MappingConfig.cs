using AutoMapper;
using ArticulosAPI.Dto;
using ArticulosAPI.Modelos;

namespace ArticulosAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ArticuloDto, Articulo>();
                config.CreateMap<Articulo, ArticuloDto>();
            });
            return mappingConfig;
        }
    }
}
