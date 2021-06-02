using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Account.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Models.Account>> GetAccounts();
        Task<bool> UpdateAccount(int idAccount, decimal amount);
    }
}
