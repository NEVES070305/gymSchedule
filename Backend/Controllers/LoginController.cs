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

namespace Backend.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;


        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<dynamic> Index(Pessoa model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = _context.Pessoas.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (existingUser == null)
            {
                return NotFound("Usuário ou senha incorretos.");
            }
            var token = JwtService.GenerateToken(existingUser);
            var refreshToken = JwtService.GenerateRefreshToken();
            JwtService.SaveRefreshToken(existingUser.Username, refreshToken);
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
            var expiredDateToken = token.expirationDate;

            // Convertendo DateTime? para DateTime usando coalescência nula
            DateTime dateTime = expiredDateToken ?? DateTime.MinValue;

            // Converte o horário original para UTC
            DateTime timeUtc = dateTime.ToUniversalTime();

            TimeZoneInfo destinyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime expiredDateTokenBr = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, destinyTimeZone);

            model.Password = "";
            return new
            {
                user = existingUser,
                token = token.token,
                refreshToken = refreshToken,
                expiredDateToken = expiredDateTokenBr,
            };
        }


    }
}
