using System;
using System.Collections.Generic;
using System.Reflection;

namespace Conventional
{
    public class AssemblyTypeSource : ITypeSource
    {
        private readonly Assembly _assembly;

        public AssemblyTypeSource(Assembly assembly)
        {
            Guard.IsNotNull(assembly, "assembly");

            _assembly = assembly;
        }

        public IEnumerable<Type> GetTypes()
        {
            return _assembly.GetTypes();
        }
    }
}