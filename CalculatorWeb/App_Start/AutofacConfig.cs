using Autofac;
using Autofac.Integration.Mvc;
using ResistorValueCalculator;
using System.Reflection;
using System.Web.Mvc;

namespace OhmValueCalculator.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ResistorValueCalculator.ResistorValueCalculator>()
                .As<IResistorValueCalculator>().UsingConstructor().InstancePerLifetimeScope();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
        }
    }
}