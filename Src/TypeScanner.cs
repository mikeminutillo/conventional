using System;
using System.Collections.Generic;
using System.Linq;

namespace Conventional
{
    public class TypeScanner : ITypeScanner
    {
        private readonly ITypeSource _typeSource;
        private readonly IList<IConvention> _conventions = new List<IConvention>();

        public TypeScanner(ITypeSource typeSource)
        {
            _typeSource = typeSource;
        }

        public void AddConvention(IConvention convention)
        {
            _conventions.Add(convention);
        }

        internal void Run(Func<Type, Action<Type>> installers)
        {
            var types = _typeSource.GetTypes().ToList();

            foreach (var convention in _conventions)
                foreach (var type in types)
                    if (convention.Matches(type))
                        installers(convention.GetType())(type);
        }
    }
}