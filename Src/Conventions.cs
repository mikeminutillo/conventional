using System;

namespace Conventional
{
    public static class Conventions
    {
        private static bool _hasRun;
        private static readonly object ConfigureLock = new object();

        public static void Configure(Action<IConventionsConfigurator> configuration)
        {
            lock (ConfigureLock)
            {
                if (_hasRun)
                    throw new InvalidOperationException("You should only call Conventions.Configure once");
                var configurator = new ConventionsConfigurator();
                configuration(configurator);
                configurator.Run();
                _hasRun = true;
            }
        }

    }
}
