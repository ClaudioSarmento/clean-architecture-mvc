using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication;
            _configuration = configuration;
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult> LoginUser([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
            return GenerateToken(userInfo);
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            // Criar as claims para o token
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("meuvalor", "o que eu quiser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Gerar a chave de segurança e as credenciais de assinatura
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));

            // Gerar as credenciais de assinatura usando a chave e o algoritmo HMAC SHA256
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            // Definir as informações do token, como emissor, audiência, claims, tempo de expiração e credenciais de assinatura
            var expiration = DateTime.UtcNow.AddMinutes(10);

            // Gerar o token JWT
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedToken = tokenHandler.WriteToken(token);

            return new UserToken();
        }
    }
}