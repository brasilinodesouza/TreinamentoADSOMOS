﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IDataService _dataService;
        public PedidoController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        public IActionResult Carrosel()
        {
            List<Produto> produtos = _dataService.GetProdutos();

            return View(produtos); 
        
        }

        public IActionResult Carrinho()
        {
            CarrinhoViewModel viewModel = GerCarrinhoViewModel();

            return View(viewModel);
        }

        private CarrinhoViewModel GerCarrinhoViewModel()
        {
            List<Produto> produtos =
                this._dataService.GetProdutos();

            var itensCarrinho = this._dataService.GetItensPedidos();

            CarrinhoViewModel viewModel = new CarrinhoViewModel(itensCarrinho);
            return viewModel;
        }

        public IActionResult Resumo()
        {
            CarrinhoViewModel viewModel = GerCarrinhoViewModel();

            return View(viewModel); 
        }
    }
}
