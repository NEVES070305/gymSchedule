using Backend.Data;
using Backend.Models;
using GymScheduleBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("/")]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;


        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login/token")]
        public ActionResult<dynamic> Logar([FromBody] LoginModel loginModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = _context.Pessoas.FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);
                if (existingUser == null)
                {
                    return NotFound("Usuário ou senha incorretos.");
                }

                var token = JwtService.GenerateToken(existingUser);
                var refreshToken = JwtService.GenerateRefreshToken();
                JwtService.SaveRefreshToken(existingUser.Username, refreshToken);
                CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
                var expiredDateToken = token.expirationDate ?? DateTime.MinValue;
                DateTime timeUtc = expiredDateToken.ToUniversalTime();
                TimeZoneInfo destinyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                DateTime expiredDateTokenBr = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, destinyTimeZone);

                loginModel.Password = "";

                return new
                {
                    user = existingUser,
                    token = token.token,
                    refreshToken = refreshToken,
                    expiredDateToken = expiredDateTokenBr,
                };
            }
            catch (Exception)
            {
                // Logar o erro
                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }
        }



            }
        }
