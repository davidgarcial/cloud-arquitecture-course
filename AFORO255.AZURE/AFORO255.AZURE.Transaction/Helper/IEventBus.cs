using System.Threading.Tasks;

namespace AFORO255.AZURE.Transaction.Helper
{
    public interface IEventBus
    {
        Task<bool> PublishMessage(object request);
    }
}
