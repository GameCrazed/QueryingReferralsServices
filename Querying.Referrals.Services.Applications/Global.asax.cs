using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Querying.Referrals.Services.Data.DataContexts;

namespace Querying.Referrals.Services.Applications
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Applications start.
        /// </summary>
        protected void Application_Start()
        {
            // AutoMapper.
            InitializeAutoMapper();

            // DI.
            AutofacConfig.ConfigureContainer();

            // MVC.
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        ///  Configures AutoMapper mappings.
        /// </summary>
        protected void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                MapBaseObjects(cfg);

                MapConvertedObjects(cfg);
            });
        }

        protected void MapConvertedObjects(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<LegalCustomerHistory, AsCustomerHistory>();

            cfg.CreateMap<AsCustomerHistory, LegalCustomerHistory>()
                .ForMember(dest => dest.customerID, opt => opt.MapFrom(src => src.customerID ?? -1))
                .ForMember(dest => dest.logtime, opt => opt.MapFrom(src => src.logtime ?? new DateTime(1900, 1, 1)));
        }

        protected void MapBaseObjects(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<LegalCustomerHistory, LegalCustomerHistory>();
            cfg.CreateMap<AsCustomerHistory, AsCustomerHistory>();
        }
    }
}
