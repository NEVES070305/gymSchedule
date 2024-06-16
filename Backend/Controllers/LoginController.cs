using Backend.Data;
using Backend.Models;
using Backend.Repository;
using GymScheduleBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("/")]
    public class LoginController : Controller
    {
        private readonly PessoaRepository _pessoaRepository;

        public LoginController(PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogarView(LoginModel loginModel)
        {
            var existingUser = _pessoaRepository.BuscarPorUsernameESenha(loginModel);
            if (existingUser == null)
                return RedirectToAction("Index", "Home");
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

                var existingUser = _pessoaRepository.BuscarPorUsernameESenha(loginModel);
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
