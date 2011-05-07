using System;
using System.Collections.Generic;
using System.Linq;

namespace Conventional
{
    public class FilteredTypeSource : ITypeSource
    {
        private readonly Func<Type, bool> _filter;
        private readonly ITypeSource _inner;

        public FilteredTypeSource(Func<Type, bool> filter, ITypeSource inner)
        {
            Guard.IsNotNull(filter, "filter");
            Guard.IsNotNull(inner, "inner");

            _filter = filter;
            _inner = inner;
        }

        public IEnumerable<Type> GetTypes()
        {
            return _inner.GetTypes().Where(_filter);
        }
    }
}