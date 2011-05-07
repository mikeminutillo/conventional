using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

        internal IEnumerable<Registration> GetRegistrations()
        {
            var types = new Lazy<IEnumerable<Type>>(() => _typeSource.GetTypes().ToList(),
                                                     LazyThreadSafetyMode.ExecutionAndPublication);

            return from c in _conventions.AsParallel().AsOrdered()
                   let ct = c.GetType()
                   from t in types.Value
                   where c.Matches(t)
                   select new Registration(ct, t);
        }
    }
}