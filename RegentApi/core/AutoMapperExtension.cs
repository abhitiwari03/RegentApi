using AutoMapper;

namespace RegentApi.core
{
    public  static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Models.DataMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
