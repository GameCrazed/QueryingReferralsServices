using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Querying.Referrals.Services.Applications.Helpers;
using Querying.Referrals.Services.Applications.Services.AppRepositoryServices.QueryingService;
using Querying.Referrals.Services.Applications.Services.AutoMapperServices;
using Querying.Referrals.Services.Applications.Services.NLogServices;
using Querying.Referrals.Services.Repository.Applications;

namespace Querying.Referrals.Services.Applications
{
    public class AutofacConfig
    {
        public static IContainer ApiContainer { get; private set; }

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register the mapper.
            builder.RegisterType<AutoMapperService>().As<IAutoMapperService>();

            // Register our Data dependencies
            // Generic Repo
            builder.RegisterType<ApplicationsRepository>().As<IApplicationsRepository>();

            // Helpers
            builder.RegisterType<ApiJsonHelper>().As<IApiJsonHelper>();

            // Services
            builder.RegisterType<NLogService>().As<INLogService>();
            builder.RegisterType<AutoMapperService>().As<IAutoMapperService>();

            // Production Repository Services
            builder.RegisterType<AsReleaseRepositoryService>().As<IAsReleaseRepositoryService>();
            builder.RegisterType<ReferralRepositoryService>().As<IReferralRepositoryService>();
            builder.RegisterType<LegalRepositoryService>().As<ILegalRepositoryService>();

            //var container = builder.Build();
            ApiContainer = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(ApiContainer));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(ApiContainer);
        }
    }
}