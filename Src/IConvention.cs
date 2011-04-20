using System;

namespace Conventional
{
    public interface IConvention
    {
        bool Matches(Type t);
    }
}