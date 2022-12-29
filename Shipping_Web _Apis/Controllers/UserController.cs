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
      
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
           // _dataProtector = dataProtectionProvider.CreateProtector(securityPurpose.ClientRouteValue);
        }
        [HttpGet]
        public IActionResult GetUsers() {

            var userInList = _userRepository.GetUsers().ToList();
            var DataList = userInList.Select(e => new
            {
                id=e.Id,
                username=e.UserName,
                password=SecurityPurpose.DecryptionData(e.Password),
                Role=e.Role
            });
            return Ok(DataList);

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
