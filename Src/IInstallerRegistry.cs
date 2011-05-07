using System;

namespace Conventional
{
    public interface IInstallerRegistry : IHideObjectMembers
    {
        void AddInstaller(Type conventionType, Action<Type> installer);
    }
}