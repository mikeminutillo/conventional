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

        internal IEnumerable<Registration> GetRegistrations()
        {
            var types = _typeSource.GetTypes().ToList();

            return from c in _conventions.AsParallel().AsOrdered()
                   let ct = c.GetType()
                   from t in types
                   where c.Matches(t)
                   select new Registration(ct, t);
        }
    }
}