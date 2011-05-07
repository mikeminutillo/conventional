namespace Conventional
{
    public interface ITypeScanner : IHideObjectMembers
    {
        void AddConvention(IConvention convention);
    }
}