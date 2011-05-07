using System;

namespace Conventional
{
    public static class InstallerRegistryExtensions
    {
        public static void Install<TConvention>(this IInstallerRegistry registry, Action<Type> installer) where TConvention : IConvention
        {
            Guard.IsNotNull(registry, "registry");
            Guard.IsNotNull(installer, "installer");

            registry.AddInstaller(typeof(TConvention), installer);
        }        
    }
}