namespace Conventional
{
    // REFACTOR: This being a "type scanner" is telling us about the implementation not the interface
    public interface ITypeScanner : IHideObjectMembers
    {
        void AddConvention(IConvention convention);
    }
}