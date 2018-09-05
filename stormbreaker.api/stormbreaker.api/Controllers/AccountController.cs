using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stormbreaker.api.Models.DTO;
using stormbreaker.api.Repositories.AccountRepository;

namespace stormbreaker.api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepo;
        public AccountController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var accounts = _accountRepo.GetAllAccounts();

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var account = _accountRepo.GetAccount(id);

            return Ok(account);
        }

        [HttpGet("user/{id}")]
        public IActionResult GetForUser(int id)
        {
            var accounts = _accountRepo.GetAllAccountsForUser(id);

            return Ok(accounts);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] int userId, [FromBody] AccountDTO account)
        {
            _accountRepo.AddAccount(userId, account);

            return Ok(account);
        }

        // POST api/values
        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] AccountDTO account)
        {
            _accountRepo.UpdateAccount(id, account);

            return Ok(account);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _accountRepo.DeleteAccount(id);

            return Ok();
        }
    }
}