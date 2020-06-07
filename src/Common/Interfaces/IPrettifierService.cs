using Common.Models;

namespace Common.Interfaces
{
    public interface IPrettifierService
    {
        PrettifyResponse Prettify<TInput>(TInput aNumber);
    }
}
