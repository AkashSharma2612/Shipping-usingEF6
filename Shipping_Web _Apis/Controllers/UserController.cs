using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;
using Shipping_Web__Apis.ViewModels;

namespace Shipping_Web__Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IDataProtector _dataProtector;
        public UserController(IUserRepository userRepository, IDataProtectionProvider dataProtectionProvider, SecurityPurpose securityPurpose)
        {
            _userRepository = userRepository;
            _dataProtector = dataProtectionProvider.CreateProtector(securityPurpose.ClientRouteValue);
        }
        [HttpGet]
        public IActionResult GetUsers() {

            var userInList = _userRepository.GetUsers().Select(e =>
            {
                e.UserName = _dataProtector.Protect(e.UserName);
                e.Password = _dataProtector.Protect(e.Password);
                /*e.UserName = _dataProtector.Unprotect(e.UserName);
                e.Password = _dataProtector.Unprotect(e.Password);*/
               // e.Role = _dataProtector.Unprotect(e.Role);
                e.Role = _dataProtector.Protect(e.Role);
                return e;

            });
            return Ok(userInList);

        }
        [HttpPost("register")]
        public IActionResult Register([FromBody]USer user)
        {
            if (ModelState.IsValid)
            {
                var IsUniqueUser = _userRepository.IsUniqueUser(user.UserName);
                if (!IsUniqueUser)
                    return BadRequest("Username In Use");
                var UserInfo = _userRepository.Register(user.UserName, user.Password);
                if (UserInfo == null)
                    return BadRequest();
            }
            return Ok();
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserVM userVM)
        {
            var user = _userRepository.Authenticate(userVM.UserName, userVM.Password);
            if (user == null)
                return BadRequest("Wrong Username / Password");
            return Ok(user);
        }

    }
}
