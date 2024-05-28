using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ConsultApi.Models;
using ConsultApi.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;


namespace ConsultApi.Services
    {
        public static class JwtService
        {
            public static (string token, DateTime? expirationDate) GenerateToken(User user)
            {
                var tokenHandler = new JwtSecurityTokenHandler(); //Classe que gera o token realmente
                var key = Encoding.ASCII.GetBytes(Settings.Secret);

                var tokenDescritor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(

                        new[]
                        {
                            new Claim(ClaimTypes.Name, user.Username), // User.Identity.Name
                            new Claim(ClaimTypes.Role, user.Role)
                        }),

                    Expires = DateTime.UtcNow.AddMinutes(120),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescritor);
                return (tokenHandler.WriteToken(token), tokenDescritor.Expires);
            }

            public static (string newJwtToken, DateTime? expirationDate) GenerateToken(IEnumerable<Claim> claims)
            {
                var tokenHandler = new JwtSecurityTokenHandler(); //Classe que gera o token realmente
                var key = Encoding.ASCII.GetBytes(Settings.Secret);

                var tokenDescritor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),

                    Expires = DateTime.UtcNow.AddMinutes(120),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescritor);
                return (tokenHandler.WriteToken(token), tokenDescritor.Expires);
            }

            public static string GenerateRefreshToken()
            {
                var randomNumber = new byte[32];
                using var rng = RandomNumberGenerator.Create();
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }

            public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
            {
                try
                {
                    var tokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret)),
                        ValidateLifetime = false
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
                    if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(value: SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase))
                        throw new SecurityTokenException(message: "Invalid token");
                    return principal;
                }
                catch
                {
                    return null;
                }

            }

            private static List<(string, string)> _refreshTokens = new();

            public static void SaveRefreshToken(string username, string refreshToken)
            {
                _refreshTokens.Add(new(username, refreshToken));
            }

            public static string GetRefreshToken(string username)
            {
                return _refreshTokens.FirstOrDefault(x => x.Item1 == username).Item2;
            }

            public static void DeleteRefreshToken(string username, string refreshToken)
            {
                var item = _refreshTokens.FirstOrDefault(x => x.Item1 == username && x.Item2 == refreshToken);
                _refreshTokens.Remove(item);
            }

            public static void ValidateToken(string token)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Settings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // Não aceitar tokens que expiraram
                };

                SecurityToken validatedToken;
                tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }

        }
    }

