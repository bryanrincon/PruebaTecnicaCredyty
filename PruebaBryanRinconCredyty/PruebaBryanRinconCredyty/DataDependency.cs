using BusinessRules.Business;
using BusinessRules.Interfaces;
using Common;
using Common.Interfaces;
using DataAccess;
using DataAccess.Business;
using DataAccess.Interfaces;

namespace PruebaBryanRinconCredyty
{
    public static class DataDependency
    {
        public static WebApplicationBuilder AddDependency(this WebApplicationBuilder container)
        {
            //Common
            container.Services.AddScoped<IDatabaseConfig, DatabaseConfig>();
            //Data Access
            container.Services.AddScoped<IDapperRepository, DapperRepository>();
            container.Services.AddScoped<IRegistroRepository, RegistroRepository>();
            container.Services.AddScoped<ITipoVehiculoRepository, TipoVehiculoRepository>();
            //Business Rules
            container.Services.AddScoped<IRegistroBusiness, RegistroBusiness>();
            return container;
        }
    }
}
