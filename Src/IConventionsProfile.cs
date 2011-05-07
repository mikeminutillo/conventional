namespace Conventional
{
    public interface IConventionsProfile
    {
        void SetupInstallers(IInstallerRegistry registry);
        void SetupScanners(IScannerRegistry registry);
    }
}