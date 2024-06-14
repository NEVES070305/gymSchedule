﻿using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoRepository enderecoRepository;

        // Inicializa o EnderecoRepository através do construtor
        public EnderecoController(EnderecoRepository enderecoRepository)
        {
            this.enderecoRepository = enderecoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Endereco endereco)
        {
            enderecoRepository.Adicionar(endereco);
            return RedirectToAction("Index");
        }
    }
}