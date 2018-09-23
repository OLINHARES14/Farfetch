namespace Farfetch.Infra.Mapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //cfg.AddProfile(new ViewToDtoMappingProfile());
            });
        }
    }
}
