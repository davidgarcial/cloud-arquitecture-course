using System.Threading.Tasks;

namespace AFORO255.AZURE.Account.Helper
{
    public interface ISuscribeTransaction
    {
        Task Process();
        Task CloseSuscribe();
    }
}
