using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shipping_Web__Apis.DataAccess;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shipping_Web__Apis.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appsettings;
        public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appsettings = appSettings.Value;

        }
        public USer Authenticate(string Username, string password)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.UserName == Username && u.Password == password);
            if (userInDb == null)
                return null;
            //JWT Autentication
            var TokenHandeler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,userInDb.Id.ToString()),
                    new Claim(ClaimTypes.Role,userInDb.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = TokenHandeler.CreateToken(tokenDescriptor);
            userInDb.Token = TokenHandeler.WriteToken(token);
            userInDb.Password = "";
            return userInDb;
        }

        public ICollection<USer> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool IsUniqueUser(string Username)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == Username);
            if (user == null)
                return true;
            else
                return false;
        }

        public USer Register(string Username, string Password)
        {
            USer user = new USer()
            {
                UserName = Username,
                Password = Password,
                Role = "Admin"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

    }
}
