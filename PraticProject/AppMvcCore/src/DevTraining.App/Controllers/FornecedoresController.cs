using AutoMapper;
using DevTraining.App.Configurations;
using DevTraining.App.Models;
using DevTraining.Business.Interfaces;
using DevTraining.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevTraining.App.Controllers
{
    [Route("fornecedores")]
    [Authorize]
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        // private readonly IEnderecoRepository _enderecoRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;
        private readonly ILogger<FornecedoresController> _logger;


        public FornecedoresController(IFornecedorRepository fornecedorRepository,
            IMapper mapper,
            IFornecedorService fornecedorService,
            INotificador notificador, ILogger<FornecedoresController> logger) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
            _logger = logger;
        }

        [Route("lista-de-fornecedores")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation(LoggingConfig.GETFORNECEDOR);
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos()));
        }

        [Route("dados-do-fornecedores/{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);
            if (fornecedorViewModel == null)
                return NotFound();


            _logger.LogInformation(LoggingConfig.DETAILSTFORNECEDOR);
            return View(fornecedorViewModel);
        }

        [Route("criar-fornecedores")]
        [ClaimsAuthorize("Fornecedor", "Adicionar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("criar-fornecedores")]
        [ClaimsAuthorize("Fornecedor", "Adicionar")]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
                return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorService.Adicionar(fornecedor);

            if (!OperacaoValida())
                return View(fornecedorViewModel);


            _logger.LogInformation(LoggingConfig.POSTFORNECEDOR);
            return RedirectToAction("Index");
        }

        [Route("atualizar-fornecedores/{id:guid}")]
        [ClaimsAuthorize("Fornecedor", "Editar")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorViewModel == null)
                return NotFound();

            return View(fornecedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("atualizar-fornecedores/{id:guid}")]
        [ClaimsAuthorize("Fornecedor", "Editar")]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorService.Atualizar(fornecedor);

            if (!OperacaoValida())
                return View(await ObterFornecedorProdutosEndereco(id));

            _logger.LogInformation(LoggingConfig.UPDATFORNECEDOR);
            return RedirectToAction("Index");
        }

        [Route("excluir-fornecedores/{id:guid}")]
        [ClaimsAuthorize("Fornecedor", "Excluir")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
                return NotFound();

            return View(fornecedorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("excluir-fornecedores/{id:guid}")]
        [ClaimsAuthorize("Fornecedor", "Excluir")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null)
                return NotFound();

            await _fornecedorService.Remover(id);

            if (!OperacaoValida())
                return View(fornecedor);


            _logger.LogInformation(LoggingConfig.DELETTFORNECEDOR);
            return RedirectToAction("Index");
        }

        [Route("atualizar-enderecos/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null)
                return NotFound();

            return PartialView("_AtualizarEndereco", new FornecedorViewModel { Endereco = fornecedor.Endereco });
        }

        [Route("obter-endereco/{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObterEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            return PartialView("_DetalhesEndereco", fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("Fornecedor", "Editar")]
        public async Task<IActionResult> AtualizarEndereco(FornecedorViewModel fornecedorViewModel)
        {

            ModelState.Remove("Nome");
            ModelState.Remove("Documento");

            if (!ModelState.IsValid)
                return PartialView("_AtualizarEndereco", fornecedorViewModel);

            await _fornecedorService.AtualizarEndereco(_mapper.Map<Endereco>(fornecedorViewModel.Endereco));

            if (!OperacaoValida())
                return PartialView("_AtualizarEndereco", fornecedorViewModel);

            var url = Url.Action("ObterEndereco", "Fornecedores", new { id = fornecedorViewModel.Endereco.FornecedorId });
            return Json(new { sucess = true, url });
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
    }
}
