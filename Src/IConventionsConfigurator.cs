using System;

namespace Conventional
{
    public interface IConventionsConfigurator
    {
        void AddInstaller(Type conventionType, Action<Type> installer);
        ITypeScanner Scan(ITypeSource typeSource);
    }
}