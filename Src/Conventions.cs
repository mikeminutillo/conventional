using System;

namespace Conventional
{
    /// <summary>
    /// The main entry point for Conventional
    /// </summary>
    public static class Conventions
    {
        private static bool _hasRun;
        private static readonly object ConfigureLock = new object();

        /// <summary>
        /// Set up Conventional installers and scanners and apply all conventions
        /// </summary>
        /// <param name="configuration">Instructions for how to apply conventions and where to find them</param>
        public static void Configure(Action<IConventionsConfigurator> configuration)
        {
            lock (ConfigureLock)
            {
                if (_hasRun)
                    throw new InvalidOperationException("You should only call Conventions.Configure once");
                Guard.IsNotNull(configuration, "configuration");

                var configurator = new ConventionsConfigurator();
                configuration(configurator);
                configurator.Run();
                _hasRun = true;
            }
        }

        /// <summary>
        /// Set up Conventional installers and scanners and apply all conventions
        /// </summary>
        /// <param name="profile">A class that knows about your conventions</param>
        public static void Configure(IConventionsProfile profile)
        {
            Configure(c =>
            {
                profile.SetupInstallers(c);
                profile.SetupScanners(c);
            });
        }

        /// <summary>
        /// Set up Conventional installers and scanners and apply all conventions
        /// </summary>
        /// <typeparam name="TProfile">A type that knows about your conventions and has a parameterless constructor</typeparam>
        public static void Configure<TProfile>() where TProfile : IConventionsProfile, new()
        {
            Configure(new TProfile());
        }
    }
}
