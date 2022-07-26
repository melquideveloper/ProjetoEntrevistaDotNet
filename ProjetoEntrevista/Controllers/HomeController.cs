﻿using Microsoft.AspNetCore.Mvc;
using ProjetoEntrevista.Models;
using System.Diagnostics;
using ProjetoEntrevista.Repositorio;
using ProjetoEntrevista.Filters;

namespace ProjetoEntrevista.Controllers
{
    [PaginaParaUsuárioLogado] // Essa invocação da classe que esta na pasta Filters, é para controlar o filtro de rota, para checar antes de acessar os método da home, verificar se existe usuário logado, para poder acessalos
    public class HomeController : Controller
    {
        public readonly IUsuarioRepositorio _iusuarioRepositorio;

        public HomeController(IUsuarioRepositorio iusuarioRepositorio)
        {
            _iusuarioRepositorio = iusuarioRepositorio;
        }


        public IActionResult Index(int id)
        {
            ModelUsuario usuario = _iusuarioRepositorio.BuscarUsuario(id);
            return View(usuario); //Verificar possibilidade de carregar pelo id vindo do LoginController, para carregar numa session!
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}