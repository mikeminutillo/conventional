using System;

namespace Conventional
{
    public interface IConventionsConfigurator : IHideObjectMembers
    {
        void AddInstaller(Type conventionType, Action<Type> installer);
        ITypeScanner Scan(ITypeSource typeSource);
    }
}