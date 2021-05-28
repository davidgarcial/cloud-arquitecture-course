using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Account.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IConfiguration _configuration;

        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Models.Account>> GetAccounts()
        {
            var sp = "SP_LIST_ACCOUNT";
            var cn = new SqlConnection(_configuration.GetConnectionString("Account"));
            var result = await cn.QueryAsync<Models.Account>(
                    sp,
                    null,
                    commandType: CommandType.StoredProcedure
                );

            return result;

        }

        public async Task<bool> UpdateAccount(int idAccount, decimal amount)
        {
            var sp = "SP_UPDATE_ACCOUNT";
            var parameters = new DynamicParameters();
            parameters.Add("IDACCOUNT", idAccount);
            parameters.Add("AMOUNT", amount);
            var cn = new SqlConnection(_configuration.GetConnectionString("Account"));
            await cn.ExecuteAsync(
                    sp,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

            return true;
        }
    }
}