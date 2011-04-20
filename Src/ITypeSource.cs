using System;
using System.Collections.Generic;

namespace Conventional
{
    public interface ITypeSource
    {
        IEnumerable<Type> GetTypes();
    }
}