using stormbreaker.api.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        List<AccountDTO> GetAllAccounts();
        List<AccountDTO> GetAllAccountsForUser(int userId);
        AccountDTO GetAccount(int id);
        void AddAccount(int userId, AccountDTO accountDTO);
        void UpdateAccount(int id, AccountDTO accountDTO);
        void DeleteAccount(int id);
    }
}
