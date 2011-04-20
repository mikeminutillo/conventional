namespace Conventional.Tests.Helpers.Handlers
{
    class HandlerB : HandlerBBase
    {
    }

    abstract class HandlerBBase : IHandler<ClassB>
    {
        
    }

    internal class ClassB
    {
    }
}
