namespace Conventional
{
    public interface IScannerRegistry : IHideObjectMembers
    {
        ITypeScanner Scan(ITypeSource typeSource);
    }
}