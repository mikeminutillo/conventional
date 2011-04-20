using System;
using System.Collections.Generic;

namespace Conventional
{
    class ConventionsConfigurator : IConventionsConfigurator
    {
        private readonly IDictionary<Type, Action<Type>> _installers = new Dictionary<Type, Action<Type>>();
        private readonly IList<TypeScanner> _typeScanners = new List<TypeScanner>();

        internal void Run()
        {
            foreach (var scanner in _typeScanners)
                scanner.Run(GetInstaller);
        }

        private Action<Type> GetInstaller(Type key)
        {
            Action<Type> installer;
            if (!_installers.TryGetValue(key, out installer))
                throw new ArgumentOutOfRangeException(String.Format("There is not an installer for {0}.", key.FullName));
            return installer;
        }

        public void AddInstaller(Type conventionType, Action<Type> installer)
        {
            _installers[conventionType] = installer;
        }

        public ITypeScanner Scan(ITypeSource typeSource)
        {
            var scanner = new TypeScanner(typeSource);
            _typeScanners.Add(scanner);
            return scanner;
        }
    }
}