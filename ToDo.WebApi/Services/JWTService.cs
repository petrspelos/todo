using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDo.WebApi.Config;
using ToDo.WebApi.Entities;

namespace ToDo.WebApi.Services {
    public class JWTService : IAuthService
    {

        public JWTService() {
        }

        public string GenerateToken(IAuthModel model)
        {
            if (model == null || model.Claims.Length == 0)
                throw new ArgumentException("Arguments to create token are not valid.");
            var jwtToken = new JwtSecurityToken(
               issuer:"todo",
               audience:"todo",
               claims: model.Claims,
               expires: DateTime.UtcNow.AddSeconds(Convert.ToInt32(AuthConfig.ExpireSeconds)),
               signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), AuthConfig.SecurityAlgorithm)
            );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            string token = jwtSecurityTokenHandler.WriteToken(jwtToken);

            return token;

        }

        public string GenerateTokenFromUser(User user) {
            var claims = new[] { 
                new Claim(ClaimTypes.Name, user.Username)
            };
            return GenerateToken(new JWTModel(claims));
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Given token is null or empty.");

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return tokenValid.Claims;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Given token is null or empty.");

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

         private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Encoding.UTF8.GetBytes(AuthConfig.SecretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }
    }
}
