using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Module = Autofac.Module;

namespace ViewFactoryExample.Injection
{
    public class MvcModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // OPTIONAL: Inform Autofac.Mvc that we want to turn on the action invoker so
            // that if we ever want to do action method injection, we'll be setup and ready to go.
            builder
                .RegisterType<ExtensibleActionInvoker>()
                .As<IActionInvoker>()
                .WithParameter("injectActionMethodParameters", true);

            // Register our MVC controllers.
            builder
                .RegisterControllers(Assembly.GetExecutingAssembly())
                .InjectActionInvoker(); // <-- method call needed if we want action injection to function.

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Regiseter web abstractions liek HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());
        }
    }
}