using System.Linq;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeSender.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : StorageController<Account>
    {
        private readonly ApplicationContext _db;
        private readonly ILogger _logger;
        
        public AccountsController(ApplicationContext context, ILogger<AccountsController> logger) 
            : base(context, context.Accounts, logger)
        {
            this._db = context;
            this._logger = logger;
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Account settings)
        {
            if (settings == null)
            {
                return new BadRequestObjectResult("No settings was provided");   
            }
            
            this._logger.LogInformation($"Update account settings: {settings.ToJson()}");

            if (this._db.Accounts.Any(s => s.Login == settings.Login))
            {
                this._db.Accounts.RemoveRange(this._db.Accounts.Where(s => s.Login == settings.Login));
            }

            this._db.Accounts.Add(settings);
            this._db.SaveChanges();
            return new OkObjectResult(settings);
        }
    }
}