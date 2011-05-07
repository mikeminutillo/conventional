using System.Reflection;

namespace Conventional
{
    public static class ScannerRegistryExtensions
    {
        public static ITypeScanner ScanAssembly(this IScannerRegistry registry, Assembly assembly)
        {
            Guard.IsNotNull(registry, "registry");
            Guard.IsNotNull(assembly, "assembly");

            var source = new FilteredTypeSource(t => t.IsConcreteClass(), new AssemblyTypeSource(assembly));
            return registry.Scan(source);
        }

        public static ITypeScanner ScanThisAssembly(this IScannerRegistry registry)
        {
            Guard.IsNotNull(registry, "registry");

            return registry.ScanAssembly(Assembly.GetCallingAssembly());
        }

        public static ITypeScanner ScanAssembly(this IScannerRegistry registry, string assembly)
        {
            Guard.IsNotNull(registry, "registry");
            Guard.IsNotNull(assembly, "assembly");

            return registry.ScanAssembly(Assembly.Load(assembly));
        }

        public static ITypeScanner ScanAssemblyContaining<T>(this IScannerRegistry registry)
        {
            Guard.IsNotNull(registry, "registry");

            return registry.ScanAssembly(typeof(T).Assembly);
        }        
    }
}