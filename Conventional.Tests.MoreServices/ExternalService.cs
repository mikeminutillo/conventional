namespace Conventional.Tests.MoreServices
{
    public class ExternalService : IServiceInterface
    {
    }

    internal interface IServiceInterface
    {
    }

    class SomeOtherExternalService : IOtherServiceInterface
    {
        
    }

    internal interface IOtherServiceInterface
    {
    }
}
