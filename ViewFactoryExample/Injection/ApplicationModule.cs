using System.Reflection;
using Autofac;
using ViewFactoryExample.Factory;
using Module = Autofac.Module;

namespace ViewFactoryExample.Injection
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(ViewModelFactory<>));
            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(ViewModelFactory<,>));
        }
    }
}