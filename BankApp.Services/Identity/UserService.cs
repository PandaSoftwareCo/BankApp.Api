using BankApp.Application.DTOs.User;
using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Data.Repositories;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BankApp.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IAppSettings appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

            //var userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
        //private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier));

        public void AddUser(User user, string password)
        {
            //user.PasswordSalt = Guid.NewGuid();
            //string saltedPassword = password + user.PasswordSalt;
            //var passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);
            //HashAlgorithm sha512 = SHA512.Create();
            //user.PasswordHash = sha512.ComputeHash(passwordBytes);

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userRepository.Add(user);
            _userRepository.UnitOfWork.SaveChanges();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            //var user = _context.Users.FirstOrDefault(i => i.Username == request.Username);
            var user = _userRepository.GetUserByUsername(request.Username).Result;
            if (user == null)
            {
                return null;
            }
            if(!user.IsAuthentic(request.Password))
            {
                return null;
            }
            string token = GenerateJwtToken(user, out DateTime expires);
            return new AuthenticateResponse(user, token, expires);
        }

        public User? GetById(int id) => _userRepository.FindAsync(id).Result;

        private string GenerateJwtToken(User user, out DateTime expires)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            expires = DateTime.UtcNow.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Subject = new ClaimsIdentity(new[]
                //{
                //    new Claim("id", user.UserId.ToString()),
                //}),
                Subject = new ClaimsIdentity(claims),
                Claims = new Dictionary<string, object>
                {
                    { "test", 42 }
                },
                Issuer = "BankApp.Api",
                Audience = "BankApp",
                IssuedAt = DateTime.UtcNow,
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }
    }
}
