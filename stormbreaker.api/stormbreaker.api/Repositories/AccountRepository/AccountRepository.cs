using AutoMapper;
using stormbreaker.api.Models.Database;
using stormbreaker.api.Models.Database.Models;
using stormbreaker.api.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace stormbreaker.api.Repositories.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StormbreakerContext _stormbreakerContext;
        private readonly IMapper _mapper;

        public AccountRepository(StormbreakerContext stormbreakerContext, IMapper mapper)
        {
            _stormbreakerContext = stormbreakerContext;
            _mapper = mapper;
        }

        public void AddAccount(int userId, AccountDTO accountDTO)
        {
            var account = _stormbreakerContext.Accounts.FirstOrDefault(x => x.User.Id == userId && x.Name == accountDTO.Name);
            var user = _stormbreakerContext.Users.FirstOrDefault(x => x.Id == userId);
            var accountToSave = _mapper.Map<AccountDTO, Account>(accountDTO);

            if (user == null)
            {
                throw new Exception("Cannot add account for the specified user because the specified user does not exist");
            }
            if (account != null)
            {
                throw new Exception("An Account with the specified name already exists");
            }
            else
            {
                try
                {
                    accountToSave.User = user;

                    _stormbreakerContext.Accounts.Add(accountToSave);
                    _stormbreakerContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeleteAccount(int id)
        {
            var account = _stormbreakerContext.Accounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                throw new Exception("The specified account does not exist");
            }
            else
            {
                _stormbreakerContext.Accounts.Remove(account);
                _stormbreakerContext.SaveChanges();
            }
        }

        public AccountDTO GetAccount(int id)
        {
            var account = _mapper.Map<Account, AccountDTO>(_stormbreakerContext.Accounts.FirstOrDefault(x => x.Id == id));

            if (account == null)
            {
                throw new Exception("The specified account does not exist");
            }

            return account;
        }

        public List<AccountDTO> GetAllAccounts()
        {
            return _mapper.Map<List<AccountDTO>>(_stormbreakerContext.Accounts.ToList());
        }

        public List<AccountDTO> GetAllAccountsForUser(int userId)
        {
            return _mapper.Map<List<AccountDTO>>(_stormbreakerContext.Accounts.Where(x => x.User.Id == userId).ToList());
        }

        public void UpdateAccount(int id, AccountDTO accountDTO)
        {
            var account = _stormbreakerContext.Accounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                throw new Exception("The specified user does not exist");
            }
            else
            {
                if (account.Description != accountDTO.Description && !string.IsNullOrWhiteSpace(accountDTO.Description))
                {
                    account.Description = accountDTO.Description;
                    account.Name = Regex.Replace(accountDTO.Description, @"\s+", string.Empty);
                }

                try
                {
                    _stormbreakerContext.Accounts.Update(account);
                    _stormbreakerContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
