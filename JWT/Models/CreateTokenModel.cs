using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Models
{
    public class CreateTokenModel
    {
        public string CrtTokenVisitor()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoremvcapi_superr_secret_key_12346");

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> _claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Visitor")
            };


            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(3), signingCredentials: credentials, claims:_claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

           return handler.WriteToken(token);
        }

        public string CrtTokenAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoremvcapi_superr_secret_key_12346");

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> _claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin")
            };


            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(3), signingCredentials: credentials, claims: _claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }


}
