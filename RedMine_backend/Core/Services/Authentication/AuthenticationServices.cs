using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RedMine_backend.Core.Services.Authentication
{
    public class AuthenticationServices
    {
        private readonly static  string secret = "ThisIsTestKey123456789hdkasbdajkhbdkjahsbdjkhsajadshbkshj";
        public static string GenerateJwtToken(string userId, bool admin)
        {
            DataBaseOperations get = new DataBaseOperations();

            var tokenHandler = new JwtSecurityTokenHandler();
            Claim AdminProperty = null;
            Claim ManagerID = new Claim("UserID", get.ManagerIDByName(userId).Result.ToString());
            if (admin)
            {
                AdminProperty = new Claim(ClaimTypes.Role, "admin");
            }
            else
            {
                AdminProperty = new Claim(ClaimTypes.Role, "guest");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim(ClaimTypes.Name, userId),
                    AdminProperty,
                    ManagerID
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(GenerateSecret()), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static byte[] GenerateSecret()
        {
            return Encoding.UTF8.GetBytes(secret);
        }
    }
}