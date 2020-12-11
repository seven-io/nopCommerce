using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugin.Misc.Sms77.Services;
using Nop.Plugin.Misc.Sms77.Services.Sms;
using Nop.Plugin.Misc.Sms77.Services.Voice;

namespace Nop.Plugin.Misc.Sms77.Infrastructure {
    /// <summary>Dependency registrar</summary>
    public class DependencyRegistrar : IDependencyRegistrar {
        /// <summary>Register services and interfaces</summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config) {
            builder.RegisterType<SmsService>().As<ISmsService>().InstancePerLifetimeScope();

            builder.RegisterType<VoiceService>().As<IVoiceService>().InstancePerLifetimeScope();
        }

        /// <summary>Order of this dependency registrar implementation</summary>
        public int Order => 1;
    }
}