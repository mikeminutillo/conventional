namespace Conventional
{
    public static class TypeScannerExtensions
    {
        public static ITypeScanner For<TConvention>(this ITypeScanner scanner) where TConvention : IConvention, new()
        {
            Guard.IsNotNull(scanner, "scanner");

            scanner.AddConvention(new TConvention());
            return scanner;
        }
    }
}