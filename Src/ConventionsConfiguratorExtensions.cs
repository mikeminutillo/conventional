using System;
using System.Reflection;

namespace Conventional
{
    public static class ConventionsConfiguratorExtensions
    {
        public static void Install<TConvention>(this IConventionsConfigurator config, Action<Type> installer) where TConvention : IConvention
        {
            Guard.IsNotNull(config, "config");
            Guard.IsNotNull(installer, "installer");

            config.AddInstaller(typeof(TConvention), installer);
        }

        public static ITypeScanner ScanAssembly(this IConventionsConfigurator config, Assembly assembly)
        {
            Guard.IsNotNull(config, "config");
            Guard.IsNotNull(assembly, "assembly");

            var source = new FilteredTypeSource(t => t.IsConcreteClass(), new AssemblyTypeSource(assembly));
            return config.Scan(source);
        }

        public static ITypeScanner ScanThisAssembly(this IConventionsConfigurator config)
        {
            return config.ScanAssembly(Assembly.GetCallingAssembly());
        }

        public static ITypeScanner ScanAssembly(this IConventionsConfigurator config, string assembly)
        {
            Guard.IsNotNull(config, "config");
            Guard.IsNotNull(assembly, "assembly");

            return config.ScanAssembly(Assembly.Load(assembly));
        }

        public static ITypeScanner ScanAssemblyContaining<T>(this IConventionsConfigurator config)
        {
            Guard.IsNotNull(config, "config");

            return config.ScanAssembly(typeof(T).Assembly);
        }
    }
}