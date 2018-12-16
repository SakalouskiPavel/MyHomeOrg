using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MyHomeOrg.Common.DbModels.User;
using MyHomeOrg.Common.DTO.User;
using MyHomeOrg.Common.Interfaces.Services.User;
using Swashbuckle.Swagger.Annotations;

namespace MyHomeOrg.WebApi.Areas.User.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "", typeof(string))]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(Account))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "", typeof(Exception))]
        public async Task<IHttpActionResult> RegisterUser([FromBody] RegisterUserDto data)
        {
            await _accountService.RegisterAsync(data);
            return Ok();
        }
    }
}
