using Autofac;

namespace ViewFactoryExample.Injection
{
    public class DependencyConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();

            return builder.Build();
        }
    }
}